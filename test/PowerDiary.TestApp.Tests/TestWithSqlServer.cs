using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerDiary.TestApp.EntityFrameworkCore;
using PowerDiary.TestApp.Services.Chat;
using PowerDiary.TestApp.Shared.Chat;
using System.Collections.Generic;

namespace PowerDiary.TestApp.Tests
{
    public abstract class TestWithSqlServer
    {
        private const string TestConnectionString = @"Server=(localdb)\mssqllocaldb;Database=TestAppDb;ConnectRetryCount=0";
        private readonly TestAppDbContext _dbContext;
        protected readonly ServiceProvider _serviceProvider;

        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        protected TestWithSqlServer()
        {
            var config = new ConfigurationBuilder().AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"ConnectionStrings:DefaultConnection", TestConnectionString},
                }
            );

            var configuration = config.Build();

            _serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddScoped<IChatService, ChatService>()
                .AddSingleton<IDbCommands, DbCommands>()
                .AddDbContext<TestAppDbContext>(options => options.UseSqlServer(TestConnectionString))
                .BuildServiceProvider();

            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    _dbContext = _serviceProvider.GetRequiredService<TestAppDbContext>();

                    _dbContext.Database.EnsureDeleted();
                    _dbContext.Database.Migrate();
                    _databaseInitialized = true;
                }
            }
        }
    }
}

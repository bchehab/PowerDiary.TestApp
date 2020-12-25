using Microsoft.EntityFrameworkCore;
using PowerDiary.TestApp.Core;

namespace PowerDiary.TestApp.EntityFrameworkCore
{
    public class TestAppDbContext: DbContext
    {
        public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ChatEvent> ChatEvents { get; set; }
        public DbSet<ChatEventType> ChatEventTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}

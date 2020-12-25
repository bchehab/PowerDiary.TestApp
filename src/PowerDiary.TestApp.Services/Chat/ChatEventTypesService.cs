using Microsoft.EntityFrameworkCore;
using PowerDiary.TestApp.EntityFrameworkCore;
using PowerDiary.TestApp.Shared.ChatEventType;
using PowerDiary.TestApp.Shared.ChatEventType.Dto;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PowerDiary.TestApp.Services.Chat
{
    public class ChatEventTypesService : IChatEventTypesService
    {
        private readonly TestAppDbContext _dbContext;

        public ChatEventTypesService(TestAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ChatEventTypeDto[]> GetAll()
        {
            return await _dbContext.ChatEventTypes.Select(x => new ChatEventTypeDto
            {
                Id = x.Id,
                Description = x.Description
            }).ToArrayAsync();
        }
    }
}

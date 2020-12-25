using Microsoft.EntityFrameworkCore;
using PowerDiary.TestApp.Core;
using PowerDiary.TestApp.EntityFrameworkCore;
using PowerDiary.TestApp.Services.Helpers;
using PowerDiary.TestApp.Shared.Chat;
using PowerDiary.TestApp.Shared.Chat.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PowerDiary.TestApp.Services.Chat
{
    public class ChatService : IChatService
    {
        private readonly TestAppDbContext _dbContext;
        private readonly IDbCommands _dbCommands;
        public ChatService(TestAppDbContext dbContext, IDbCommands dbCommands)
        {
            _dbContext = dbContext;
            _dbCommands = dbCommands;
        }

        public async Task<DailyChatOutputDto> GetDailyChat(DailyChatInputDto dto)
        {
            if (dto.ChatEventTypeId != null && !Enum.IsDefined(typeof(ChatEventTypes), dto.ChatEventTypeId))
            {
                throw new UserFriendlyException("Invalid Event Type");
            }

            var query = from e in _dbContext.ChatEvents
                        join u1 in _dbContext.Users on e.User1Id equals u1.Id
                        join u2 in _dbContext.Users on e.User2Id equals u2.Id into utemp
                        from u2 in utemp.DefaultIfEmpty()
                        where e.IsActive
                        && (dto.ChatEventTypeId == null || e.ChatEventTypeId == dto.ChatEventTypeId)
                        orderby e.CreatedDate
                        select new
                        {
                            ChatEventTypeId = e.ChatEventTypeId,
                            User1 = u1.Username,
                            User2 = u2 != null ? u2.Username : null,
                            Message = e.Message,
                            CreatedDate = e.CreatedDate
                        };

            var total = await query.CountAsync();

            var messages = await query.Skip(dto.ToSkip).Take(dto.PageSize)
                .Select(e => new ChatDto
                {
                    Time = e.CreatedDate,
                    Message = ChatEventsHelper.ParseChatEvent(e.ChatEventTypeId, e.Message, e.User1, e.User2)
                }).ToListAsync();

            var result = new DailyChatOutputDto { TotalCount = total, ChatMessages = messages };

            return result;
        }

        public ChatSummaryDto[] GetHourlyChatSummary()
        {
            var dt = _dbCommands.ExecuteProcedure("GetHourlySummary");

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            var summary = dt.AsEnumerable()
                .Select(r => new EventSummaryDto
                {
                    Time = r.Field<int>("Time"),
                    TimeDisplay = r.Field<string>("TimeDisplay"),
                    Name = r.Field<string>("Name"),
                    EventTypeId = r.Field<int>("EventTypeId"),
                    EventCount = r.Field<int>("EventCount"),
                    HighFiveCount = r.Field<int>("HighFiveCount")
                })
                .GroupBy(r => r.TimeDisplay)
                .Select(g => new ChatSummaryDto
                {
                    Time = g.Key,
                    Events = g.Select(e => new HourlyEventDto
                    {
                        EventTypeId = e.EventTypeId,
                        Name = e.Name,
                        Time = e.Time,
                        EventCount = e.EventCount,
                        HighFiveCount = e.HighFiveCount,
                        EventDisplay = ChatEventsHelper.SummarizeChatEvents(e.EventTypeId, e.EventCount, e.HighFiveCount)
                    }).ToArray()
                }).ToArray();

            return summary;
        }
    }
}

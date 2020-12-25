using Microsoft.EntityFrameworkCore;
using PowerDiary.TestApp.Shared.Chat;
using PowerDiary.TestApp.Shared.Chat.Dto;
using Shouldly;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using PowerDiary.TestApp.EntityFrameworkCore;
using System.Linq;
using PowerDiary.TestApp.Core;

namespace PowerDiary.TestApp.Tests
{
    public class ChatService_Tests : TestWithSqlServer
    {
        private readonly IChatService _chatService;
        private readonly TestAppDbContext _dbContext;
        public ChatService_Tests()
        {
            _chatService = _serviceProvider.GetRequiredService<IChatService>();
            _dbContext = _serviceProvider.GetRequiredService<TestAppDbContext>();
        }

        [Fact]
        public async void GetDailyChat_Test()
        {
            var dto = new DailyChatInputDto
            {
                PageNumber = 1,
                PageSize = 100
            };

            var activeChats = await _chatService.GetDailyChat(dto);

            //1 inactive
            activeChats.TotalCount.ShouldBe(13);

            //page size should be the same as the total above
            activeChats.ChatMessages.Count.ShouldBe(13);

            var allChatsCount = await _dbContext.ChatEvents.CountAsync();

            allChatsCount.ShouldBe(14);

            activeChats.ChatMessages.First().Time.ShouldBe(Clock.GetTimeDate(2020, 12, 24, 17, 0));

            activeChats.ChatMessages.Last().Time.ShouldBe(Clock.GetTimeDate(2020, 12, 24, 18, 25));
        }

        [Fact]
        public async void GetDailyChat_Paging_Test()
        {
            var dto = new DailyChatInputDto
            {
                PageNumber = 1,
                PageSize = 8
            };

            var activeChats = await _chatService.GetDailyChat(dto);

            activeChats.TotalCount.ShouldBe(13);

            activeChats.ChatMessages.Count.ShouldBe(8);

            activeChats.ChatMessages.First().Time.ShouldBe(Clock.GetTimeDate(2020, 12, 24, 17, 0));

            //message no.8 is at 6pm
            activeChats.ChatMessages.Last().Time.ShouldBe(Clock.GetTimeDate(2020, 12, 24, 18, 0));
        }

        [Fact]
        public async void GetDailyChat_InvalidEventType_Test()
        {
            //didnt add a test for pagenumber & pagesize, since i opted to handle them with dto attributes
            //so they are validated at the api level, and here we are directly calling the services and 
            //bypassing the api

            var dto = new DailyChatInputDto
            {
                PageNumber = 1,
                PageSize = 15,
                ChatEventTypeId = 5 //invalid ChatEventTypeId
            };

            await Should.ThrowAsync<UserFriendlyException>(async () => await _chatService.GetDailyChat(dto));
        }

        [Fact]
        public void GetHourlyChatSummary_Test()
        {
            var data = _chatService.GetHourlyChatSummary();

            data.Length.ShouldBe(2);

            //5pm data
            var firstGroup = data.First();
            
            firstGroup.Time.ShouldBe("5 PM");

            //all four types of events happened between 5 to 6
            firstGroup.Events.Count().ShouldBe(4);

            //2 comments at 5pm
            firstGroup.Events.First(e => e.EventTypeId == (int)ChatEventTypes.Comment).EventCount.ShouldBe(2);

            //6pm data
            var lastGroup = data.Last();

            lastGroup.Time.ShouldBe("6 PM");

            //2 types of events happened at 6 -> 7
            lastGroup.Events.Count().ShouldBe(2);

            //3 high-fives at 6pm
            lastGroup.Events.First(e => e.EventTypeId == (int)ChatEventTypes.HighFive).HighFiveCount.ShouldBe(3);

            //0 comments at 6pm
            lastGroup.Events.FirstOrDefault(e => e.EventTypeId == (int)ChatEventTypes.Comment).ShouldBe(null);

            //total count
            data.SelectMany(x => x.Events).Count().ShouldBe(6);
        }
    }
}

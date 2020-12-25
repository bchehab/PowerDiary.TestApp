using Microsoft.AspNetCore.Mvc;
using PowerDiary.TestApp.Shared;
using PowerDiary.TestApp.Shared.Chat;
using PowerDiary.TestApp.Shared.Chat.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerDiary.TestApp.Controllers
{
    [ApiController]
    public class ChatArchiveController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatArchiveController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("/chatarchive/daily")]
        public async Task<DailyChatOutputDto> GetDailyChat(DailyChatInputDto dto)
        {
            return await _chatService.GetDailyChat(dto);
        }

        [HttpGet("/chatarchive/summary/hourly")]
        public ChatSummaryDto[] GetHourlySummary()
        {
            return _chatService.GetHourlyChatSummary();
        }
    }
}

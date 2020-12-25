using Microsoft.AspNetCore.Mvc;
using PowerDiary.TestApp.Shared.ChatEventType;
using PowerDiary.TestApp.Shared.ChatEventType.Dto;
using System.Threading.Tasks;

namespace PowerDiary.TestApp.Controllers
{
    [ApiController]
    public class ChatEventTypesController : ControllerBase
    {
        private readonly IChatEventTypesService _chatEventTypesService;

        public ChatEventTypesController(IChatEventTypesService chatEventTypesService)
        {
            _chatEventTypesService = chatEventTypesService;
        }

        [HttpGet("/chateventtypes")]
        public async Task<ChatEventTypeDto[]> GetAll()
        {
            return await _chatEventTypesService.GetAll();
        }
    }
}

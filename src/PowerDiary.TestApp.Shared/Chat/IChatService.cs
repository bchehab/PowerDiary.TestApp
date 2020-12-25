using PowerDiary.TestApp.Shared.Chat.Dto;
using System.Threading.Tasks;

namespace PowerDiary.TestApp.Shared.Chat
{
    public interface IChatService
    {
        Task<DailyChatOutputDto> GetDailyChat(DailyChatInputDto dto);
        ChatSummaryDto[] GetHourlyChatSummary();
    }
}

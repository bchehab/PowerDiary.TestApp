using PowerDiary.TestApp.Shared.ChatEventType.Dto;
using System.Threading.Tasks;

namespace PowerDiary.TestApp.Shared.ChatEventType
{
    public interface IChatEventTypesService
    {
        Task<ChatEventTypeDto[]> GetAll();
    }
}

using System.Collections.Generic;

namespace PowerDiary.TestApp.Shared.Chat.Dto
{
    public class DailyChatOutputDto
    {
        public List<ChatDto> ChatMessages { get; set; }
        public int TotalCount { get; set; }
    }
}

namespace PowerDiary.TestApp.Shared.Chat.Dto
{
    public class ChatSummaryDto
    {
        public string Time { get; set; }

        public HourlyEventDto[] Events { get; set; }
    }
}

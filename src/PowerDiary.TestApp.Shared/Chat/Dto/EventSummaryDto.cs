namespace PowerDiary.TestApp.Shared.Chat.Dto
{
    public class EventSummaryDto
    {
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string TimeDisplay { get; set; }
        public int EventCount { get; set; }
        public int HighFiveCount { get; set; }
    }
}

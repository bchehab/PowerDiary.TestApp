using System.Text.Json.Serialization;

namespace PowerDiary.TestApp.Shared.Chat.Dto
{
    public class HourlyEventDto
    {
        [JsonIgnore]
        public int EventTypeId { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public int Time { get; set; }
        [JsonIgnore]
        public int EventCount { get; set; }
        [JsonIgnore]
        public int HighFiveCount { get; set; }
        public string EventDisplay { get; set; }
    }
}
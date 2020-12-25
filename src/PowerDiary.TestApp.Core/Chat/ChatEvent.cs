using System;

namespace PowerDiary.TestApp.Core
{
    public class ChatEvent : BaseEntity<int>
    {
        /// <summary>
        /// message poster, or user who triggerred the event
        /// </summary>
        public int User1Id { get; set; }
        public virtual User User1 { get; set; }

        /// <summary>
        /// high-fived user
        /// </summary>
        public int? User2Id { get; set; }
        public virtual User User2 { get; set; }

        public int ChatEventTypeId { get; set; }

        public virtual ChatEventType ChatEventType { get; set; }

        public string Message { get; set; }
    }
}

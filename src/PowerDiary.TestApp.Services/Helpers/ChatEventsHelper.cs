using Humanizer;
using PowerDiary.TestApp.Core;
using System;

namespace PowerDiary.TestApp.Services.Helpers
{
    public class ChatEventsHelper
    {
        internal static string SummarizeChatEvents(int chatEventTypeId, int eventCount, int highFiveCount)
        {
            switch (chatEventTypeId)
            {
                case (int)ChatEventTypes.Comment:
                    return $"{QuantifyWord("comment", eventCount)}";

                case (int)ChatEventTypes.EnterRoom:
                    return $"{QuantifyWord("person", eventCount)} entered";

                case (int)ChatEventTypes.LeaveRoom:
                    return $"{eventCount} left";

                case (int)ChatEventTypes.HighFive:
                    return $"{QuantifyWord("person", eventCount)} high-fived {QuantifyWord("other person", highFiveCount)}";

                default:
                    return string.Empty;
            }
        }
        private static string QuantifyWord(string word, int count)
        {
            return word.ToQuantity(count);
        }

        internal static string ParseChatEvent(int chatEventTypeId, string message, string user1, string user2)
        {
            switch (chatEventTypeId)
            {
                case (int)ChatEventTypes.Comment:
                    return $"{user1} comments: \"{message}\"";

                case (int)ChatEventTypes.EnterRoom:
                    return $"{user1} enters the room";

                case (int)ChatEventTypes.LeaveRoom:
                    return $"{user1} leaves";

                case (int)ChatEventTypes.HighFive:
                    return $"{user1} high-fived {user2}";

                default:
                    return string.Empty;
            }
        }
    }
}

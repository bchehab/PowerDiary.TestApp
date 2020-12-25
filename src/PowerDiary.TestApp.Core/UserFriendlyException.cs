using System;

namespace PowerDiary.TestApp.Core
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException() : base()
        {
        }

        public UserFriendlyException(string message) : base(message)
        {
        }

        public UserFriendlyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

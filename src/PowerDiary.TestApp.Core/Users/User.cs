using System;

namespace PowerDiary.TestApp.Core
{
    public class User: BaseEntity<int>
    {
        public string Username { get; set; }
    }
}

using System;

namespace PowerDiary.TestApp.Core
{
    public class BaseEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
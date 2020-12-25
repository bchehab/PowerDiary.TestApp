using Microsoft.EntityFrameworkCore;
using PowerDiary.TestApp.Core;
using System;

namespace PowerDiary.TestApp.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Bob", CreatedDate = Clock.Now, IsActive = true },
                new User { Id = 2, Username = "Kate", CreatedDate = Clock.Now, IsActive = true },
                new User { Id = 3, Username = "Alice", CreatedDate = Clock.Now, IsActive = true },
                new User { Id = 4, Username = "John", CreatedDate = Clock.Now, IsActive = true }
            );

            modelBuilder.Entity<ChatEventType>().HasData(
                new ChatEventType
                {
                    Id = 1,
                    Name = "enter-the-room",
                    Description = "Enter the room"
                }, new ChatEventType
                {
                    Id = 2,
                    Name = "leave-the-room",
                    Description = "Leave the room"
                }, new ChatEventType
                {
                    Id = 3,
                    Name = "comment",
                    Description = "Comment"
                }, new ChatEventType
                {
                    Id = 4,
                    Name = "high-five-another-user",
                    Description = "High-five another user"
                }
            );

            modelBuilder.Entity<ChatEvent>().HasIndex(c => c.CreatedDate);
            modelBuilder.Entity<ChatEvent>().HasIndex(c => c.Message);

            modelBuilder.Entity<ChatEvent>(e =>
            {
                e.HasIndex(c => c.CreatedDate);
                e.HasData(
                    new ChatEvent { Id = 1, ChatEventTypeId = (int)ChatEventTypes.EnterRoom, CreatedDate = Clock.GetTimeDate(17, 0), IsActive = true, User1Id = 1 },
                    new ChatEvent { Id = 2, ChatEventTypeId = (int)ChatEventTypes.EnterRoom, CreatedDate = Clock.GetTimeDate(17, 5), IsActive = true, User1Id = 2 },
                    new ChatEvent { Id = 3, ChatEventTypeId = (int)ChatEventTypes.Comment, CreatedDate = Clock.GetTimeDate(17, 15), IsActive = true, User1Id = 1, Message = "Hey, Kate - high five?" },
                    new ChatEvent { Id = 4, ChatEventTypeId = (int)ChatEventTypes.HighFive, CreatedDate = Clock.GetTimeDate(17, 17), IsActive = true, User1Id = 2, User2Id = 1 },
                    new ChatEvent { Id = 5, ChatEventTypeId = (int)ChatEventTypes.LeaveRoom, CreatedDate = Clock.GetTimeDate(17, 18), IsActive = true, User1Id = 1 },
                    new ChatEvent { Id = 6, ChatEventTypeId = (int)ChatEventTypes.Comment, CreatedDate = Clock.GetTimeDate(17, 20), IsActive = true, User1Id = 2, Message = "Oh, typical" },
                    new ChatEvent { Id = 7, ChatEventTypeId = (int)ChatEventTypes.LeaveRoom, CreatedDate = Clock.GetTimeDate(17, 21), IsActive = true, User1Id = 2 },
                    new ChatEvent { Id = 8, ChatEventTypeId = (int)ChatEventTypes.EnterRoom, CreatedDate = Clock.GetTimeDate(18, 0), IsActive = true, User1Id = 2 },
                    new ChatEvent { Id = 9, ChatEventTypeId = (int)ChatEventTypes.EnterRoom, CreatedDate = Clock.GetTimeDate(18, 5), IsActive = true, User1Id = 3 },
                    new ChatEvent { Id = 10, ChatEventTypeId = (int)ChatEventTypes.EnterRoom, CreatedDate = Clock.GetTimeDate(18, 10), IsActive = true, User1Id = 4 },
                    new ChatEvent { Id = 11, ChatEventTypeId = (int)ChatEventTypes.HighFive, CreatedDate = Clock.GetTimeDate(18, 15), IsActive = true, User1Id = 1, User2Id = 2 },
                    new ChatEvent { Id = 12, ChatEventTypeId = (int)ChatEventTypes.HighFive, CreatedDate = Clock.GetTimeDate(18, 20), IsActive = true, User1Id = 2, User2Id = 3 },
                    new ChatEvent { Id = 13, ChatEventTypeId = (int)ChatEventTypes.HighFive, CreatedDate = Clock.GetTimeDate(18, 25), IsActive = true, User1Id = 3, User2Id = 4 },
                    new ChatEvent { Id = 14, ChatEventTypeId = (int)ChatEventTypes.HighFive, CreatedDate = Clock.GetTimeDate(18, 24), IsActive = false, User1Id = 3, User2Id = 1 }
                );
            });
        }
    }
}

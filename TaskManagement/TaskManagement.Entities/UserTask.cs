using System;

namespace TaskManagement.Entities
{
   public class UserTask
    {
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using TaskManagement.Entities.Common;

namespace TaskManagement.Entities
{
    public class Task : BaseEntity
    {
        public string TaskName { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
        public DateTime? NextActionDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int TypeTaskId { get; set; }
        public TypeTask Type { get; set; }
        public int StatusTaskId { get; set; } = (int)TaskStatuses.Open;
        public StatusTask Status { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}

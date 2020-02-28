using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentContent { get; set; }
        public DateTime? ReminderDate { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
    }
}

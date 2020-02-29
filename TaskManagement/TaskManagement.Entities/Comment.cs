using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManagement.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        public DateTime? ReminderDate { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int TypeCommentId { get; set; }
        public TypeComment Type { get; set; }
    }
}

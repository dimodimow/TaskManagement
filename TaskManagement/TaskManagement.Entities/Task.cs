using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Entities
{
    public class Task : BaseEntity
    {
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
        public DateTime? NextActionDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int TypeTaskId { get; set; }
        public TypeTask Type { get; set; }
        public int StatusTaskId { get; set; }
        public StatusTask Status { get; set; }

    }
}

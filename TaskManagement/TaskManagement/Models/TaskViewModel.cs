
using System;
using System.Collections.Generic;
using TaskManagement.Entities;

namespace TaskManagement.Web.Models
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime DueTime { get; set; }  
        public List<User> AllUsers { get; set; }
        public List<User> SelectedUsers { get; set; } 
        public int TypeTaskId { get; set; }
        public int StatusTaskId { get; set; }
        public DateTime? NextActionDate { get; set; }
    }
}

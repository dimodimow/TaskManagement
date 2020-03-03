
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Entities;

namespace TaskManagement.Web.Models
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string TaskName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Required by date")]
        public DateTime? DueTime { get; set; }  
        public List<UserProxyViewModel> AllUsers { get; set; }
        public int TypeTask { get; set; }
        public int StatusTask { get; set; }
        public DateTime? NextActionDate { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Entities;

namespace TaskManagement.Web.Models
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Name")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        [Display(Name = "Required by date")]
        public DateTime? DueTime { get; set; }  
        public List<UserProxyViewModel> AllUsers { get; set; }
        [Display(Name = "Type")]
        public int TypeTask { get; set; }
        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int StatusTask { get; set; }
        public DateTime? NextActionDate { get; set; }
        [Display(Name = "Created")]
        public DateTime? CreatedOn { get; set; }
    }
}

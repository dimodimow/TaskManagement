using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TaskManagement.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserTask> UserTasks { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

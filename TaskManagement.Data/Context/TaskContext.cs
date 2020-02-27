using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities;

namespace TaskManagement.Data.Context
{
    public class TaskContext : IdentityDbContext<User>
    {
        public TaskContext()
        {

        }
        public TaskContext(DbContextOptions<TaskContext> options)
        : base(options) { }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities;

namespace TaskManagement.Data.Context
{
    public class TaskContext : IdentityDbContext<User>
    {
        public TaskContext() {}

        public TaskContext(DbContextOptions<TaskContext> options)
        : base(options) { }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Many-To-Many Relationship UserTasks
            modelBuilder.Entity<UserTask>()
                .HasKey(userTask => new { userTask.UserId, userTask.TaskId });
            modelBuilder.Entity<UserTask>()
                .HasOne(userTask => userTask.Task)
                .WithMany(user => user.UserTasks)
                .HasForeignKey(userTask => userTask.TaskId);
            modelBuilder.Entity<UserTask>()
             .HasOne(userTask => userTask.User)
             .WithMany(task => task.UserTasks)
             .HasForeignKey(userTask => userTask.UserId);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

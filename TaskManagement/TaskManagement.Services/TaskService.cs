using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Data.Context;
using TaskManagement.Entities;
using TaskManagement.Services.Contracts;

namespace TaskManagement.Services
{
   public class TaskService : ITaskService
    {
        private readonly TaskContext context;
        public TaskService(TaskContext context)
        {
            this.context = context;
        }
        
        public async Task<Entities.Task> CreateTask(string taskName,string description,string userId, DateTime dueDate, int typeTask, ICollection<User> selectedUsers, DateTime? nextActionDate = null)
        {

            Guid taskId = Guid.NewGuid();

            var task = new Entities.Task
            {
                Id = taskId,
                TaskName = taskName,
                UserId = Guid.Parse(userId),
                Description = description,
                TypeTaskId = typeTask,
                DueDate = dueDate,
                CreatedOn = DateTime.Now,
            }; 
            foreach(var selectedUser in selectedUsers)
            {
                var userTask = new UserTask
                {
                    User = selectedUser,
                    Task = task
                };
                await this.context.AddAsync(userTask);
            }

            await this.context.Tasks.AddAsync(task);
            await this.context.SaveChangesAsync();
            
            return task;
        }

        public async Task<List<Entities.Task>> GetAllAsync()
        {
            var query = await this.context.Tasks.Include(x => x.Comments).ToListAsync();

            return query;
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            var task = await this.context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

            if (task == null)
            {
                return false;
            }

            this.context.Tasks.Remove(task);
            await this.context.SaveChangesAsync();
            return true;
        }
    }
}

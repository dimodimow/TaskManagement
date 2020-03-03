using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Data.Context;
using TaskManagement.Entities;
using TaskManagement.Services.Contracts;
using TaskManagement.Services.Util;
using TaskManagement.Web.Models;

namespace TaskManagement.Services
{
   public class TaskService : ITaskService
    {
        private readonly TaskContext context;
        public TaskService(TaskContext context)
        {
            this.context = context;
        }
        
        public async Task<Entities.Task> CreateTask(string taskName,string description,string userId, DateTime? dueDate, int typeTask, ICollection<UserProxyViewModel> selectedUsers, DateTime? nextActionDate = null)
        {
            ValidationTask.ValidateTaskNameIfIsNull(taskName);
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
                if(selectedUser.IsChecked)
                {
                    var userTask = new UserTask
                    {
                        UserId = selectedUser.UserId,
                        Task = task
                    };
                    await this.context.AddAsync(userTask);
                }
            }

            await this.context.Tasks.AddAsync(task);
            await this.context.SaveChangesAsync();
            
            return task;
        }
        public async Task<Entities.Task> EditTask(Guid taskId, string taskName, string description, DateTime? dueDate, int statusTaskId ,ICollection<UserProxyViewModel> selectedUsers)
        {
            var task = await this.context.Tasks.SingleOrDefaultAsync(a => a.Id.Equals(taskId));

            ValidationTask.ValidateTaskNameIfIsNull(taskName);

            if (await this.context.Tasks.AnyAsync(n => n.TaskName.Equals(taskName.ToLower()) && n.Id != taskId))
            {
                throw new ArgumentException($"Task with Name: {taskName} already exists!");
            }

            task.StatusTaskId = statusTaskId;
            task.TaskName = taskName;
            task.Description = description;
            task.DueDate = dueDate;

            //foreach (var selectedUser in selectedUsers)
            //{
            //    if (selectedUser.IsChecked)
            //    {
            //        var userTask = new UserTask
            //        {
            //            UserId = selectedUser.UserId.ToString(),
            //            Task = task
            //        };
            //        await this.context.AddAsync(userTask);
            //    }
            //}

            this.context.Tasks.Update(task);
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

        public async Task<Entities.Task> FindTaskById(Guid id)
        {
            var task = await this.context.Tasks.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);

            return task;
        }
    }
}

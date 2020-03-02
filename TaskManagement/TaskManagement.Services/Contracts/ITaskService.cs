using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Entities;

namespace TaskManagement.Services.Contracts
{
   public interface ITaskService
    {
        Task<Entities.Task> CreateTask(string taskName, string description, string userId,  DateTime dueDate, int typeTask, ICollection<User> selectedUsers, DateTime? nextActionDate = null);
        Task<List<Entities.Task>> GetAllAsync();
        Task<bool> DeleteTask(Guid taskId);
    }
}

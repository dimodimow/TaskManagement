using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Entities;
using TaskManagement.Web.Models;

namespace TaskManagement.Services.Contracts
{
   public interface ITaskService
    {
        Task<Entities.Task> CreateTask(string taskName, string description, string userId,  DateTime? dueDate, int typeTask, ICollection<UserProxyViewModel> selectedUsers, DateTime? nextActionDate = null);
        Task<List<Entities.Task>> GetAllAsync();
        Task<bool> DeleteTask(Guid taskId);
        public Task<Entities.Task> FindTaskById(Guid id);
        Task<Entities.Task> EditTask(Guid taskId, string taskName, string description, DateTime? dueDate, int statusTaskId, ICollection<UserProxyViewModel> selectedUsers);
    }
}

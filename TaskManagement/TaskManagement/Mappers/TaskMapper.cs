using System.Collections.Generic;
using TaskManagement.Entities;
using TaskManagement.Web.Mappers.Contracts;
using TaskManagement.Web.Models;

namespace TaskManagement.Web.Mappers
{
    public class TaskMapper : IMapper<TaskViewModel, Entities.Task>
    {
        public TaskViewModel Map(Entities.Task entity)
        {
            return new TaskViewModel
            {
                TaskName = entity.TaskName,
                Description = entity.Description,
                DueTime = entity.DueDate,
                StatusTaskId = entity.StatusTaskId,
                TypeTaskId = entity.TypeTaskId,
                NextActionDate = entity.NextActionDate,
                AllUsers = new List<User>(),
                SelectedUsers = new List<User>()
            };
        }
    }
}

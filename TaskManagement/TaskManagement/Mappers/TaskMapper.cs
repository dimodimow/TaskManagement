using System.Collections.Generic;
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
                Id = entity.Id,
                TaskName = entity.TaskName,
                Description = entity.Description,
                DueTime = entity.DueDate,
                StatusTask = entity.StatusTaskId,
                TypeTask = entity.TypeTaskId,
                NextActionDate = entity.NextActionDate,
                CreatedOn = entity.CreatedOn,
                AllUsers = new List<UserProxyViewModel>()
            };
        }
    }
}

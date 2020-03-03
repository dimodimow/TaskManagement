using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data.Context;
using TaskManagement.Entities;
using TaskManagement.Web.Models;

namespace TaskManagement.Services
{
    public class UserService : IUserService
    {
        private readonly TaskContext context;
        public UserService(TaskContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns all Users
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserProxyViewModel>> GetAllUsersAsync()
        {

            return await this.context.Users.Select(x => new UserProxyViewModel { UserId = x.Id, UserName = x.UserName}).ToListAsync();
        }

        /// <summary>
        /// returns all Users and the selected ones for the task
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserProxyViewModel>> GetAllUsersForTaskAsync(Guid taskId)
        {

            return await this.context.Users.Include(x => x.UserTasks)
                .Select(x => new UserProxyViewModel { UserId = x.Id, UserName = x.UserName, IsChecked = x.UserTasks.Any(y=> y.TaskId == taskId && y.UserId == x.Id)}).ToListAsync();
        }

        /// <summary>
        /// Returns all selected users for this task
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserProxyViewModel>> GetSelectedUsersAsync(Guid taskId)
        {
            return await this.context.UserTasks.Include(x => x.User).Where(x=> x.TaskId == taskId).Select(x => new UserProxyViewModel { UserId = x.User.Id, IsChecked = true, UserName = x.User.UserName }).ToListAsync();
        }

    }
}

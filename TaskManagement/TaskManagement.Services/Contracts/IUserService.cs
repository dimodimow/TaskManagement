using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Web.Models;

namespace TaskManagement.Services
{
    public interface IUserService
    {
        Task<List<UserProxyViewModel>> GetAllUsersAsync();
        Task<List<UserProxyViewModel>> GetSelectedUsersAsync();
        Task<List<UserProxyViewModel>> GetAllUsersForTaskAsync(Guid taskid);
    }
}
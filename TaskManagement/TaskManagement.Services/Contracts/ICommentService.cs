using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Entities;

namespace TaskManagement.Services.Contracts
{
    public interface ICommentService
    {
        Task<Comment> CreateComment(string text, string userId, DateTime? reminderDate);
        Task<List<Comment>> GetAllComments(Guid taskId);
    }
}

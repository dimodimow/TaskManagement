using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Entities;

namespace TaskManagement.Services.Contracts
{
    public interface ICommentService
    {
        Task<Comment> CreateComment(string text, string userId, Guid taskId, DateTime? reminderDate, int typeCommentId);
        Task<List<Comment>> SearchAllComments(int taskId, string text);
        Task<List<Comment>> GetAllComments(Guid taskId);
        Task<Comment> FindCommentById(Guid id);
        Task<Comment> EditComment(Guid commentId, string text, string userId, int commentTypeId, DateTime? reminderDate);
        Task<bool> DeleteComment(Guid commentId);
    }
}

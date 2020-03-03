using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data.Context;
using TaskManagement.Entities;
using TaskManagement.Services.Contracts;
using TaskManagement.Services.Util;

namespace TaskManagement.Services
{
   public class CommentService : ICommentService
    {
        private readonly TaskContext context;
        private readonly ITaskService taskService;
        public CommentService(TaskContext context, ITaskService taskService)
        {
            this.context = context;
            this.taskService = taskService;
        }
        public async Task<Comment> CreateComment(string text, string userId,Guid taskId, DateTime? reminderDate, int typeCommentId)
        {
            ValidationComment.ValidateCommentTextIfIsNullOrEmpty(text);
           Entities.Task findTask = await this.taskService.FindTaskById(taskId);
            var currentUser = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            Guid commentId = Guid.NewGuid();

                var comment = new Comment
                {
                    Id = commentId,
                    Text = text,
                    UserId = userId,
                    Task = findTask,
                    TaskId = taskId,
                    CreatedOn = DateTime.Now,
                    TypeCommentId = typeCommentId,
                    User = currentUser,
                    ReminderDate = reminderDate
                };

            if (reminderDate != null)
            {
                comment.Task.NextActionDate = reminderDate;
            }

            await this.context.Comments.AddAsync(comment);
            await this.context.SaveChangesAsync();

            return comment;
        }
        public async Task<List<Comment>> SearchAllComments(int taskId, string text)
        {
            return await this.context.Comments
                .Include(x => x.Task)
                .Include(x=>x.User)
                .Where(x => x.TypeCommentId == taskId && x.Text.Contains(text?? string.Empty))
                .ToListAsync();
        }
        public async Task<List<Comment>> GetAllComments(Guid taskId)
        {
            return await this.context.Comments
                .Include(x => x.User)
                .Where(x => x.TaskId == taskId)
                .ToListAsync();
        }
        public async Task<bool> DeleteComment(Guid commentId)
        {
            var comment = await this.context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment == null)
            {
                return false;
            }

            this.context.Comments.Remove(comment);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<Comment> FindCommentById(Guid id)
        {
            var comment = await this.context.Comments.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            return comment;
        }

        public async Task<Comment> EditComment(Guid commentId, string text, string userId, int commentTypeId, DateTime? reminderDate)
        {
            ValidationComment.ValidateCommentTextIfIsNullOrEmpty(text);
            var comment = await this.context.Comments.Include(x=>x.Task).FirstOrDefaultAsync(c => c.Id == commentId);

            if (comment == null)
            {
                 throw new ArgumentException("Comment does not exist");
            }

            comment.Text = text;
            comment.TypeCommentId = commentTypeId;
            comment.ModifiedOn = DateTime.Now;
            comment.ReminderDate = reminderDate;
            if(reminderDate != null && comment.ReminderDate != reminderDate)
            {
                comment.Task.NextActionDate = reminderDate;
            }
            this.context.Update(comment);
            await this.context.SaveChangesAsync();
            return comment; 
        }

    }
}

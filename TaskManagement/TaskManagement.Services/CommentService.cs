using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Data.Context;
using TaskManagement.Entities;
using TaskManagement.Services.Contracts;

namespace TaskManagement.Services
{
   public class CommentService : ICommentService
    {
        private readonly TaskContext context;
        public CommentService(TaskContext context)
        {
            this.context = context;
        }
        public async Task<Comment> CreateComment(string text, string userId, DateTime? reminderDate)
        {
            var currentUser = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            Guid commentId = Guid.NewGuid();

                var comment = new Comment
                {
                    Id = commentId,
                    Text = text,
                    UserId = userId,
                    CreatedOn = DateTime.Now,
                    User = currentUser,
                    ReminderDate = reminderDate
                };


            await this.context.Comments.AddAsync(comment);
            await this.context.SaveChangesAsync();

            return comment;
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
            var comment = await this.context.Comments.FirstOrDefaultAsync(comment => comment.Id == commentId);

            if (comment == null)
            {
                return false;
            }

            this.context.Comments.Remove(comment);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<Comment> EditComment(Guid commentId, string text, string userId, DateTime? reminderDate)
        {
            var comment = await this.context.Comments.Include(x=>x.Task).FirstOrDefaultAsync(comment => comment.Id == commentId);
            if (comment == null)
            {
                 throw new ArgumentException("Comment does not exist");
            }


            //da se premesti v controlera predi da idesh na edit ekrana, proverkata tr e predvaritelno
            if (comment.UserId != userId)
            {
                throw new ArgumentException("User can not edit this comment because somebody else. ");
            }

            if(string.IsNullOrWhiteSpace(text))
            {
                throw new NotImplementedException();
            }
            comment.Text = text;
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

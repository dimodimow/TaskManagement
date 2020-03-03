using TaskManagement.Entities;
using TaskManagement.Web.Mappers.Contracts;
using TaskManagement.Web.Models;

namespace TaskManagement.Web.Mappers
{
    public class CommentMapper : IMapper<CommentViewModel, Comment>
    {
        public CommentViewModel Map(Comment entity)
        {
            return new CommentViewModel
            {
                Id = entity.Id,
                Text = entity.Text,
                UserId = entity.UserId,
                TypeCommentId = entity.TypeCommentId,
                ReminderDate = entity.ReminderDate,
                TaskId = entity.TaskId,
                UserName = entity.User.UserName,
                CreatedOn = entity.CreatedOn
            };
        }
    }
}

﻿using System;
using TaskManagement.Entities;

namespace TaskManagement.Web.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public string UserName { get; set; }
        public int TypeCommentId { get; set; }
        public Guid TaskId { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Entities;

namespace TaskManagement.Data.Extentions
{
   public static class SeedCommentType
    {
        public static void CommentType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeComment>().HasData(TypeComment());
        }

        private static TypeComment[] TypeComment()
        {
            return new TypeComment[]
            {
                new TypeComment
                {
                     Id = 1,
                     Type = "Hint"
                },

                new TypeComment
                {
                     Id = 2,
                     Type = "Question"
                },

                new TypeComment
                {
                     Id = 3,
                     Type = "Important"
                },
            };
        }
    }
}

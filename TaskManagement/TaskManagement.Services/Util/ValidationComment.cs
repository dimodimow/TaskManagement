using System;

namespace TaskManagement.Services.Util
{
   public static class ValidationComment
    {
        public static void ValidateCommentTextIfIsNullOrEmpty(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Comment text can not be null!");
            }
        }
    }
}

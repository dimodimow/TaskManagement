using System;

namespace TaskManagement.Services.Util
{
   public static class ValidationTask
    {
        public static void ValidateTaskNameIfIsNull(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Task name can not be null");
            }
        }
    }
}

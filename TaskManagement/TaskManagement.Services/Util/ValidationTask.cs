using System;
using System.Text;

namespace TaskManagement.Services.Util
{
   public static class ValidationTask
    {
        public static void ValidateTaskNameIfIsNull(string name)
        {
            if (name == null)
            {
                throw new ArgumentException("Task name can not be null");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities;

namespace TaskManagement.Data.Extentions
{
   public static class SeedTaskStatus
    {
        public static void TaskStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTask>().HasData(StatusSeed());
        }

        private static StatusTask[] StatusSeed()
        {
            return new StatusTask[]
            {
                new StatusTask
                {
                     Id = 1,
                     Status = "Open"
                },

                new StatusTask
                {
                     Id = 2,
                     Status = "InProgress"
                },

                new StatusTask
                {
                     Id = 3,
                     Status = "Closed"
                },
            };
        }
    }
}

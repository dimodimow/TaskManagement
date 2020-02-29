using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities;

namespace TaskManagement.Data.Extentions
{
    public static class SeedTaskType
    {
        public static void TaskType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeTask>().HasData(TypeSeed());
        }

        private static TypeTask[] TypeSeed()
        {
            return new TypeTask[]
            {
                new TypeTask
                {
                     Id = 1,
                     Type = "Bug"
                },

                new TypeTask
                {
                     Id = 2,
                     Type = "Task"
                },

                new TypeTask
                {
                     Id = 3,
                     Type = "Improvement"
                },

                new TypeTask
                {
                     Id = 4,
                     Type = "Research"
                },
            };
        }
    }
}

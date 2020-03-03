using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities;

namespace TaskManagement.Data.Extentions
{
   public static class SeedRoles
    {
        public static void Roles(this ModelBuilder modelBuilder)
        {
            #region Create roles
            modelBuilder
                .Entity<UserRole>()
                .HasData(new IdentityRole
                {
                    Id = "a5e38752-84ae-4352-a0b6-bf47b3fd460a",
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                });

            modelBuilder
              .Entity<UserRole>()
              .HasData(new IdentityRole
              {
                  Id = "d90e75c6-7da9-490e-aeb0-3d8c4827e193",
                  Name = "Employee",
                  NormalizedName = "EMPLOYEE"
              });
            #endregion

            #region Create Users
            var hasher = new PasswordHasher<User>();

            var adminDimo = new User
            {
                Id = "69e7930c-3df5-4261-99cf-0352eb018a91",
                UserName = "dimo@manager.com",
                NormalizedUserName = "DIMO@MANAGER.COM",
                Email = "dimo@manager.com",
                NormalizedEmail = "DIMO@MANAGER.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                LockoutEnabled = true
            };

            var employeeGosho = new User
            {
                Id = "9009a034-7f66-455f-b76f-4f873dc93741",
                UserName = "gosho@employee.com",
                NormalizedUserName = "GOSHO@EMPLOYEE.COM",
                Email = "gosho@employee.com",
                NormalizedEmail = "GOSHO@EMPLOYEE.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNUUV5PVYBHGXN",
                LockoutEnabled = true
            };

            var employeePesho = new User
            {
                Id = "4a55904b-910e-46c3-8df7-a138a2b73a8a",
                UserName = "pesho@employee.com",
                NormalizedUserName = "PESHO@EMPLOYEE.COM",
                Email = "pesho@employee.com",
                NormalizedEmail = "PESHO@EMPLOYEE.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNULV5PVYBHGXN",
                LockoutEnabled = true
            };
            #endregion

            #region Set passwords of users
            adminDimo.PasswordHash = hasher
                .HashPassword(adminDimo, "12345");

            employeeGosho.PasswordHash = hasher
                .HashPassword(employeeGosho, "12345");

            employeePesho.PasswordHash = hasher
                .HashPassword(employeePesho, "12345");
            #endregion

            #region Set user to role
            modelBuilder.Entity<User>()
                .HasData(adminDimo); 
            modelBuilder.Entity<User>()
                .HasData(employeeGosho);
            modelBuilder.Entity<User>()
               .HasData(employeePesho);


            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                { UserId = adminDimo.Id, RoleId = "a5e38752-84ae-4352-a0b6-bf47b3fd460a" });

            modelBuilder
               .Entity<IdentityUserRole<string>>()
               .HasData(new IdentityUserRole<string>
               { UserId = employeeGosho.Id, RoleId = "d90e75c6-7da9-490e-aeb0-3d8c4827e193" });

            modelBuilder
               .Entity<IdentityUserRole<string>>()
               .HasData(new IdentityUserRole<string>
               { UserId = employeePesho.Id, RoleId = "d90e75c6-7da9-490e-aeb0-3d8c4827e193" });
            #endregion
        }
    }
}

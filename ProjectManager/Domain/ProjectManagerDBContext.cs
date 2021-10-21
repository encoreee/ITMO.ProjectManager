using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectManager.Service;

#nullable disable

namespace ProjectManager
{
    public class ProjectManagerDBContext : IdentityDbContext<IdentityUser>
    {
        public ProjectManagerDBContext()
        {
        }

        public ProjectManagerDBContext(DbContextOptions<ProjectManagerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<ColumnTask> ColumnTasks { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectColumn> ProjectColumns { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Task>()
            //.HasOne(i => i.Chat)
            //.WithOne(c => c.Ta)
            //.OnDelete(DeleteBehavior.Cascade);
            

            //Заполнение БД юзерами и ролямиt

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                Name = "user",
                NormalizedName = "USER"
            });


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB",
                UserName = "User1",
                NormalizedUserName = "USER1",
                Email = "user1@email.com",
                NormalizedEmail = "USER1@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "User1"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "401CD605-BAEF-45CF-8BB5-FA69DA80DC63",
                UserId = "13D24B5A-E7C9-42B0-BCD2-DF0956FEB2FB"
            });

        }
    }
}
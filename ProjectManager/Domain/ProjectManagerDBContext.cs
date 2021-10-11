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

        public virtual DbSet<AcsessLevel> AcsessLevels { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<ColumnTasks> ColumnTasks { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectColumns> ProjectColumns { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        //Заполнение БД юзерами и ролями

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

            //заполнение проектов

            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = new Guid("EC12B7D7-7DCD-4E42-9A52-A4986CB3E1D7"),
                Name = "Project1",
                Description = "this is very log description about project1"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = new Guid("A90787D4-C1B6-47F6-85EA-9CBDB9BE883A"),
                Name = "Project2",
                Description = "this is very log description about project2"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = new Guid("E56BB6AF-B4D8-4016-BBAD-E90A21600C65"),
                Name = "Project3",
                Description = "this is very log description about project3"
            });

            modelBuilder.Entity<Column>().HasData(new Column
            {
                Id = new Guid("A22DC7DA-1311-4479-9764-93507257F813"),
                Name = "Column1",
            });
            modelBuilder.Entity<Column>().HasData(new Column
            {
                Id = new Guid("6F338C6A-2979-472D-B6BE-9B984EF4D4D7"),
                Name = "Column2",
            });
            modelBuilder.Entity<Column>().HasData(new Column
            {
                Id = new Guid("E9A0C114-1143-4EC6-9C6D-D08736116BAC"),
                Name = "Column3",
            });

            modelBuilder.Entity<ProjectColumns>().HasData(new ProjectColumns
            {
                Id = new Guid("F3F52CC7-0E87-48AB-9685-B1CAB744BFB5"),
                Projectid = new Guid("EC12B7D7-7DCD-4E42-9A52-A4986CB3E1D7"),
                Columnid = new Guid("A22DC7DA-1311-4479-9764-93507257F813")
            });

            modelBuilder.Entity<ProjectColumns>().HasData(new ProjectColumns
            {
                Id = new Guid("1184FAC6-8886-47C6-930D-2078D7844135"),
                Projectid = new Guid("EC12B7D7-7DCD-4E42-9A52-A4986CB3E1D7"),
                Columnid = new Guid("6F338C6A-2979-472D-B6BE-9B984EF4D4D7")
            });

            modelBuilder.Entity<ProjectColumns>().HasData(new ProjectColumns
            {
                Id = new Guid("6B6AC990-742B-470E-BC5D-E982D9A0C31E"),
                Projectid = new Guid("EC12B7D7-7DCD-4E42-9A52-A4986CB3E1D7"),
                Columnid = new Guid("E9A0C114-1143-4EC6-9C6D-D08736116BAC")
            });

            modelBuilder.Entity<Task>().HasData(new Task
            {
                Id = new Guid("55A0A852-657B-4A0E-9CF1-E923F2B11FE7"),
                Name = "Task1",
                Description = "Description1",
                Columnid = new Guid("A22DC7DA-1311-4479-9764-93507257F813")
            });

            modelBuilder.Entity<Task>().HasData(new Task
            {
                Id = new Guid("AD3972B5-3789-4A10-AA86-950B539DC40A"),
                Name = "Task2",
                Description = "Description2",
                Columnid = new Guid("A22DC7DA-1311-4479-9764-93507257F813")

            }) ;
        }
    }
}
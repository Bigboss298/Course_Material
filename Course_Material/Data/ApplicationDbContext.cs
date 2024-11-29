using Course_Material.Model.Entities;
using Course_Material.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace Course_Material.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> database) : DbContext(database)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Materials> Materials { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = "001",
                    FirstName = "Big",
                    LastName = "Boss",
                    Email = "bigboss@gmail.com",
                    Username = "Bigboss",
                    Password = "passer",
                    Gender = (Gender)1,
                    Role = Role.Admin,
                    ProfilePicture = "bigboss.jpg",
                }
         );
    }
    }
    }

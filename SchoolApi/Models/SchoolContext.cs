using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Models
{
    public class SchoolContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
using System.Threading.Tasks;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly SchoolContext context;

        public StudentCourseRepository(SchoolContext context)
        {
            this.context = context;
        }
        public async Task RegisterStudentCourse(int studentId, int courseId)
        {
            await context.StudentCourses.AddAsync(new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId,
            });
            await context.SaveChangesAsync();
        }
    }
}
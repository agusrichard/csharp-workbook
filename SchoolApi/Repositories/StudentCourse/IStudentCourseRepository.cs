using System.Threading.Tasks;

namespace SchoolApi.Repositories
{
    public interface IStudentCourseRepository
    {
        Task RegisterStudentCourse(int studentId, int courseId);
    }
}
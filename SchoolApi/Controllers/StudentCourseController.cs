using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("student-course")]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseRepository repository;

        public StudentCourseController(IStudentCourseRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterStudentCourse(StudentCourse sc)
        {
            await repository.RegisterStudentCourse(sc.StudentId, sc.CourseId);
            return NoContent();
        }
    }
}
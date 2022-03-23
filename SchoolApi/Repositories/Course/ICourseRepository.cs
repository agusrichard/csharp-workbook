using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> Get();
        Task<Course> GetById(int id);
        Task Create(Course course);
        Task Update(Course course);
        Task Delete(int id);
    }
}
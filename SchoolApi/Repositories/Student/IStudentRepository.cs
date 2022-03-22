using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Get();
        Task<Student> GetById(int id);
        Task Create(Student student);
        Task Update(Student student);
        Task Delete(int id);
    }
}
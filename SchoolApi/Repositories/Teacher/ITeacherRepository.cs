using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> Get();
        Task<Teacher> GetById(int id);
        Task Create(Teacher teacher);
        Task Update(Teacher teacher);
        Task Delete(int id);
    }
}
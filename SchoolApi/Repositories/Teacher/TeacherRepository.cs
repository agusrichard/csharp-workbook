using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext context;

        public TeacherRepository(SchoolContext context)
        {
            this.context = context;
        }

        public async Task Create(Teacher teacher)
        {
            await context.Teachers.AddAsync(teacher);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await GetById(id);
            context.Teachers.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> Get()
        {
            return await context.Teachers.Select(t => new Teacher
            {
                Courses = context.Courses.Where(c => c.TeacherId == t.Id).ToList(),
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            var result = await context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No teacher with id {id} found");
            }
            result.Courses = await context.Courses.Where(c => c.TeacherId == result.Id).ToListAsync();

            return result;
        }

        public async Task Update(Teacher teacher)
        {
            var result = await GetById(teacher.Id);
            result.Name = teacher.Name;
            await context.SaveChangesAsync();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext context;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }

        public async Task Create(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No student with id {id} found");
            }

            context.Students.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            var result = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No student with id {id} found");
            }

            return result;
        }

        public async Task Update(Student student)
        {
            var result = await GetById(student.Id);
            result.Name = student.Name;
            await context.SaveChangesAsync();
        }
    }
}
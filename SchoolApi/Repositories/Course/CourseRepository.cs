using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext context;

        public CourseRepository(SchoolContext context)
        {
            this.context = context;
        }

        public async Task Create(Course course)
        {
            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await GetById(id);
            context.Courses.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> Get()
        {
            return await context.Courses.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            var result = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No student with id {id} found");
            }

            return result;
        }

        public async Task Update(Course course)
        {
            var result = await GetById(course.Id);
            result.Name = course.Name;
            result.Description = course.Description;
            await context.SaveChangesAsync();
        }
    }
}
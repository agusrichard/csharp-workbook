using System.Collections.Generic;
using System.Linq;
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
            var result = await GetById(id);
            var resultAddress = await context.Addresses.FirstOrDefaultAsync(a => a.Id == result.AddressId);
            context.Students.Remove(result);
            context.Addresses.Remove(resultAddress);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> Get()
        {
            var students = await context.Students.ToListAsync();
            for (var i = 0; i < students.Count; i++)
            {
                var studentCourses = context.StudentCourses
                    .Where(sc => sc.StudentId == students[i].Id)
                    .Select(sc => new StudentCourse
                    {
                        CourseId = sc.CourseId,
                        StudentId = sc.StudentId,
                        Course = context.Courses.FirstOrDefault(csc => csc.Id == sc.CourseId)
                    })
                    .ToList();
                students[i].Address = context.Addresses.FirstOrDefault(a => a.Id == students[i].AddressId);
                students[i].Courses = studentCourses.Select(sc => sc.Course).ToList();
            }

            return await Task.FromResult<IEnumerable<Student>>(students);
        }

        public async Task<Student> GetById(int id)
        {
            var result = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No student with id {id} found");
            }
            var studentCourses = context.StudentCourses
                   .Where(sc => sc.StudentId == result.Id)
                   .Select(sc => new StudentCourse
                   {
                       CourseId = sc.CourseId,
                       StudentId = sc.StudentId,
                       Course = context.Courses.FirstOrDefault(csc => csc.Id == sc.CourseId)
                   })
                   .ToList();

            var address = await context.Addresses.FirstOrDefaultAsync(a => a.Id == result.AddressId);
            result.Address = address;
            result.Courses = studentCourses.Select(sc => sc.Course).ToList();

            return result;
        }

        public async Task Update(Student student)
        {
            var result = await GetById(student.Id);
            result.Name = student.Name;
            result.BirthDate = student.BirthDate;
            result.Address.Detail = student.Address.Detail;
            result.Address.City = student.Address.City;
            result.Address.State = student.Address.State;
            result.Address.Country = student.Address.Country;
            await context.SaveChangesAsync();
        }
    }
}
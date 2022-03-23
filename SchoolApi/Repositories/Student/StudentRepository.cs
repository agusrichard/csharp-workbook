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
            return await context.Students.Select(s => new Student
            {
                Address = context.Addresses.FirstOrDefault(a => a.Id == s.AddressId),
                Id = s.Id,
                Name = s.Name,
                AddressId = s.AddressId,
                BirthDate = s.BirthDate,
            }).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            var result = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                throw new KeyNotFoundException($"No student with id {id} found");
            }

            var address = await context.Addresses.FirstOrDefaultAsync(a => a.Id == result.AddressId);
            result.Address = address;

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
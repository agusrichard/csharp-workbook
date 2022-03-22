using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository repository;
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            try
            {
                return await repository.GetById(id);
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            await repository.Create(student);

            return CreatedAtAction(nameof(GetById), new { Id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Student student)
        {
            try
            {
                student.Id = id;
                await repository.Update(student);
                return NoContent();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await repository.Delete(id);
                return NoContent();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
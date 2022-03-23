using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository repository;

        public TeacherController(ITeacherRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> Get()
        {
            return await repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetById(int id)
        {
            try
            {
                return await repository.GetById(id);
            }
            catch (KeyNotFoundException)
            {

                return NotFound();
            }
            catch (System.Exception)
            {

                return Problem();
            }
        }


        [HttpPost]
        public async Task<ActionResult<Teacher>> Create(Teacher teacher)
        {
            await repository.Create(teacher);

            return CreatedAtAction(nameof(GetById), new { Id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Teacher teacher)
        {
            try
            {
                teacher.Id = id;
                await repository.Update(teacher);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception)
            {

                return Problem();
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
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (System.Exception)
            {

                return Problem();
            }
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository repository;

        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> Get()
        {
            return await repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
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
        public async Task<ActionResult<Course>> Create(Course course)
        {
            await repository.Create(course);

            return CreatedAtAction(nameof(GetById), new { Id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Course course)
        {
            try
            {
                course.Id = id;
                await repository.Update(course);
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
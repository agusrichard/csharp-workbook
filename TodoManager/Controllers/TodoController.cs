using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoManager.Dtos;
using TodoManager.Models;
using TodoManager.Repositories;

namespace TodoManager.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository repository;

        public TodoController(ITodoRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoDto>> GetAllAsync()
        {
            return (await repository.GetTodosAsync()).Select(item => item.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetByIdAsync(int id)
        {
            Todo result = await repository.GetTodoAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            return result.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> CreateAsync(CreateUpdateTodoDto todo)
        {
            Todo newTodo = new()
            {
                Name = todo.Name,
                Description = todo.Description,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await repository.CreateTodoAsync(newTodo);

            return CreatedAtAction(nameof(GetByIdAsync), new { Id = newTodo.Id }, newTodo.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, CreateUpdateTodoDto todo)
        {
            var existingTodo = await repository.GetTodoAsync(id);

            if (existingTodo is null)
            {
                return NotFound();
            }

            var updatedTodo = existingTodo with
            {
                Name = todo.Name,
                Description = todo.Description
            };

            await repository.UpdateTodoAsync(updatedTodo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingTodo = await repository.GetTodoAsync(id);

            if (existingTodo is null)
            {
                return NotFound();
            }

            await repository.DeleteTodoAsync(existingTodo.Id);

            return NoContent();
        }
    }
}
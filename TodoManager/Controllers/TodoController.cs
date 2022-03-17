using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TodoManager.Dtos;
using TodoManager.Entities;
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
        public IEnumerable<TodoDto> GetAll()
        {
            return repository.GetTodos().Select(item => item.AsDto());
        }

        [HttpGet("{id}")]
        public ActionResult<TodoDto> GetById(Guid id)
        {
            Todo result = repository.GetTodo(id);
            if (result is null)
            {
                return NotFound();
            }

            return result.AsDto();
        }

        [HttpPost]
        public ActionResult<TodoDto> Create(CreateUpdateTodoDto todo)
        {
            Todo newTodo = new()
            {
                Id = Guid.NewGuid(),
                Name = todo.Name,
                Description = todo.Description,
                CreatedAt = DateTimeOffset.UtcNow
            };

            repository.CreateTodo(newTodo);

            return CreatedAtAction(nameof(GetById), new { Id = newTodo.Id }, newTodo.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, CreateUpdateTodoDto todo)
        {
            var existingTodo = repository.GetTodo(id);

            if (existingTodo is null)
            {
                return NotFound();
            }

            var updatedTodo = existingTodo with
            {
                Name = todo.Name,
                Description = todo.Description
            };

            repository.UpdateTodo(updatedTodo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingTodo = repository.GetTodo(id);

            if (existingTodo is null)
            {
                return NotFound();
            }

            repository.DeleteTodo(existingTodo.Id);

            return NoContent();
        }
    }
}
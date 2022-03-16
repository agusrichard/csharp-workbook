using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TodoManager.Entities;
using TodoManager.Repositories;

namespace TodoManager.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        private readonly InMemTodoRepository repository;

        public TodoController()
        {
            repository = new InMemTodoRepository();
        }

        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            return repository.GetTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetById(Guid id)
        {
            Todo result = repository.GetTodo(id);
            if (result is null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
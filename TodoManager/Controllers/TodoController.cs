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
    }
}
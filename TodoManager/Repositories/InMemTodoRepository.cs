using System;
using System.Collections.Generic;
using System.Linq;
using TodoManager.Dtos;
using TodoManager.Entities;

namespace TodoManager.Repositories
{
    public class InMemTodoRepository : ITodoRepository
    {
        private List<Todo> _todos = new()
        {
            new Todo
            {
                Id = Guid.NewGuid(),
                Name = "Sekardayu Hana Pradiani",
                Description = "Learn administration",
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Todo
            {
                Id = Guid.NewGuid(),
                Name = "Saskia Nurul Azhima",
                Description = "Learn economy",
                CreatedAt = DateTimeOffset.UtcNow
            },
            new Todo
            {
                Id = Guid.NewGuid(),
                Name = "Sintya Lestari",
                Description = "Learn communication",
                CreatedAt = DateTimeOffset.UtcNow
            }
        };

        public IEnumerable<Todo> GetTodos()
        {
            return _todos;
        }

        public Todo GetTodo(Guid id)
        {
            return _todos.Find(t => t.Id == id);
        }

        public void CreateTodo(Todo todo)
        {
            _todos.Add(todo);
        }

        public void UpdateTodo(Todo todo)
        {
            var existingTodoIndex = _todos.FindIndex(t => t.Id == todo.Id);
            _todos[existingTodoIndex] = todo;
        }

        public void DeleteTodo(Guid id)
        {
            _todos = _todos.Where(t => t.Id != id).ToList();
        }
    }
}
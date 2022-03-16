using System;
using System.Collections.Generic;
using TodoManager.Entities;

namespace TodoManager.Repositories
{
    public class InMemTodoRepository
    {
        private readonly List<Todo> _todos = new()
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
    }
}
using System;
using System.Collections.Generic;
using TodoManager.Entities;

namespace TodoManager.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodo(Guid id);
        void CreateTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(Guid id);
    }
}
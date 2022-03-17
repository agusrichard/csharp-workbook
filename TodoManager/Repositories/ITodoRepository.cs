using System;
using System.Collections.Generic;
using TodoManager.Entities;

namespace TodoManager.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodo(Guid id);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoManager.Entities;

namespace TodoManager.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> GetTodoAsync(Guid id);
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(Guid id);
    }
}
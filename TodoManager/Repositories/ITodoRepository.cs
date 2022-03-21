using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoManager.Models;

namespace TodoManager.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> GetTodoAsync(int id);
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
    }
}
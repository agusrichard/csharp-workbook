using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoManager.Entities;
using TodoManager;

namespace TodoManager.Repositories
{
    public class SqlServerTodoRepository : ITodoRepository
    {
        private readonly Models.TodoContext context;

        public SqlServerTodoRepository(Models.TodoContext context)
        {
            this.context = context;
        }
        public async Task CreateTodoAsync(Todo todo)
        {
            await context.AddAsync(todo);
        }

        public Task DeleteTodoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetTodoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> GetTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
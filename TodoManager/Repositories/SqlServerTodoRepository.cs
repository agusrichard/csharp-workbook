using System.Collections.Generic;
using System.Threading.Tasks;
using TodoManager.Models;
using Microsoft.EntityFrameworkCore;

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
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var result = await context.Todos.SingleOrDefaultAsync(t => t.Id == id);
            context.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<Todo> GetTodoAsync(int id)
        {
            return await context.Todos.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return await context.Todos.ToListAsync();
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            var result = await context.Todos.SingleOrDefaultAsync(t => t.Id == todo.Id);
            result.Name = todo.Name;
            result.Description = todo.Description;
            await context.SaveChangesAsync();
        }
    }
}
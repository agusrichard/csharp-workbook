using TodoManager.Dtos;
using TodoManager.Models;

namespace TodoManager
{
    public static class Extensions
    {
        public static TodoDto AsDto(this Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Name = todo.Name,
                Description = todo.Description,
                CreatedAt = todo.CreatedAt
            };
        }
    }
}
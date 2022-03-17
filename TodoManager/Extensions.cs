using TodoManager.Dtos;
using TodoManager.Entities;

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
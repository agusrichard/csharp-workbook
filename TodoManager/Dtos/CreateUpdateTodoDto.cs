using System.ComponentModel.DataAnnotations;

namespace TodoManager.Dtos
{
    public record CreateUpdateTodoDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Description { get; init; }
    }
}
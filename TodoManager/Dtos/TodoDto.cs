using System;

namespace TodoManager.Dtos
{
    public record TodoDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
    }
}
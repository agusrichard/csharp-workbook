using System;

namespace TodoManager.Entities
{
    public record Todo
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
    }
}
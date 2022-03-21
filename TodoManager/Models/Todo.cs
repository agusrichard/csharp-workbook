using System;
using System.ComponentModel.DataAnnotations;

namespace TodoManager.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
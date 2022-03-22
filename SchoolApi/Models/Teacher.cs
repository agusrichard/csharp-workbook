using System.Collections.Generic;

namespace SchoolApi.Models
{
    public record Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
using System.Collections.Generic;

namespace SchoolApi.Models
{
    public record Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Teacher Teacher { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolApi.Models
{
    public record Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        [JsonIgnore]
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace SchoolApi.Models
{
    public record StudentCourse
    {
        public int StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
    }
}
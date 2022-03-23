namespace SchoolApi.Dto
{
    public record RegisterStudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
namespace SchoolApi.Models
{
    public record Address
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
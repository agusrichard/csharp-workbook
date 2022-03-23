using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SchoolApi.Models
{
    public record Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        [NotMapped]
        public IList<Course> Courses { get; set; }
        [JsonIgnore]
        public IList<StudentCourse> StudentCourses { get; set; }
        [JsonIgnore]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
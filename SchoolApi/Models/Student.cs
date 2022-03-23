using System;
using System.Collections.Generic;

namespace SchoolApi.Models
{
    public record Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
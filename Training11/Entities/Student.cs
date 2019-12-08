using System;
using System.Collections.Generic;
using System.Text;

namespace Training11.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public School School { get; set; }
    }
}

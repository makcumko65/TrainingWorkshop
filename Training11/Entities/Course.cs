using System;
using System.Collections.Generic;
using System.Text;

namespace Training11.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}

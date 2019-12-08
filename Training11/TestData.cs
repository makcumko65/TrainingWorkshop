using System;
using System.Collections.Generic;
using System.Text;
using Training11.Entities;

namespace Training11
{
    public  class TestData
    {
        
        public List<School> Schools = new List<School>
        {
            new School{Id = 1, Name="School1"},
            new School{Id = 2, Name="School2"},
            new School{Id = 3, Name="School3"}
        };

        public List<Course> Courses = new List<Course>
        {
            new Course{Id = 1, Name="Course1",SchoolId = 1 },
            new Course{Id = 2, Name="Course2",SchoolId = 2 },
            new Course{Id = 3, Name="Course3",SchoolId = 3 },
            new Course{Id = 4, Name="Course4",SchoolId = 1 },
            new Course{Id = 5, Name="Course5",SchoolId = 1 },
            new Course{Id = 6, Name="Course6",SchoolId = 2 },
        };

        public List<Student> Students = new List<Student>
        {
            new Student{Id = 1, Name="Student1",SchoolId = 1,CourseId = 1 },
            new Student{Id = 2, Name="Student2",SchoolId = 1,CourseId = 2 },
            new Student{Id = 3, Name="Student3",SchoolId = 1,CourseId = 3 },
            new Student{Id = 4, Name="Student4",SchoolId = 1,CourseId = 4 },
            new Student{Id = 5, Name="Student5",SchoolId = 1,CourseId = 5 },
            new Student{Id = 6, Name="Student6",SchoolId = 2,CourseId = 6 },
            new Student{Id = 7, Name="Student7",SchoolId = 2,CourseId = 1 },
            new Student{Id = 8, Name="Student8",SchoolId = 2,CourseId = 2 },
            new Student{Id = 9, Name="Student9",SchoolId = 2,CourseId = 3 },
            new Student{Id = 10, Name="Student10",SchoolId = 2,CourseId = 4 },
        };
    }
}

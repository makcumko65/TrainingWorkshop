using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training11.Entities;
using Training11.Interfaces;

namespace Training11.Mocks
{
    public class StudentMockService : IStudent
    {
        TestData testData = new TestData();
        public void Join(Student student)
        {
            var countCoursePerStudent = testData.Students.Where(x => x.CourseId == student.CourseId).Count();
            if (countCoursePerStudent <= 30)
            {
                testData.Students.Add(student);
            }
            else
            {
                throw new Exception("Student must be 30 or less in course");
            }
        }

        public void Leave(Student student)
        {
            throw new NotImplementedException();
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Training11.Entities;
using Training11.Mocks;

namespace TestTraining11
{
    [TestFixture]
    class StudentTest
    {
        StudentMockService studentService = new StudentMockService();
        [Test]
        public void CheckMaxNumberOfStudentsInGroup()
        {
            Assert.Catch<Exception>(() => RandomStudents());
        }

        public void RandomStudents()
        {
            for (int i = 0; i <= 30; i++)
            {
                studentService.Join(new Student()
                {
                    CourseId = 1,
                    Name = $"Student{i}",
                    SchoolId = 1,
                    Id = 10020
                });
            }
        }
    }
}

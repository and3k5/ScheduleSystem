using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScheduleSystem.Test.ClassesTest
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CheckIfStudensAreAddedToCourse()
        {
            Course course = new Course();
            Student student = new Student();
            student.CPR = "010101-0101";
            
            course.Students.Add(student);
        }
    }
}

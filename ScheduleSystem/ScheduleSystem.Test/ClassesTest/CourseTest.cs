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
            student.Name = "Herbert";
            student.Email = "test@test.com";
            course.Students.Add(student);
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        public void CheckIfStudensAreRemovedFromCourse()
        {
            Course course = new Course();
            Student student = new Student();
            student.CPR = "010101-0101";
            student.Name = "Herbert";
            student.Email = "test@test.com";
            course.Students.Add(student);
            int oldCount = course.Students.Count;
            course.Students.Remove(student);
            Assert.IsTrue((course.Students.Count == 0) && (oldCount == 1));
        }

        [TestMethod]
        public void CheckIfNameIsAssignedFromConstructor()
        {
            Course course = new Course("WAT");
            Assert.AreEqual("WAT", course.Name);
        }
    }
}

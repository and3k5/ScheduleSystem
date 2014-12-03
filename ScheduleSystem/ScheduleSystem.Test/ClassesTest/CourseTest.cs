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
            // Create course and student
            Course course = new Course();
            Student student = new Student();

            // Set some information in student object
            student.CPR = "010101-0101";
            student.Name = "Herbert";
            student.Email = "test@test.com";

            // Add student to course object
            course.Students.Add(student);

            // Assertion = course should contain one student
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        public void CheckIfStudensAreRemovedFromCourse()
        {
            // Create course and student
            Course course = new Course();
            Student student = new Student();

            // Set some information in student object
            student.CPR = "010101-0101";
            student.Name = "Herbert";
            student.Email = "test@test.com";
            
            // Add student to course object
            course.Students.Add(student);

            // Assertion = course should contain one student
            Assert.IsTrue(course.Students.Count == 1);
            
            // Remove student from course object
            course.Students.Remove(student);

            // Assertion = course should not contain any student
            Assert.IsTrue(course.Students.Count == 0);
        }

        [TestMethod]
        public void CheckIfNameIsAssignedFromConstructor()
        {
            // Set course name variable
            String CourseName = "Programming 3 - Test";
            
            // Create course with name assigned from contructor parameter
            Course course = new Course(CourseName);
            
            // Assertion = course name should match the constructor parameter
            Assert.AreEqual(CourseName, course.Name);
        }
    }
}

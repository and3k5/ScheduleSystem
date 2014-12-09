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
            /*  1 - Create course
             *  2 - Create Student
             *  3 - Add student to course
             *  4 - Check if student is assigned to course
             */
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
            /*  1 - Create course
             *  2 - Create Student
             *  3 - Add student to course
             *  4 - Check if student is assigned to course
             *  5 - Remove student from course
             *  6 - Check if student has been removed
             */
            Course course = new Course();

            Student student = new Student();
            student.CPR = "010101-0101";
            student.Name = "Herbert";
            student.Email = "test@test.com";

            course.Students.Add(student);

            Assert.IsTrue(course.Students.Count == 1);
            
            course.Students.Remove(student);

            Assert.IsTrue(course.Students.Count == 0);
        }

        [TestMethod]
        public void CheckIfNameIsAssignedFromConstructor()
        {
            /*  1 - Set course name variable
             *  2 - Create course with name assigned from contructor parameter
             *  3 - Assertion = course name should match the constructor parameter
             */
            String CourseName = "Programming 3 - Test";
            
            Course course = new Course(CourseName);
            
            Assert.AreEqual(CourseName, course.Name);
        }
    }
}

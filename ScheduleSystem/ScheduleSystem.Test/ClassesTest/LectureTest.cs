using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScheduleSystem.Test.ClassesTest
{
    [TestClass]
    public class LectureTest
    {
        [TestMethod]
        public void CheckIfTeacherIsAssignedLecture()
        {
            /* 1 - Create lecture
             * 2 - Create teacher
             * 3 - Assign teacher to lecture
             * 4 - Check if Teacher is assigned to lecture
             */
            Lecture lecture = new Lecture();
            lecture.Name = "Programming";
            DateTime date1 = new DateTime(2014, 5, 1, 8, 30, 52);
            DateTime date2 = new DateTime(2014, 5, 2, 8, 30, 52);
            lecture.StartDate = date1;
            lecture.EndDate = date2;

            Teacher teacher = new Teacher();
            teacher.Name = "Michael";
            teacher.Email = "Mich@mich.com";
            teacher.Skills = "Much_skills";

            lecture.Teachers.Add(teacher);

            Assert.IsTrue(lecture.Teachers.Count == 1);
        }

        [TestMethod]
        public void CheckIfTeacherRemovedFromLecture()
        {
            /* 1 - Create lecture
             * 2 - Create teacher
             * 3 - Assign teacher to lecture
             * 4 - Check if Teacher is assigned to lecture
             * 5 - Remove teacher from lecture
             * 6 - Check if teacher has been removed
             */
            Lecture lecture = new Lecture();
            lecture.Name = "Programming";
            DateTime date1 = new DateTime(2014, 5, 1, 8, 30, 52);
            DateTime date2 = new DateTime(2014, 5, 2, 8, 30, 52);
            lecture.StartDate = date1;
            lecture.EndDate = date2;

            Teacher teacher = new Teacher();
            teacher.Name = "Michael";
            teacher.Email = "Mich@mich.com";
            teacher.Skills = "Much_skills";

            lecture.Teachers.Add(teacher);

            Assert.IsTrue(lecture.Teachers.Count == 1);

            lecture.Teachers.Remove(teacher);

            Assert.IsTrue(lecture.Teachers.Count == 0);
        }
    }
}

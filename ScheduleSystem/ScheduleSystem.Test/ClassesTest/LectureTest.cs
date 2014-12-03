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
            Lecture lecture = new Lecture();
            Teacher teacher = new Teacher();

            teacher.Name = "Michael";
            teacher.Email = "Mich@mich.com";
            teacher.Skills = "Much_skills";

            DateTime date1 = new DateTime(2014, 5, 1, 8, 30, 52);
            DateTime date2 = new DateTime(2014, 5, 2, 8, 30, 52);

            lecture.Name = "Programming";
            lecture.StartDate = date1;
            lecture.EndDate = date2;
            lecture.Teachers.Add(teacher);

            Assert.IsTrue(lecture.Teachers.Count == 1);
        }
    }
}

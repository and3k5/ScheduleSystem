using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScheduleSystem.Test.ClassesTest
{
    [TestClass]
    public class TeacherTest
    {
        [TestMethod]
        public void CreateNewTeacherTestMethod()
        {
            /* 1 - Create new teacher
             * 2 - Add teacher Name
             * 3 - Add teacher Email
             * 4 - Add teacher Skills
             * 5 - Check if teacher has been created
             * 6 - Check teacher name
             * 7 - Check teacher Email
             * 8 - Check teacher CPR
             **/

            string tName = "Michael";
            string tEmail = "Mich@Mich.com";
            string tSkills = "Much Skills";

            Teacher teacher = new Teacher();

            teacher.Name = tName;
            teacher.Email = tEmail;
            teacher.Skills = tSkills;

            Assert.IsTrue(teacher != null);
            Assert.IsTrue(teacher.Name == tName);
            Assert.IsTrue(teacher.Email == tEmail);
            Assert.IsTrue(teacher.Skills == tSkills);
        }
    }
}

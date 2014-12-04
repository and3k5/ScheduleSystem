using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScheduleSystem.Test.ClassesTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void AddStudentTestMethod()
        {
            /* 1 - Create new student
             * 2 - Add student name
             * 3 - Add student Email
             * 4 - Add student CPR
             * 5 - Check if student has been created
             * 6 - Check student name
             * 7 - Check student Email
             * 8 - Check student CPR
             **/

            string sName = "Carmen Electra";
            string sEmail = "Carmen@Dolls.com";
            string sCpr = "";

            Student student = new Student();

            student.Name = sName;
            student.Email = sEmail;
            student.CPR = sCpr;

            Assert.IsTrue(student != null);
            Assert.IsTrue(student.Name == sName);
            Assert.IsTrue(student.Email == sEmail);
            Assert.IsTrue(student.CPR == sCpr);
        }
    }
}

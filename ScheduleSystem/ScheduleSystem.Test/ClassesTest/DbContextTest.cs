using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleSystem.Data;

namespace ScheduleSystem.Test.ClassesTest
{
    [TestClass]
    public class DbContextTest
    {
        [TestMethod]
        public void TestDbContext()
        {
            using (ScheduleSystemContext db = new ScheduleSystemContext())
            {
                /* 1 - Create database if it does not exist
                 * 2 - Create course
                 * 3 - Create student
                 * 4 - Add student to course
                 * 5 - Add course to database
                 * 6 - Save changes to database
                 */
                db.Database.CreateIfNotExists();

                var course = new Course();
                course.StartDate = new DateTime(2014, 01, 01);
                course.EndDate = new DateTime(2014, 12, 01);
                course.Name = "Test course";

                Student student = new Student();
                student.CPR = "123456-7890";
                student.Email = "hello@example.com";
                student.Name = "Bent";

                course.Students.Add(student);

                db.Courses.Add(course);

                db.SaveChanges();
            }
        }
    }
}

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

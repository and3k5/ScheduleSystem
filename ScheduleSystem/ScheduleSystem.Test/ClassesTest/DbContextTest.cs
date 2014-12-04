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
                var course = new Course("wat");
                db.Courses.Add(course);
            }
        }
    }
}

namespace ScheduleSystem.Data
{
    using System;
    using System.Data.Entity;

    // IDisposable is added for using this type in a 'using' case
    public class ScheduleSystemContext : DbContext, IDisposable
    {
        // This is our Database context, with tables.
        public ScheduleSystemContext()
            : base("ScheduleSystemDatabase")
        {
            
        }

        // Tables of the database
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
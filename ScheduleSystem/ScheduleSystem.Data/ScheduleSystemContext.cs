namespace ScheduleSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ScheduleSystemContext : DbContext, IDisposable
    {
        // Your context has been configured to use a 'ScheduleSystem' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ScheduleSystem.Data.ScheduleSystem' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ScheduleSystem' 
        // connection string in the application configuration file.
        public ScheduleSystemContext()
        //    : base("name=ScheduleSystem.Data.Properties.Settings.ScheduleSystemContext")
            : base(ScheduleSystem.Data.Properties.Settings.Default.ScheduleSystemContext)
        {
            
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
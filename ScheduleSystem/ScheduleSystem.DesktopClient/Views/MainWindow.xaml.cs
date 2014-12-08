using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScheduleSystem.DesktopClient.Views;
using ScheduleSystem.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace ScheduleSystem.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (ScheduleSystemContext db = new ScheduleSystemContext())
            {
                db.Database.CreateIfNotExists();

                Course course = new Course("Test 1");
                course.StartDate = DateTime.Now;
                course.EndDate = DateTime.Now.AddDays(7);
                db.Courses.Add(course);
                
                course = new Course("Test 2");
                course.StartDate = DateTime.Now;
                course.EndDate = DateTime.Now.AddDays(7);
                db.Courses.Add(course);

                course = new Course("Test 3");
                course.StartDate = DateTime.Now;
                course.EndDate = DateTime.Now.AddDays(7);
                db.Courses.Add(course);
                
                db.SaveChanges();
                
                DbSet<Course> courses = db.Courses;

                var query =
                    from Crse in courses
                    select new { Crse.Name, Crse.StartDate, Crse.EndDate };

                dGrid1.ItemsSource = query.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CourseDialog courseDiag = new CourseDialog();
            courseDiag.Show();
        }
    }
}

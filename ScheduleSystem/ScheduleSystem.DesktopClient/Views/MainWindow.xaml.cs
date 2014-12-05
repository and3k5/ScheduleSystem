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
                var course = new Course("wat1");
                course.StartDate = DateTime.Now;
                course.EndDate = DateTime.Now.AddDays(7);
                db.Courses.Add(course);
                course = new Course("wat2");
                course.StartDate = DateTime.Now;
                course.EndDate = DateTime.Now.AddDays(7);
                db.Courses.Add(course);
                course = new Course("wat3");
                course.StartDate = DateTime.Now;
                course.EndDate = DateTime.Now.AddDays(7);
                db.Courses.Add(course);
                db.SaveChanges();
                DbSet<Course> courses = db.Courses;

                var query =
                from Crse in courses
                where 1 == 1
                select new { course.Name, course.StartDate, course.EndDate };

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

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
using ScheduleSystem.DesktopClient.ViewModels;
using System.ComponentModel;

namespace ScheduleSystem.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class EditCourse : ICommand
    {
        public void Execute(Object _course)
        {
            Course course = (Course)_course;
            CourseDialog cDialog = new CourseDialog();
            cDialog.DataContext = new CourseViewModel(course);
            cDialog.Show();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
    public partial class MainWindow : Window
    {
        public EditCourse editCourse = new EditCourse();
        public MainWindow()
        {
            InitializeComponent();
            using (ScheduleSystemContext db = ((ScheduleSystemContext)DataContext))
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
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CourseDialog courseDiag = new CourseDialog();
            courseDiag.Show();
        }
        public void UpdateItems()
        {
            dGrid1.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateItems();
        }
    }
}

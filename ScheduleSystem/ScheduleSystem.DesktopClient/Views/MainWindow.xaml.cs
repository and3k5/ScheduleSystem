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
using System.Collections.ObjectModel;

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
            // Create database if it does not exist
            SSCTX.Database.CreateIfNotExists();
        }
        //Easy workaround to access the DataContext as a ScheduleSystemContext, 
        //instead of casting every time
        private ScheduleSystemContext SSCTX
        {
            get
            {
                return (ScheduleSystemContext)DataContext;
            }
        }
        public void CourseView_UpdateItems()
        {
            // Refresh datagrid and save changes to database.
            dGrid1.Items.Refresh();
            SSCTX.SaveChanges();
        }

        private void CourseView_CommonCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // User can always add or edit a customer, so can execute will just be
            // true for both of the commands
            e.CanExecute = true;
        }

        private void CourseView_EditCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Opens the "Edit Course" dialog and
            // enabled you to change the parameters of the
            // course selected from the databse.
            Course course = (Course)e.Parameter;
            CourseDialog cDialog = new CourseDialog();
            cDialog.DataContext = new CourseViewModel(course);
            cDialog.Closed += CourseView_cDialog_Closed;
            cDialog.ShowDialog();
        }

        private void CourseView_NewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Creates a new course object and shows the "Add Course" window
            // Course is saved to the databse when windows is closed.
            Course course = new Course();
            SSCTX.Courses.Add(course);
            CourseDialog cDialog = new CourseDialog();
            cDialog.DataContext = new CourseViewModel(course);
            cDialog.Closed += CourseView_cDialog_Closed;
            cDialog.ShowDialog();
        }
        void CourseView_cDialog_Closed(object sender, EventArgs e)
        {
            // Updates items in course view
            CourseView_UpdateItems();
        }

        private void AboutBtnClick(object sender, RoutedEventArgs e)
        {
            // Creates the "About" dialog and shows it when button is clicked.
            AboutDialog aDialog = new AboutDialog();
            aDialog.ShowDialog();
        }

        private void StudentView_CommonCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // User can always add or edit a customer, so can execute will just be
            // true for both of the commands 
            e.CanExecute = true;
        }

        private void StudentView_EditCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // This function below is not best practice when looking from 
            // the MVVM perspective.
            // We've prioritised functionality and setup above MVVM principles.

            // Fetch the student which is 'owner' of the fired 'Edit' command
            Student student = (Student)e.Parameter;

            // Create a copy element which is linked to the dialog below.
            // We won't link the real Student object to the viewmodel, 
            // because of the option to Cancel changes (press X on window)
            Student copy = new Student();
            copy.Name = student.Name;
            copy.Email = student.Email;
            copy.CPR = student.CPR;

            // Create Student dialog with StudentModelView linked to the Student copy
            StudentDialog sDialog = new StudentDialog();
            sDialog.DataContext = new StudentViewModel(copy);

            // Get result of the dialog (Did the user press X or Save?)
            Nullable<bool> result = sDialog.ShowDialog();

            // If save was pressed, apply the specified data to the real student
            if (result == true)
            {
                student.Name = copy.Name;
                student.Email = copy.Email;
                student.CPR = copy.CPR;
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            StudentView_UpdateItems();

        }
        public void StudentView_UpdateItems()
        {
            // Refresh datagrid and save changes to database.
            dGrid2.Items.Refresh();
            SSCTX.SaveChanges();
        }
        private void StudentView_NewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // This function below is not best practice when looking from 
            // the MVVM perspective.
            // We've prioritised functionality and setup above MVVM principles.

            // Create a new Student element which would be directly linked
            // to the viewmodel
            Student student = new Student();

            // Create dialog and link the ViewModel
            StudentDialog sDialog = new StudentDialog();
            sDialog.DataContext = new StudentViewModel(student);

            // Get result of the dialog (Did the user press X or Save?)
            Nullable<bool> result = sDialog.ShowDialog();

            // If save was pressed, Add the student object to the database
            if (result == true)
            {
                SSCTX.Students.Add(student);
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            StudentView_UpdateItems();
        }
    }
}

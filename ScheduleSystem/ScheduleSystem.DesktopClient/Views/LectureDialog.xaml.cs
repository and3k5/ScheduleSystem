using ScheduleSystem.DesktopClient.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace ScheduleSystem.DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for LectureDialog.xaml
    /// </summary>
    public partial class LectureDialog : Window
    {
        public LectureDialog()
        {
            InitializeComponent();
        }
        private void CommonCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // User can always add or edit a customer, so can execute will just be
            // true for both of the commands
            e.CanExecute = true;
        }

        private void EditCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // This function below is not best practice when looking from 
            // the MVVM perspective.
            // We've prioritised functionality and setup above MVVM principles.

            // Fetch the teacher which is 'owner' of the fired 'Edit' command
            Teacher teacher = (Teacher)e.Parameter;

            // Create a copy element which is linked to the dialog below.
            // We won't link the real Teacher object to the viewmodel, 
            // because of the option to Cancel changes (press X on window)
            Teacher copy = new Teacher();
            copy.Name = teacher.Name;
            copy.Email = teacher.Email;
            copy.Skills = teacher.Skills;

            // Create Teacher dialog with TeacherModelView linked to the Teacher copy
            TeacherDialog sDialog = new TeacherDialog();
            sDialog.DataContext = new TeacherViewModel(copy);

            // Get result of the dialog (Did the user press X or Save?)
            Nullable<bool> result = sDialog.ShowDialog();

            // If save was pressed, apply the specified data to the real teacher
            if (result == true)
            {
                teacher.Name = copy.Name;
                teacher.Email = copy.Email;
                teacher.Skills = copy.Skills;
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            UpdateItems();
        }

        private void NewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // This function below is not best practice when looking from 
            // the MVVM perspective.
            // We've prioritised functionality and setup above MVVM principles.

            // Create a new Teacher element which would be directly linked
            // to the viewmodel
            Teacher teacher = new Teacher();

            // Create dialog and link the ViewModel
            TeacherDialog sDialog = new TeacherDialog();
            sDialog.DataContext = new TeacherViewModel(teacher);

            // Get result of the dialog (Did the user press X or Save?)
            Nullable<bool> result = sDialog.ShowDialog();

            // If save was pressed, Add the teacher object to the database
            if (result == true)
            {
                ((LectureViewModel)DataContext).Teachers.Add(teacher);
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            UpdateItems();
        }
        private void UpdateItems()
        {
            // Update items on the datagrid (the list of teachers)
            dataGrid.Items.Refresh();
        }
    }
}

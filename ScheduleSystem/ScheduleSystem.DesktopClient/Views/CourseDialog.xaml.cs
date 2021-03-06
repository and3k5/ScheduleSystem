﻿using ScheduleSystem.DesktopClient.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScheduleSystem.DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for CourseDialog.xaml
    /// </summary>
    public partial class CourseDialog : Window
    {
        public CourseDialog()
        {
            InitializeComponent();
        }

        private void CommonCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // User can always add or edit a customer, so can execute will just be
            // true for both of the commands
            e.CanExecute = true;
        }

        private void EditStudentCmd_Executed(object sender, ExecutedRoutedEventArgs e)
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
            UpdateItems();
        }

        private void NewStudentCmd_Executed(object sender, ExecutedRoutedEventArgs e)
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
                ((CourseViewModel)DataContext).Students.Add(student);
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            UpdateItems();
        }

        private void EditLectureCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Opens the "Edit lecture" dialog and
            // enabled you to change the parameters of the
            // lecture selected from the databse.
            Lecture lecture = (Lecture)e.Parameter;
            LectureDialog cDialog = new LectureDialog();
            cDialog.DataContext = new LectureViewModel(lecture);
            
            cDialog.ShowDialog();
            
            UpdateItems();
        }

        private void NewLectureCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Creates a new lecture object and shows the "Add lecture" window
            // lecture is saved to the databse when windows is closed.
            Lecture lecture = new Lecture();

            ((CourseViewModel)DataContext).Lectures.Add(lecture);
            LectureDialog cDialog = new LectureDialog();
            cDialog.DataContext = new LectureViewModel(lecture);
            
            cDialog.ShowDialog();
            UpdateItems();
        }

        private void UpdateItems()
        {
            // Update items on the datagrid (the list of students)
            dataGrid.Items.Refresh();
            // Update items on the seconds datagrid (the list of lectures)
            dGrid2.Items.Refresh();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Enables save function when entered information is valid.
            e.CanExecute = IsValid(sender as DependencyObject);
        }
        // http://stackoverflow.com/a/4650392
        private bool IsValid(DependencyObject obj)
        {
            return !Validation.GetHasError(obj) &&
                LogicalTreeHelper.GetChildren(obj)
                .OfType<DependencyObject>()
                .All(IsValid);
        }
        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

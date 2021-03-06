﻿using System;
using System.Windows;
using System.Windows.Input;
using ScheduleSystem.DesktopClient.Views;
using ScheduleSystem.Data;
using System.Data.Entity;
using ScheduleSystem.DesktopClient.ViewModels;

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

            // For some reason, we have to load every table manually.
            // We bind the CollectionChanged event to a function, 
            // which is explained below.
            SSCTX.Students.Load();
            SSCTX.Students.Local.CollectionChanged += Local_CollectionChanged;
            SSCTX.Teachers.Load();
            SSCTX.Teachers.Local.CollectionChanged += Local_CollectionChanged;
            SSCTX.Lectures.Load();
            SSCTX.Lectures.Local.CollectionChanged += Local_CollectionChanged;
            SSCTX.Courses.Load();
            SSCTX.Courses.Local.CollectionChanged += Local_CollectionChanged;
        }

        void Local_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Every time we delete an element from the datagrid,
            // it won't be removed from the database, unless we do 
            // a manual SaveChanges on the DbContext
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                SSCTX.SaveChanges();
            }
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

            Nullable<bool> result = cDialog.ShowDialog();

            if (result != true)
            {
                SSCTX.Entry(course).Reload();
            }
            CourseView_UpdateItems();
        }

        private void CourseView_NewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Creates a new course object and shows the "Add Course" window
            // Course is saved to the databse when windows is closed.
            Course course = new Course();
            
            
            CourseDialog cDialog = new CourseDialog();
            cDialog.DataContext = new CourseViewModel(course);
            
            Nullable<bool> result = cDialog.ShowDialog();

            if (result == true)
            {
                if (course.Name.Trim().Length!=0) SSCTX.Courses.Add(course);
            }
            CourseView_UpdateItems();
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
                try
                {
                    SSCTX.Students.Add(student);
                }
                catch (NullReferenceException ex)
                {

                }
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            StudentView_UpdateItems();
        }

        private void TeacherView_CommonCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // User can always add or edit a customer, so can execute will just be
            // true for both of the commands 
            e.CanExecute = true;
        }

        private void TeacherView_EditCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // This function below is not best practice when looking from 
            // the MVVM perspective.
            // We've prioritised functionality and setup above MVVM principles.

            // Fetch the student which is 'owner' of the fired 'Edit' command
            Teacher teacher = (Teacher)e.Parameter;

            // Create a copy element which is linked to the dialog below.
            // We won't link the real Student object to the viewmodel, 
            // because of the option to Cancel changes (press X on window)
            Teacher copy = new Teacher();
            copy.Name = teacher.Name;
            copy.Email = teacher.Email;
            copy.Skills = teacher.Skills;

            // Create Student dialog with StudentModelView linked to the Student copy
            TeacherDialog sDialog = new TeacherDialog();
            sDialog.DataContext = new TeacherViewModel(copy);

            // Get result of the dialog (Did the user press X or Save?)
            Nullable<bool> result = sDialog.ShowDialog();

            // If save was pressed, apply the specified data to the real student
            if (result == true)
            {
                teacher.Name = copy.Name;
                teacher.Email = copy.Email;
                teacher.Skills = copy.Skills;
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            TeacherView_UpdateItems();

        }
        public void TeacherView_UpdateItems()
        {
            // Refresh datagrid and save changes to database.
            dGrid3.Items.Refresh();
            SSCTX.SaveChanges();
        }
        private void TeacherView_NewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // This function below is not best practice when looking from 
            // the MVVM perspective.
            // We've prioritised functionality and setup above MVVM principles.

            // Create a new Student element which would be directly linked
            // to the viewmodel
            Teacher teacher = new Teacher();

            // Create dialog and link the ViewModel
            TeacherDialog sDialog = new TeacherDialog();
            sDialog.DataContext = new TeacherViewModel(teacher);

            // Get result of the dialog (Did the user press X or Save?)
            Nullable<bool> result = sDialog.ShowDialog();

            // If save was pressed, Add the student object to the database
            if (result == true)
            {
                try
                {
                    SSCTX.Teachers.Add(teacher);
                }
                catch (NullReferenceException ex)
                {

                }
            }

            // Also this is far from MVVM standard, but PropertyChanged
            // does not work properly with the DataGrid item.
            TeacherView_UpdateItems();
        }
    }
}

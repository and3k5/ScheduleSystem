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
            SSCTX.Database.CreateIfNotExists();
        }
        private ScheduleSystemContext SSCTX
        {
            get
            {
                return (ScheduleSystemContext)DataContext;
            }
        }
        public void UpdateItems()
        {
            dGrid1.Items.Refresh();
            SSCTX.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateItems();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Course course = (Course)e.Parameter;
            CourseDialog cDialog = new CourseDialog();
            cDialog.DataContext = new CourseViewModel(course);
            cDialog.Closed += cDialog_Closed;
            cDialog.ShowDialog();
            //cDialog.Show();
            
        }

        private void NewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Course course = new Course();
            SSCTX.Courses.Add(course);
            CourseDialog cDialog = new CourseDialog();
            cDialog.DataContext = new CourseViewModel(course);
            cDialog.Closed += cDialog_Closed;
            cDialog.ShowDialog();
            //cDialog.Show();
            
        }
        void cDialog_Closed(object sender, EventArgs e)
        {
            UpdateItems();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AboutDialog aDialog = new AboutDialog();
            aDialog.ShowDialog();
        }
    }
}

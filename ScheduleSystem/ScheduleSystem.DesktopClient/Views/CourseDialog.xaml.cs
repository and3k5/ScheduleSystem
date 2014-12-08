using ScheduleSystem.Data;
using ScheduleSystem.DesktopClient.ViewModels;
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
using System.Windows.Shapes;

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
        private CourseViewModel SSCTX
        {
            get
            {
                return (CourseViewModel)DataContext;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentDialog studiag = new StudentDialog();
            studiag.Show();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Student student = (Student)e.Parameter;
            StudentDialog sDialog = new StudentDialog();
            sDialog.DataContext = new StudentViewModel(student);
            dataGrid.Items.Refresh();
            sDialog.Closed += sDialog_Closed;
            sDialog.Show();
        }

        private void NewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Student student = new Student();
            SSCTX.Students.Add(student);
            StudentDialog sDialog = new StudentDialog();
            sDialog.DataContext = new StudentViewModel(student);
            dataGrid.Items.Refresh();
            sDialog.Closed += sDialog_Closed;
            sDialog.Show();
        }

        void sDialog_Closed(object sender, EventArgs e)
        {
            dataGrid.Items.Refresh();
        }
    }
}

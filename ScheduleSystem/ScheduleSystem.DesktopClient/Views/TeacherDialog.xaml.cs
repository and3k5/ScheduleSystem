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
    /// Interaction logic for TeacherDialog.xaml
    /// </summary>
    public partial class TeacherDialog : Window
    {
        public TeacherDialog()
        {
            InitializeComponent();
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
            //this.Close();
        }
    }
}

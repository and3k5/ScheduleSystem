using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScheduleSystem.DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for StudentDialog.xaml
    /// </summary>
    public partial class StudentDialog : Window
    {
        public StudentDialog()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Enables save function when entered information is valid.
            e.CanExecute = IsValid(sender as DependencyObject);
        }

        // Function to check the validations of an element and all it's controls
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
            // Makes the dialog return 'positive'.
            // Means that changes/properties will be saved.
            // If dialog doesn't return true, changes will not be comitted
            this.DialogResult = true;
        }
    }
}

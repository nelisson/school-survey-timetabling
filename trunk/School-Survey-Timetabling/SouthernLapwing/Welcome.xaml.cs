using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Common.ValidationRules;

namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome
    {
        public string Email { get; set; }
        public string FullName { get; set; }    

        public Welcome()
        {
            Email = " ";
            FullName = " ";
            InitializeComponent();
        }

        private void CommandBindingCanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Validation.GetHasError(TextBoxFullName) && !Validation.GetHasError(TextBoxEmail);
        }

        private void CommandBindingExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            new MainWindow(Email, FullName).Show();
            Close();
        }
    }
}

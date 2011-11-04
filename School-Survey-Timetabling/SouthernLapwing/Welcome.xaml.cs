using System.Windows;

namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            new MainWindow(TextBoxEmail.Text, TextBoxFullName.Text).Show();
            Close();
        }
    }
}

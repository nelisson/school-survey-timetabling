using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;
using MessageBox = Microsoft.Windows.Controls.MessageBox;

namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static object _token;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSendClick(object sender, RoutedEventArgs e)
        {
            Group1.IsEnabled = false;
            busyIndicator.IsBusy = true;

            var client = new SmtpClient("smtp.gmail.com", 587)
                             {
                                 Credentials = new NetworkCredential("fatimaescolateste@gmail.com", "admin123."),
                                 EnableSsl = true,
                             };
            var mail = new MailMessage("fatimaescolateste@gmail.com", "fatimaescolateste@gmail.com")
                           {
                               Subject = "Teste",
                               Body =
                                   Serialize(
                                       GridDays.Children.OfType<Label>().Where(l => l.DataContext != null).Select(
                                           l => l.DataContext).Cast<Choice>().ToList()),
                           };

            client.SendCompleted += ClientSendCompleted;
            client.SendAsync(mail, _token);
        }

        private void ClientSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            busyIndicator.IsBusy = false;
            Group1.IsEnabled = true;
            if (!(e.Cancelled && e.Error == null))
                MessageBox.Show("Preferências enviadas com sucesso");
            else
                MessageBox.Show("Erro no envio");
        }

        private void LabelDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var label = sender as Label;
            if (label == null) return;

            label.Background = new SolidColorBrush(Colors.AliceBlue);

            foreach (Label child in GridDays.Children.OfType<Label>().Where(c => c.DataContext != null && c != label))
            {
                if ((child.DataContext as Choice).Priority != (label.DataContext as Choice).Priority)
                {
                    label.Background = new SolidColorBrush(Colors.AliceBlue);
                    child.Background = new SolidColorBrush(Colors.AliceBlue);
                    continue;
                }

                child.Background = new SolidColorBrush(Colors.Tomato);
                label.Background = new SolidColorBrush(Colors.Tomato);
            }
        }

        public string Serialize<T>(T _object)
        {
            var xmlSettings = new XmlWriterSettings
                                  {OmitXmlDeclaration = true, Indent = true, NewLineOnAttributes = true};

            var serializer = new XmlSerializer(_object.GetType());

            var stringBuilder = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(stringBuilder, xmlSettings))
                serializer.Serialize(writer, _object);

            return stringBuilder.ToString();
        }
    }
}
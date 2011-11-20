using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Extensions;
using MessageBox = Microsoft.Windows.Controls.MessageBox;
<<<<<<< .mine
using Common;
using System.IO;
using System.Net.Mime;
=======
using Common;
>>>>>>> .r31

namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static readonly object Token = new object();
        private static readonly Brush ErrorColor = new SolidColorBrush(Colors.Tomato);
        private static readonly Brush OkColor = new SolidColorBrush(Colors.Cyan);

<<<<<<< .mine
        public string TeacherEmail { get; set; }
        public string TeacherFullName { get; set; }

        public MainWindow(string name, string email) : this() 
        {
            TeacherFullName = name;
            TeacherEmail = email;
        }

=======
        string Email { get; set; }
        string FullName { get; set; }

>>>>>>> .r31
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string email, string name) : this()
        {
            Email = email;
            FullName = name;
        }

        private void ButtonSendClick(object sender, RoutedEventArgs e)
        {

            if (!InputIsValid())
            {
                MessageBox.Show("Existem conflitos na tabela","ERRO",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            var teacherChoice = new TeacherChoice
                                    {
                                        Alternatives = GridDays.Children
                                            .OfType<Label>()
                                            .Where(l => l.DataContext != null)
                                            .Select(l => l.DataContext)
                                            .Cast<Alternative>().ToList(),
<<<<<<< .mine
                                        Email = TeacherEmail,
                                        Name = TeacherFullName,
=======
                                        Email = Email,
                                        Name = FullName,
>>>>>>> .r31
                                    };

            Options.IsEnabled = false;
            busyIndicator.IsBusy = true;

            var client = new SmtpClient("smtp.gmail.com", 587)
                             {
                                 Credentials = new NetworkCredential("fatimaescolateste@gmail.com", "admin123."),
                                 EnableSsl = true,
                             };

            var contentType = new ContentType("text/xml") { Name = "teacherChoice.xml" };
            var xmlAttachment = Attachment.CreateAttachmentFromString(teacherChoice.Serialize(), contentType);
            var mail = new MailMessage("fatimaescolateste@gmail.com", "fatimaescolateste@gmail.com")
                           {
                               Subject = "Teste",
                           };
            mail.Attachments.Add(xmlAttachment);

            client.SendCompleted += ClientSendCompleted;
            client.SendAsync(mail, Token);
        }

        private bool InputIsValid()
        {
            return !GridDays.Children.OfType<Label>().Any(l => l.Background == ErrorColor); 
        }

        private void ClientSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            busyIndicator.IsBusy = false;
            Options.IsEnabled = true;
            if (!(e.Cancelled && e.Error == null))
                MessageBox.Show("Preferências enviadas com sucesso");
            else
                MessageBox.Show("Erro no envio");
        }

        private void LabelDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var days = GridDays.Children
                .OfType<Label>()
                .Where(l => l.DataContext != null)
                .Select(l => new {Alternative = l.DataContext as Alternative, Label = l})
                .ToLookup(item => item.Alternative.Priority);

            foreach (var alternative in days.Where(d => d.Count() > 1).SelectMany(group => group.ToList()))
            {
                alternative.Label.Background = ErrorColor;
            }
            
            foreach (var alternative in days.Where(d => d.Count() == 1).SelectMany(group => group.ToList()))
            {
                alternative.Label.Background = OkColor;
            }
        }
    }
}
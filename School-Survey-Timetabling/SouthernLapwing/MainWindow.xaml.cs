﻿using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Extensions;
using MessageBox = Microsoft.Windows.Controls.MessageBox;
using Common;

using System.Net.Mime;



namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static readonly object Token = new object();

        string Email { get; set; }
        string FullName { get; set; }


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
            var teacherChoice = new TeacherChoice
                                    {
                                        Alternatives = GridDays.Children
                                            .OfType<RadioButton>()
                                            .Where(l => l.IsChecked.HasValue)
                                            .Select(l => l.DataContext)
                                            .Cast<Alternative>().ToList(),

                                        Email = Email,
                                        Name = FullName,
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

        private void ClientSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            busyIndicator.IsBusy = false;
            Options.IsEnabled = true;
            if (!(e.Cancelled && e.Error == null))
                MessageBox.Show("Preferências enviadas com sucesso");
            else
                MessageBox.Show("Erro no envio");
        }
    }
}
using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Ribbon;

namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private static object _token;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSendClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("fatimaescolateste@gmail.com", "admin123."),
                EnableSsl = true,
            };
            var mail = new MailMessage("fatimaescolateste@gmail.com", "fatimaescolateste@gmail.com")
                           {
                               Subject = "Teste",
                               Body = "WOW",
                           };
            Group1.IsEnabled = false;
            client.SendCompleted += ClientSendCompleted;
            busyIndicator.IsBusy = true;
            
            client.SendAsync(mail, _token);
        }

        void ClientSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            busyIndicator.IsBusy = false;
            Group1.IsEnabled = true;
            if(!(e.Cancelled && e.Error == null))
                MessageBox.Show("Preferências enviadas com sucesso");
            else
                MessageBox.Show("Erro no envio");
        }
    }
}

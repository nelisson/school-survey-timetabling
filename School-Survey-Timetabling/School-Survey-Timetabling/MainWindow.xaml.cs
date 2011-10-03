using System.Windows.Media;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using School_Survey_Timetabling.Model;

namespace School_Survey_Timetabling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ContractVerification(true)]
    public partial class MainWindow
    {
        /// <summary>
        /// Transf
        /// </summary>
        public Transform Trans { get; set; }

        /// <summary>
        /// uhul
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Trans = new ScaleTransform(1.2, 1.2);
            Resources.Add("teste", Trans);
        }

        private void Button2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void Buttonf_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var escola = new EmefFatima();
        }
    }
}

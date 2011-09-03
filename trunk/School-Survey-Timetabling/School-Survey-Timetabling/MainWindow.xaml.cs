using System.Windows.Media;
using System.Diagnostics.Contracts;
using System.Collections.Generic;

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

            var x = new TesteLINQ();
            x.M(null);
            var teste = new Dictionary<string, Dictionary<string, Dictionary<string, List<Dictionary<List<int>, object>>>>>();
            
            // Insert code required on object creation below this point.
            var ttt = teste.ToString();

            foreach (var t in teste)
            {
                   
            }
        }

        private void Button2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}

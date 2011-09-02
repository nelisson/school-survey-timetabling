using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace School_Survey_Timetabling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Transform Trans { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Trans = new ScaleTransform(1.2, 1.2);
            Resources.Add("teste", Trans);

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

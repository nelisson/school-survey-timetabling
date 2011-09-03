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
        }

        private void Button2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}

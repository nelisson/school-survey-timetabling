using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using School_Survey_Timetabling.Model;

namespace School_Survey_Timetabling
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var emef = new EmefFatima())
            {
                emef.Rooms.InsertOnSubmit(new Room{Code = "E5"});
                emef.SubmitChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var emef = new EmefFatima())
            {
                foreach (var room in emef.Rooms)
                {
                    room.Code = "A6";
                }
                emef.SubmitChanges();
            }
        }
    }
}

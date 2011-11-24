using System;
using System.Windows;
using School_Survey_Timetabling.Model;

namespace School_Survey_Timetabling
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register
    {
        private EmefFatima emef;

        public Register()
        {
            InitializeComponent();
            emef = (EmefFatima)Resources["Emef"];
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            var room = new Room {Code = "E5", Class = new Class()};
            emef.ObservableRooms.Add(room);
            Rooms.SelectedItem = room;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            emef.SubmitChanges();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void exclude_Click(object sender, RoutedEventArgs e)
        {
            var deletedIndex = Rooms.SelectedIndex;
            emef.ObservableRooms.Remove((Room)Rooms.SelectedItem);
            Rooms.SelectedIndex = Math.Min(deletedIndex, Rooms.Items.Count - 1);
        }
    }
}

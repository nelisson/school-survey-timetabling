using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using School_Survey_Timetabling.Model;

namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void LabelMouseUp(object sender, MouseButtonEventArgs e)
        {
            var label = (Label)sender;
            
            if (label.DataContext == null)
            {
                label.DataContext = new Alternative
                                        {
                                            Priority = e.ChangedButton == MouseButton.Left ? 1 : 3,
                                            DayOfWeek = (DayOfWeek) ((int) label.GetValue(Grid.ColumnProperty) + 1),
                                            Shift = (Shift) label.GetValue(Grid.RowProperty)
                                        };
                return;
            }

            var value = (Alternative) label.DataContext;

            value.Priority = value.Priority + (e.ChangedButton == MouseButton.Left ? 1 : -1);
            label.DataContext = value.Priority < 1 || value.Priority > 3 ? null : new Alternative(value);

            if (label.DataContext == null)
                label.Background = new SolidColorBrush(Colors.White);
        }
    }
}
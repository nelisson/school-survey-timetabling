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
        protected void LabelMouseUp(object sender, MouseButtonEventArgs e)
        {
            var label = sender as Label;
            if (label == null) return;

            if (label.DataContext == null)
            {
                label.DataContext = new Choice
                                        {
                                            Priority = e.ChangedButton == MouseButton.Left ? 1 : 3,
                                            DayOfWeek = (DayOfWeek) ((int) label.GetValue(Grid.ColumnProperty) + 1),
                                            Shift = (Shift) label.GetValue(Grid.RowProperty)
                                        };
                return;
            }

            var value = (Choice) label.DataContext;

            value.Priority = value.Priority + (1*(e.ChangedButton == MouseButton.Left ? 1 : -1));
            label.DataContext = value.Priority < 1 || value.Priority > 3 ? null : new Choice(value);

            if (label.DataContext == null)
                label.Background = new SolidColorBrush(Colors.White);
        }
    }
}
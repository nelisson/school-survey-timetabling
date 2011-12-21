using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Common;

namespace SouthernLapwing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void LabelMouseUp(object sender, MouseButtonEventArgs e)
        {
            const int maxOptions = 1;
            var label = (Label)sender;
            
            if (label.DataContext == null)
            {
                label.DataContext = new Alternative
                                        {
                                            DayOfWeek = (DayOfWeek) ((int) label.GetValue(Grid.ColumnProperty) + 1),
                                            Shift = (Shift) label.GetValue(Grid.RowProperty)
                                        };
                return;
            }

            if (label.DataContext == null)
                label.Background = new SolidColorBrush(Colors.White);
        }

        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            var image = (RadioButton)sender;
            
            image.DataContext = new Alternative
            {
                DayOfWeek = (DayOfWeek)((int)image.GetValue(Grid.ColumnProperty) + 1),
                Shift = (Shift)image.GetValue(Grid.RowProperty)
            };
        }
    }
}
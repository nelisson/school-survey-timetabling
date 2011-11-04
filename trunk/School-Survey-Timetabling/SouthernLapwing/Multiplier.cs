using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SouthernLapwing
{
    public class Multiplier : MarkupExtension, IValueConverter
    {
        public double Factor { get; set; }
        
        public Multiplier(){}
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) * Factor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) / Factor;
        }
    }
}

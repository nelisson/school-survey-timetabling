using System.Windows;

namespace Common.Converters
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Windows.Data;
    using Extensions;

    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.GetType().IsEnum || targetType != typeof(String))
                return DependencyProperty.UnsetValue;

            return ((Enum) value).GetDescriptionOrDefault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

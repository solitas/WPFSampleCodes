using System;
using System.Globalization;
using System.Windows.Data;

namespace Solitas
{
    [ValueConversion(typeof(double), typeof(byte))]
    public class DoubleToByteConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return (byte)(double)value;
            return byte.MinValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return (double)(byte)value;
            return double.MinValue;
        }

        #endregion
    }
}

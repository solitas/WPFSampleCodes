using System;
using System.Windows;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
namespace Solitas
{
    public class RgbToColorConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var color = Color.FromRgb((byte) values[0],
                (byte) (double) values[1],
                (byte) (double) values[2]);

            if (targetType == typeof(Color))
            {
                return color;
            }

            if (targetType == typeof(Brush))
            {
                return new SolidColorBrush(color);
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Color color;
            object[] primaries = new object[3];
            if (value is Color color1)
            {
                color = color1;
            }
            else if (value is SolidColorBrush brush)
            {
                color = brush.Color;
            }
            else
            {
                return null;
            }

            primaries[0] = color.R;
            primaries[1] = color.G;
            primaries[2] = color.B;
            return primaries;
        }

        #endregion
    }
}

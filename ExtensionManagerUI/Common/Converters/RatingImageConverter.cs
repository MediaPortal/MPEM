using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExtensionManagerUI.Common.Converters
{
    public class RatingImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return value;

            int rating = (value is int) ? (int)value : 0;
            return string.Format("/ExtensionManagerUI;component/Images/Rating{0}.png", rating);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

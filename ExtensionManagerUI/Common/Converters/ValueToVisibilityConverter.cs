using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExtensionManagerUI.Common.Converters
{
    public class ValueToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                if (parameter.ToString().Contains('|'))
                {
                    foreach (var condition in parameter.ToString().Split('|'))
                    {
                        if (value.ToString() == condition)
                        {
                            return System.Windows.Visibility.Visible;
                        }
                    }
                    return System.Windows.Visibility.Collapsed;
                }

                return value.ToString() == parameter.ToString()
                    ? System.Windows.Visibility.Visible
                    : System.Windows.Visibility.Collapsed;
            }

            return System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


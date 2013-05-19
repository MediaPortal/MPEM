using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExtensionManagerUI.Common.Converters
{
    public class BoolToImageConverter : IValueConverter
    {
        #region IValueConverter Members

        public string ImageTrue { get; set; }
        public string ImageFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return ((bool)value) ? ImageTrue : ImageFalse;
            }

            if (value != null && parameter != null)
            {
                if (parameter.ToString().Contains('|'))
                {
                    foreach (var condition in parameter.ToString().Split('|'))
                    {
                        if (value.ToString() == condition)
                        {
                            return ImageTrue;
                        }
                    }
                    return ImageFalse;
                }

                return value.ToString() == parameter.ToString()
                    ? ImageTrue
                    : ImageFalse;
            }

            return ImageTrue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


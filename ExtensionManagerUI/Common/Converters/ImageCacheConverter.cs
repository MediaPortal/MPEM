using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ExtensionManager.Common.Utils;

namespace ExtensionManagerUI.Common.Converters
{
    public class ImageCacheConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                var imageString = value.ToString();
                var cacheName = Environment.CurrentDirectory + string.Format("\\Data\\Images\\{0}",  System.IO.Path.GetFileName(imageString));
                if (System.IO.File.Exists(cacheName))
                {
                    return cacheName;
                }
                return imageString.StartsWith("http") ? DownloadManager.DownloadFileAsync(imageString, cacheName) : null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


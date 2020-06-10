using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeHomework.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string myPath = (string)value;
                Uri myURI = new Uri(myPath, UriKind.RelativeOrAbsolute);
                BitmapImage anImage = new BitmapImage(myURI);
                return anImage;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}

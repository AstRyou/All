using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfTreeHomework.Converters
{
    class NullorEmptytoVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string myPath = (string)value;
                if (!String.IsNullOrEmpty(myPath))
                {
                    return Visibility.Visible;
                }
                return Visibility.Hidden;
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

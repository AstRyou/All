using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTreeHomework.Converters
{
    class progressbarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var para = value as string;
            switch (PasswordStrengthUtils.CalculatePasswordStrength(para))
            {
                case PasswordStrength.VeryWeak:return 20;
                case PasswordStrength.Weak:return 40;
                case PasswordStrength.Average:return 60;
                case PasswordStrength.Strong:return 80;
                case PasswordStrength.VeryStrong:return 100;
                default:return 0;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}

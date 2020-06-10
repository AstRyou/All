using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfTreeHomework.Converters
{
    class passwordtolabelcolor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var para = value as string;
            switch (PasswordStrengthUtils.CalculatePasswordStrength(para))
            {
                case PasswordStrength.VeryWeak: return new SolidColorBrush(Colors.Red);
                case PasswordStrength.Weak: return new SolidColorBrush(Colors.Orange);
                case PasswordStrength.Average: return new SolidColorBrush(Colors.Yellow);
                case PasswordStrength.Strong: return new SolidColorBrush(Colors.LightGreen);
                case PasswordStrength.VeryStrong: return new SolidColorBrush(Colors.Green);
                default: return new SolidColorBrush(Colors.Gray);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

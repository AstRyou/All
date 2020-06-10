using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTreeHomework.Converters
{
    class passwordtoStrongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var para = value as string;
            switch (PasswordStrengthUtils.CalculatePasswordStrength(para))
            {
                case PasswordStrength.VeryWeak: return "Very Weak";
                case PasswordStrength.Weak: return "Weak";
                case PasswordStrength.Average: return "Average";
                case PasswordStrength.Strong: return "Strong";
                case PasswordStrength.VeryStrong: return "Very Strong";
                default: return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}

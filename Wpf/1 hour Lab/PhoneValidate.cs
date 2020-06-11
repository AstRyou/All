using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfLab1
{
    public class Phone : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);
            Regex rx = new Regex("[0-9]{1-20}");
            if (!rx.IsMatch(strValue))
                return new ValidationResult(false, $"invalid.");
            else
                return new ValidationResult(true, null);

        }
    }
}

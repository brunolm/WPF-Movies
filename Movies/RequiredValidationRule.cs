using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Movies
{
    public class RequiredValidationRule : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (String.IsNullOrWhiteSpace(value as string))
            {
                return new ValidationResult(false, "*");
            }

            return new ValidationResult(true, null);
        }
    }
}

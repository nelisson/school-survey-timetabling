using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Common.ValidationRules
{
    public class NotNullOrEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrEmpty((string)value)
                ? new ValidationResult(false, "Campo não pode ser vazio.") :
                  ValidationResult.ValidResult;
        }
    }
}

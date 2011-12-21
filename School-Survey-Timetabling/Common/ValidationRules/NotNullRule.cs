namespace Common.ValidationRules
{
    using System.Globalization;
    using System.Windows.Controls;

    /// <summary>
    /// Checks if a value is not null.
    /// </summary>
    public class NotNullRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return (value != null)
                       ? ValidationResult.ValidResult
                       : new ValidationResult(false, "Campo não pode ser vazio.");
        }
    }
}

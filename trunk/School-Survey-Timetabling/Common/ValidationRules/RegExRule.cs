namespace Common.ValidationRules
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;

    /// <summary>
    /// Checks if a value matches a given regular expression.
    /// </summary>
    class RegExRule : ValidationRule
    {
        private Regex _expression;
        /// <summary>
        /// Regular expression to match against.
        /// </summary>
        public Regex Expression
        {
            get { return _expression; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _expression = value;
            }
        }

        /// <summary>
        /// Custom error message to display.
        /// </summary>
        public string CustomMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) 
                return new ValidationResult(false, "Campo não pode ser vazio.");

            return (Expression.IsMatch(value.ToString()))
                       ? ValidationResult.ValidResult
                       : new ValidationResult(false, CustomMessage);
        }
    }
}

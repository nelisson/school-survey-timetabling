namespace Common.ValidationRules
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Windows.Controls;

    /// <summary>
    /// Checks if a value is over a range of specified values.
    /// </summary>
    public class InRangeRule : ValidationRule
    {
        public InRangeRule()
        {
            _min = int.MinValue;
            _max = int.MaxValue;
        }

        private int _min;
        /// <summary>
        /// Minimum allowed value;
        /// </summary>
        public int Min
        {
            get { return _min; }
            set
            {
                Contract.Requires<ArgumentOutOfRangeException>(value < Max);
                _min = value;
            }
        }

        private int _max;
        /// <summary>
        /// Maximum allowed value;
        /// </summary>
        public int Max
        {
            get { return _max; }
            set
            {
                Contract.Requires<ArgumentOutOfRangeException>(value > Min);
                _max = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int toValidate;
            if (!Int32.TryParse((string)value, out toValidate))
                return new ValidationResult(false, "Valor é nulo ou não é um número.");

            if (toValidate < Min || toValidate > Max)
                return new ValidationResult(false, string
                    .Format("Valor fora do intervalo permitido ({0} a {1}).", Min, Max));

            return ValidationResult.ValidResult;
        }
    }
}

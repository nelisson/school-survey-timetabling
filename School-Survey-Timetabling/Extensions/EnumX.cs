using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Extensions
{
    public static class EnumX
    {
        public static string GetDescription(this Enum e)
        {
            var description = (DescriptionAttribute) e.GetType()
                                                         .GetCustomAttributes(typeof (DescriptionAttribute), false).
                                                         FirstOrDefault() ?? new DescriptionAttribute();

            return description.Description;
        }

        [Pure]
        public static string GetDescriptionOrDefault(this Enum e)
        {
            Contract.Ensures(Contract.Result<string>() != null);
            return e.GetDescription() ?? e.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using Extensions;

namespace School_Survey_Timetabling
{
    public class EnumValuesExtension : MarkupExtension
    {
        public EnumValuesExtension()
        {
        }

        public EnumValuesExtension(Type enumType)
        {
            this.EnumType = enumType;
        }

        [ConstructorArgument("enumType")]
        public Type EnumType { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.EnumType == null || !EnumType.IsEnum)
                throw new ArgumentException("The enum type is not set");

            var result = Enum.GetValues(this.EnumType)
                .Cast<Enum>()
                .Select((e) => new { Value = e, Name = e.GetDescriptionOrDefault() })
                .ToList();
            return result;
        }
    }

}

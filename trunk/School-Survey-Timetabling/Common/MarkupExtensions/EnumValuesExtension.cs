namespace Common.MarkupExtensions
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Windows.Markup;
    using Extensions;

    public class EnumValuesExtension : MarkupExtension
    {
        public EnumValuesExtension() {}

        public EnumValuesExtension(Type enumType)
            : this()
        {
            EnumType = enumType;
        }

        private Type _enumType;
        [ConstructorArgument("enumType")]
        public Type EnumType
        {
            get { return _enumType; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                Contract.Requires<ArgumentOutOfRangeException>(value.IsEnum, "Type must be an enum.");
                _enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var result = Enum.GetValues(EnumType)
                .Cast<Enum>()
                .Select((e) => new { Value = e, Name = e.GetDescriptionOrDefault() })
                .ToList();
            return result;
        }
    }
}

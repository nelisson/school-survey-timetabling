namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Diagnostics.Contracts;
    using Extensions;

    [Table(Name = "AnosCiclos")]
    public class CycleYear : SchoolEntity
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        protected internal override long Id { get; set; }

        public CycleYear() {}

        public CycleYear(int year, CycleCode cycleCode, ClassType classType)
            : this()
        {
            Year = year;
            CycleCode = cycleCode;
            ClassType = classType;
        }

        private int _year;
        [Column(Name = "Ano")]
        public int Year
        {
            get { return _year; }
            set
            {
                Contract.Requires<ArgumentOutOfRangeException>(value > 0, "Ano deve ser um número maior que zero.");
                _year = value;
                OnPropertyChanged("Ano");
            }
        }

        private CycleCode _cycleCode;
        [Column(Name = "Ciclo")]
        public CycleCode CycleCode
        {
            get { return _cycleCode; }
            set
            {
                Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(CycleCode), value));
                _cycleCode = value;
                OnPropertyChanged("CycleCode");
            }
        }

        private ClassType _classType;
        [Column(Name = "Tipo")]
        public ClassType ClassType
        {
            get { return _classType; }
            set
            {
                Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(ClassType), value));
                _classType = value;
                OnPropertyChanged("ClassType");
            }
        }

        private EntityRef<Class> _class;
        [Association(OtherKey = "Id", Storage = "_class")]
        public Class Class
        {
            get { return _class.Entity; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _class.Entity = value;
                OnPropertyChanged("Class");
            }
        }

        public override string ToString()
        {
            return String.Format(ClassType == ClassType.Progression ? "{1}{0}{2}" : "{0}{1}{2}",
                                 ClassType.GetDescriptionOrDefault(), CycleCode.GetDescriptionOrDefault(), Year);
        }
    }
}
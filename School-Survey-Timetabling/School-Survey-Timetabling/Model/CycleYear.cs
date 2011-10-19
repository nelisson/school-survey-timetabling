using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Extensions;

namespace School_Survey_Timetabling.Model
{
    enum CycleCode
    {
        A,
        B,
        C,
    }

    enum ClassType
    {
        [Description("")]
        Normal,

        [Description("P")]
        Progression,

        [Description("J")]
        Kindergarten,
    }

    [Table(Name = "AnoCiclos")]
    class CycleYear
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name = "Ano")]
        public int Year { get; set; }

        [Column(Name = "Ciclo")]
        public CycleCode CycleCode { get; set; }

        [Column(Name = "Tipo")]
        public ClassType ClassType { get; set; }

        public CycleYear(int year, CycleCode cycleCode, ClassType classType)
        {
            Year = year;
            CycleCode = cycleCode;
            ClassType = classType;
        }

        public override string ToString()
        {
            return String.Format(ClassType == ClassType.Progression ? "{1}{0}{2}" : "{0}{1}{2}",
                                 ClassType.GetDescriptionOrDefault(), CycleCode.GetDescriptionOrDefault(), Year);
        }

        private EntityRef<Class> _class;
        
        public Class Class
        {
            get { return _class.Entity; }
            set { _class.Entity = value; }
        }
        

    }
}

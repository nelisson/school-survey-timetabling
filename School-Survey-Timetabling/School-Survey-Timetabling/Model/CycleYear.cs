using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Extensions;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "AnoCiclos")]
    internal class CycleYear
    {
        private EntityRef<Class> _class;

        public CycleYear(int year, CycleCode cycleCode)
        {
            Year = year;
            CycleCode = cycleCode;
        }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name = "Ano")]
        public int Year { get; set; }

        [Column(Name = "Ciclo")]
        public CycleCode CycleCode { get; set; }

        public Class Class
        {
            get { return _class.Entity; }
            set { _class.Entity = value; }
        }
    }
}
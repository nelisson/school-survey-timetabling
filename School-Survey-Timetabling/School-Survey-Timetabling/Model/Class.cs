using System.Data.Linq.Mapping;
using Common;
using System;
using Extensions;
using System.Diagnostics.Contracts;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "Turmas")]
    internal class Class
    {
        public Class(Shift shift, ClassType type, Room room)
        {
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(Shift), shift));
            Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(ClassType), type));
            Contract.Requires<ArgumentNullException>(room != null);

            Shift = shift;
            ClassType = type;
            Room = room;
        }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name = "Turno")]
        public Shift Shift { get; set; }

        [Column(Name = "Tipo")]
        public ClassType ClassType { get; set; }

        [Association(OtherKey = "Id")]
        public CycleYear CycleYear { get; set; }

        [Association(OtherKey = "Id")]
        public Room Room { get; set; }

        public string ShortCode
        {
            get
            {
                return String.Format(ClassType == ClassType.Progression ? "{1}{0}{2}" : "{0}{1}{2}",
                     ClassType.GetDescriptionOrDefault(), 
                     CycleYear.CycleCode.GetDescriptionOrDefault(), 
                     CycleYear.Year);
            }
        }
    }
}
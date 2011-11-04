using System.Data.Linq.Mapping;
using Common;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "Turmas")]
    internal class Class
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name = "Turno")]
        public Shift Shift { get; set; }

        [Association(OtherKey = "Id")]
        public CycleYear CycleYear { get; set; }

        [Association(OtherKey = "Id")]
        public Room Room { get; set; }
    }
}
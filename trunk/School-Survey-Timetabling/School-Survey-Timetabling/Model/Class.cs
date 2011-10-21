using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    public enum Shift
    {
        Morning,
        Evening,
    }

    [Table(Name="Turmas")]
    class Class
    {
        [Column(IsDbGenerated=true, IsPrimaryKey=true)]
        private long Id { get; set; }
        
        [Column(Name="Turno")]
        public Shift Shift { get; set; }

        [Association(OtherKey = "Id")]
        public CycleYear CycleYear { get; set; }

        [Association(OtherKey = "Id")]
        public Room Room { get; set; }
    }
}

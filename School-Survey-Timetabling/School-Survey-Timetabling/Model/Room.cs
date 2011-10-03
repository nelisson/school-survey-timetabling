using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Table(Name="Salas")]
    class Room
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        public string Code { get; set; }
    }
}

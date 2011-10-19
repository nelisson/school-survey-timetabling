using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Table(Name="Salas")]
    class Room
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name="Numero")]
        public string Code { get; set; }

        private EntityRef<Class> _class;

        public Class Class
        {
            get { return _class.Entity; }
            set { _class.Entity = value; }
        }
    }
}

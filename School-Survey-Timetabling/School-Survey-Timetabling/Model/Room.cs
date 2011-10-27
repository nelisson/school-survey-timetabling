using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "Salas")]
    internal class Room
    {
        private EntityRef<Class> _class;

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name = "Numero")]
        public string Code { get; set; }

        public Class Class
        {
            get { return _class.Entity; }
            set { _class.Entity = value; }
        }
    }
}
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Common;
using System;
using System.Diagnostics.Contracts;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "Turmas")]
    internal class Class
    {
        public Class()
        {
            
        }
        public Class(Shift shift, Room room)
        {
            //Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof(Shift), shift));
            //Contract.Requires<ArgumentNullException>(room != null);

            Shift = shift;
            Room = room;
        }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private int Id { get; set; }

        [Column(Name = "Turno")]
        public Shift Shift { get; set; }

        private EntityRef<CycleYear> _cycleYear;
        [Association(OtherKey = "Id", Storage="_cycleYear")]
        public CycleYear CycleYear
        {
            get { return _cycleYear.Entity; }
            set { _cycleYear.Entity = value; }
        }

        [Column(Name="Tipo")]
        public ClassType Type { get; set; }

        private EntityRef<Room> _room;
        [Association(OtherKey = "Id", Storage="_room")]
        public Room Room
        {
            get { return _room.Entity; }
            set { _room.Entity = value; }
        }
        
    }
}
namespace School_Survey_Timetabling.Model
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using Common;
    using System;
    using System.Diagnostics.Contracts;

    [Table(Name = "Turmas")]
    internal class Class : SchoolEntity
    {
        public Class() {}

        public Class(Shift shift, Room room) : this()
        {
            Shift = shift;
            Room = room;
        }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private int Id { get; set; }

        private Shift _shift;

        [Column(Name = "Turno")]
        public Shift Shift
        {
            get { return _shift; }
            set
            {
                Contract.Requires<ArgumentOutOfRangeException>(Enum.IsDefined(typeof (Shift), value));
                _shift = value;
                OnPropertyChanged("Shift");
            }
        }

        private EntityRef<CycleYear> _cycleYear;

        [Association(OtherKey = "Id", Storage = "_cycleYear")]
        public CycleYear CycleYear
        {
            get { return _cycleYear.Entity; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _cycleYear.Entity = value;
                OnPropertyChanged("CycleYear");
            }
        }

        private EntityRef<Room> _room;

        [Association(OtherKey = "Id", Storage = "_room")]
        public Room Room
        {
            get { return _room.Entity; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _room.Entity = value;
                OnPropertyChanged("Room");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace School_Survey_Timetabling.Model
{
    enum Shift
    {
        Morning,
        Evening,
    }

    [Table(Name="Turmas")]
    class Class
    {
        [Column(IsDbGenerated=true, IsPrimaryKey=true)]
        private long Id { get; set; }

        [Column(Name="AnoCiclo")]
        public CycleYear CycleYear { get; set; }

        [Column(Name="Sala")]
        public Room Room { get; set; }

        [Column(Name="Turno")]
        public Shift Shift { get; set; }
    }
}

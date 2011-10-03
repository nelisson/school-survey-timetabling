using System;

namespace School_Survey_Timetabling.Model
{

    abstract class Block
    {
        public TimeSpan Duration { get; set; }
        public DateTime Start { get; set; }
        public Discipline Discipline { get; set; }
    }
}

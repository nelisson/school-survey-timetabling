using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School_Survey_Timetabling.Model
{
    class LongBlock : Block
    {
        public LongBlock(DateTime start, Discipline discipline)
        {
            Start = start;
            Duration = TimeSpan.FromHours(1);
            Discipline = discipline;
        }
    }
}

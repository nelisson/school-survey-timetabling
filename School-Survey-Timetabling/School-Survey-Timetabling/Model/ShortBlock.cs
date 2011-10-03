using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School_Survey_Timetabling.Model
{
    class ShortBlock : Block
    {
        public ShortBlock(DateTime start, Discipline discipline)
        {
            Start = start;
            Duration = TimeSpan.FromMinutes(45);
            Discipline = discipline;
        }
    }
}

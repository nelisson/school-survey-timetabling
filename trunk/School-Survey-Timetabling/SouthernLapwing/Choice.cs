using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using School_Survey_Timetabling.Model;

namespace SouthernLapwing
{
    class Choice
    {
        public int Priority { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Shift Shift { get; set; }
    }
}

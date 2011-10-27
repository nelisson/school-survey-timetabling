using System;
using School_Survey_Timetabling.Model;

namespace SouthernLapwing
{
    public class Choice
    {
        public Choice(Choice _choice)
        {
            Priority = _choice.Priority;
            DayOfWeek = _choice.DayOfWeek;
            Shift = _choice.Shift;
        }

        public Choice()
        {
        }

        public int Priority { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Shift Shift { get; set; }
    }
}
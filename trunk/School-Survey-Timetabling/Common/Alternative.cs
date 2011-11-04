using System;
using Common;

namespace SouthernLapwing
{
    public class Alternative
    {
        

        public Alternative(Alternative alternative)
        {
            Priority = alternative.Priority;
            DayOfWeek = alternative.DayOfWeek;
            Shift = alternative.Shift;
        }

        public Alternative()
        {
        }

        public int Priority { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Shift Shift { get; set; }
    }
}
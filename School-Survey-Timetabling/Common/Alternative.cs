using System;

namespace Common
{
    public class Alternative
    {
        public Alternative(Alternative alternative)
        {
            DayOfWeek = alternative.DayOfWeek;
            Shift = alternative.Shift;
        }

        public Alternative()
        {
        }

        public DayOfWeek DayOfWeek { get; set; }
        public Shift Shift { get; set; }
    }
}
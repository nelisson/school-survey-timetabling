using System;

namespace School_Survey_Timetabling.Model
{
    internal class LongBlock : Block
    {
        public LongBlock()
        {
            
        }
        public LongBlock(DateTime start, Discipline discipline)
        {
            Start = start;
            Duration = TimeSpan.FromHours(1);
            Discipline = discipline;
            Length = BlockLength.Long;
        }
    }
}
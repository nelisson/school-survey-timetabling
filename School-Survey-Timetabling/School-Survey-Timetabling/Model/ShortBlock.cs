using System;

namespace School_Survey_Timetabling.Model
{
    internal class ShortBlock : Block
    {
        public ShortBlock(DateTime start, Discipline discipline)
        {
            Start = start;
            Duration = TimeSpan.FromMinutes(45);
            Discipline = discipline;
            Length = BlockLength.Short;
        }
    }
}
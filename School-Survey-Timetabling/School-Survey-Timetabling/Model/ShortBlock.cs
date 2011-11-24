namespace School_Survey_Timetabling.Model
{
    using System;

    internal class ShortBlock : Block
    {
        public ShortBlock() {}

        public ShortBlock(DateTime start, Discipline discipline)
            : this()
        {
            Start = start;
            Duration = TimeSpan.FromMinutes(45);
            Discipline = discipline;
            Length = BlockLength.Short;
        }
    }
}
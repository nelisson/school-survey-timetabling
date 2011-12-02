namespace School_Survey_Timetabling.Model
{
    using System;

    public class LongBlock : Block
    {
        public LongBlock() {}

        public LongBlock(DateTime start, Discipline discipline)
            : this()
        {
            Start = start;
            Duration = TimeSpan.FromHours(1);
            Discipline = discipline;
            Length = BlockLength.Long;
        }
    }
}
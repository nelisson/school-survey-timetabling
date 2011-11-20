using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace School_Survey_Timetabling
{
    public class IntSequence : IEnumerable<int>, IEnumerable
    {
        public int Start { get; set; }
        public int End { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            return Enumerable.Range(Start, End - Start + 1).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

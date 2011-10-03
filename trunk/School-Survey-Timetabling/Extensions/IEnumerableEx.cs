using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class IEnumerableEx
    {
        public static TimeSpan Sum(this IEnumerable<TimeSpan> e)
        {
            return TimeSpan.FromSeconds(e.Sum(t => t.TotalSeconds));
        }
    }
}

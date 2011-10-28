using System;
using System.Collections.Generic;
using System.Linq;

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
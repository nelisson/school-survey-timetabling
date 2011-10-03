using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Extensions;
using System.Linq;
using System.Text;

namespace School_Survey_Timetabling.Model
{
    class Teacher : Employee
    {
        [ContractInvariantMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(Disciplines.Select(d => d.Workload).Sum() <= Workload);
        }

        public IEnumerable<Discipline> Disciplines { get; set; }

    }
}

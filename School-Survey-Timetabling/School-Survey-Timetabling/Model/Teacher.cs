using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics.Contracts;
using System.Linq;
using Extensions;

namespace School_Survey_Timetabling.Model
{
    class Teacher : Employee
    {
        public Teacher()
        {
            Role = Role.Teacher;
            _disciplines = new EntitySet<Discipline>();
        }

        [ContractInvariantMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(Disciplines.Select(d => d.Workload).Sum() <= Workload);
        }

        private EntitySet<Discipline> _disciplines;

        [Association(Storage = "_disciplines", OtherKey="Id")]
        public EntitySet<Discipline> Disciplines
        {
            get { return _disciplines; }
            set { _disciplines.Assign(value); }
        }
    }
}

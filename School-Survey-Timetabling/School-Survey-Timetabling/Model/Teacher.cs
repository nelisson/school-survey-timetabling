namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Extensions;

    internal class Teacher : Employee
    {
        public Teacher()
        {
            Role = EmployeeRole.Teacher;
            _disciplines = new EntitySet<Discipline>();
        }

        private readonly EntitySet<Discipline> _disciplines;
        [Association(Storage = "_disciplines", OtherKey = "Id")]
        public EntitySet<Discipline> Disciplines
        {
            get { return _disciplines; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _disciplines.Assign(value);
                OnPropertyChanged("Disciplines");
            }
        }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(Disciplines.Select(d => d.Workload).Sum() <= Workload);
        }
    }
}
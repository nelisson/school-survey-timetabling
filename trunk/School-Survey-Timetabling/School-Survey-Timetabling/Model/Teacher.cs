namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Extensions;

    public class Teacher : Employee
    {
        public Teacher()
        {
            Role = EmployeeRole.Teacher;
            _teacherDisciplines = new EntitySet<TeacherDiscipline>(e => { e.Teacher = this; }, e => { e.Teacher = null; });
        }

        private readonly EntitySet<TeacherDiscipline> _teacherDisciplines;
        [Association(Storage = "_teacherDisciplines", OtherKey = "TeacherId", ThisKey="Id")]
        public EntitySet<TeacherDiscipline> TeacherDisciplines
        {
            get { return _teacherDisciplines; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _teacherDisciplines.Assign(value);
                OnPropertyChanged("TeacherDisciplines");
            }
        }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            //Contract.Invariant(TeacherDisciplines.Select(d => d.Discipline.Workload).Sum() <= Workload);
        }

        private void OnDisciplinesAdd(Discipline entity)
        {
            TeacherDisciplines.Add(new TeacherDiscipline { Teacher = this, Discipline = entity });
        }

        private void OnDisciplinesRemove(Discipline entity)
        {
            var teacherDiscipline = TeacherDisciplines.FirstOrDefault(
                c => c.TeacherId == Id
                && c.DisciplineId == entity.Id);
            TeacherDisciplines.Remove(teacherDiscipline);
        }

        private EntitySet<Discipline> _disciplines;

        public EntitySet<Discipline> Disciplines
        {
            get
            {
                if (_disciplines == null)
                {
                    _disciplines = new EntitySet<Discipline>(OnDisciplinesAdd, OnDisciplinesRemove);
                    _disciplines.SetSource(TeacherDisciplines.Select(c => c.Discipline));
                }
                return _disciplines;
            }
            set
            {
                _disciplines.Assign(value);
            }
        }
    }
}
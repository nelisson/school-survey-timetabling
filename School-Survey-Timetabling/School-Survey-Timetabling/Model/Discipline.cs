using System.Linq;

namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data.SqlTypes;
    using System.Diagnostics.Contracts;

    [Table(Name = "Disciplinas")]
    public class Discipline : AssociatedSchoolEntity<Employee, Discipline>
    {
        public Discipline() : base(false)
        {
            //_teacherDisciplines = new EntitySet<TeacherDiscipline>(e => { e.Discipline = this; }, e => { e.Discipline = null; });
            _blocks = new EntitySet<Block>();
        }

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        protected internal override long Id { get; set; }

        [Column(Name = "CargaHoraria")]
        private DateTime SqlWorkload { get; set; }
        public TimeSpan Workload
        {
            get { return SqlWorkload - SqlDateTime.MinValue.Value; }
            set
            {
                DateTime dateTime = SqlDateTime.MinValue.Value;
                SqlWorkload = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                           value.Hours, value.Minutes, value.Seconds);
                OnPropertyChanged("Workload");
            }
        }

        private string _name;
        [Column(Name = "Nome")]
        public string Name
        {
            get { return _name; }
            set
            {
                Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(value));
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private EntitySet<Block> _blocks;
        [Association(OtherKey = "Id", Storage = "_blocks")]
        public EntitySet<Block> Blocks
        {
            get { return _blocks; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _blocks.Assign(value);
                OnPropertyChanged("Blocks");
            }
        }

        /*
        private readonly EntitySet<TeacherDiscipline> _teacherDisciplines;
        [Association(Storage = "_teacherDisciplines", OtherKey = "DisciplineId", ThisKey="Id")]
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
        */

        private void OnTeachersAdd(Employee entity)
        {
            Association.Add(new TeacherDiscipline { Second = this, First = entity });
        }

        private void OnTeachersRemove(Employee entity)
        {
            var teacherDiscipline = Association.FirstOrDefault(
                c => c.IdSecond == Id
                && c.IdFirst == entity.Id);
            Association.Remove(teacherDiscipline);
        }

        private EntitySet<Employee> _teachers;

        public EntitySet<Employee> Teachers
        {
            get
            {
                if (_teachers == null)
                {
                    _teachers = new EntitySet<Employee>(OnTeachersAdd, OnTeachersRemove);
                    _teachers.SetSource(Association.Select(c => c.First));
                }
                return _teachers;
            }
            set
            {
                _teachers.Assign(value);
            }
        }
    }
}
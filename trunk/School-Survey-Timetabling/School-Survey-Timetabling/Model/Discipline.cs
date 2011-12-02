using System.Linq;

namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data.SqlTypes;
    using System.Diagnostics.Contracts;

    [Table(Name = "Disciplinas")]
    public class Discipline : SchoolEntity
    {

        public Discipline()
        {
            _teacherDisciplines = new EntitySet<TeacherDiscipline>(e => { e.Discipline = this; }, e => { e.Discipline = null; });
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

        private EntityRef<Block> _block;
        [Association(OtherKey = "Id", Storage = "_block")]
        public Block Block
        {
            get { return _block.Entity; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _block.Entity = value;
                OnPropertyChanged("Block");
            }
        }

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

        private void OnTeachersAdd(Teacher entity)
        {
            TeacherDisciplines.Add(new TeacherDiscipline { Discipline = this, Teacher = entity });
        }

        private void OnTeachersRemove(Teacher entity)
        {
            var teacherDiscipline = TeacherDisciplines.FirstOrDefault(
                c => c.DisciplineId == Id
                && c.TeacherId == entity.Id);
            TeacherDisciplines.Remove(teacherDiscipline);
        }

        private EntitySet<Teacher> _teachers;

        public EntitySet<Teacher> Teachers
        {
            get
            {
                if (_teachers == null)
                {
                    _teachers = new EntitySet<Teacher>(OnTeachersAdd, OnTeachersRemove);
                    _teachers.SetSource(TeacherDisciplines.Select(c => c.Teacher));
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
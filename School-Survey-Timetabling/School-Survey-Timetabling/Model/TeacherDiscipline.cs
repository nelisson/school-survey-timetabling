using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Table(Name="ProfessorDisciplina")]
    public class TeacherDiscipline
    {
        [Column(IsPrimaryKey=true)]
        public long TeacherId { get; set; }
        [Column(IsPrimaryKey = true)]
        public long DisciplineId { get; set; }

        private EntityRef<Discipline> _discipline;

        private EntityRef<Teacher> _teacher;


        [AssociationAttribute(Storage = "_discipline", ThisKey = "DisciplineId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        public Discipline Discipline
        {
            get
            {
                return _discipline.Entity;
            }
            set
            {
                var previousValue = _discipline.Entity;
                if (previousValue == value && _discipline.HasLoadedOrAssignedValue) return;
                
                if (previousValue != null)
                {
                    _discipline.Entity = null;
                    previousValue.TeacherDisciplines.Remove(this);
                }
                _discipline.Entity = value;
                if (value != null)
                {
                    value.TeacherDisciplines.Add(this);
                    DisciplineId = value.Id;
                }
                else
                {
                    DisciplineId = default(int);
                }
            }
        }

        [AssociationAttribute(Storage = "_teacher", ThisKey = "TeacherId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        public Teacher Teacher
        {
            get
            {
                return _teacher.Entity;
            }
            set
            {
                var previousValue = _teacher.Entity;
                if (previousValue == value && _teacher.HasLoadedOrAssignedValue) return;

                if ((previousValue != null))
                {
                    _teacher.Entity = null;
                    previousValue.TeacherDisciplines.Remove(this);
                }
                _teacher.Entity = value;
                if ((value != null))
                {
                    value.TeacherDisciplines.Add(this);
                    TeacherId = value.Id;
                }
                else
                {
                    TeacherId = default(int);
                }
            }
        }
    }
}

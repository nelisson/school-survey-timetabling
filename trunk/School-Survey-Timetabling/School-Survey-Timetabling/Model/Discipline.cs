using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlTypes;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "Disciplinas")]
    internal class Discipline : SchoolEntity
    {
        private EntityRef<Teacher> _teacher;

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private int Id { get; set; }

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
            }
        }

        [Column(Name = "Nome")]
        public string Name { get; set; }

        private EntityRef<Block> _block;
        [Association(OtherKey = "Id", Storage = "_block")]
        public Block Block
        {
            get { return _block.Entity; }
            set { _block.Entity = value; }
        }

        public Teacher Teacher
        {
            get { return _teacher.Entity; }
            set { _teacher.Entity = value; }
        }
    }
}
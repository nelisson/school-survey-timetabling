namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data.SqlTypes;
    using System.Diagnostics.Contracts;

    [Table(Name = "Disciplinas")]
    internal class Discipline : SchoolEntity
    {
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

        private EntityRef<Teacher> _teacher;
        public Teacher Teacher
        {
            get { return _teacher.Entity; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _teacher.Entity = value;
                OnPropertyChanged("Teacher");
            }
        }
    }
}
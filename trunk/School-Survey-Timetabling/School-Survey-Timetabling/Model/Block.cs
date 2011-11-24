namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data.SqlTypes;
    using System.Diagnostics.Contracts;

    [Table(Name = "Blocos")]
    [InheritanceMapping(Code = BlockLength.Short, Type = typeof (ShortBlock), IsDefault = true)]
    [InheritanceMapping(Code = BlockLength.Long, Type = typeof (LongBlock))]
    internal abstract partial class Block : SchoolEntity
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private int Id { get; set; }

        private DateTime _start;
        [Column(Name = "Inicio")]
        public DateTime Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        [Column(Name = "Tamanho", IsDiscriminator = true)]
        protected BlockLength Length { get; set; }

        [Column(Name = "Duracao")]
        private DateTime SqlDuration { get; set; }
        public TimeSpan Duration
        {
            get { return SqlDuration - SqlDateTime.MinValue.Value; }
            set
            {
                DateTime dateTime = SqlDateTime.MinValue.Value;
                SqlDuration = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                           value.Hours, value.Minutes, value.Seconds);
                OnPropertyChanged("Duration");
            }
        }

        private EntityRef<Discipline> _discipline;
        [Association(OtherKey = "Id", Storage = "_discipline")]
        public Discipline Discipline
        {
            get { return _discipline.Entity; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _discipline.Entity = value;
                OnPropertyChanged("Discipline");
            }
        }
    }
}
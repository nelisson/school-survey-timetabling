namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq.Mapping;
    using System.Data.SqlTypes;
    using System.Diagnostics.Contracts;

    [Table(Name = "Servidores")]
    [InheritanceMapping(Code = EmployeeRole.Administrator, Type = typeof (Administrator), IsDefault = true)]
    [InheritanceMapping(Code = EmployeeRole.Teacher, Type = typeof (Teacher))]
    [InheritanceMapping(Code = EmployeeRole.Volant, Type = typeof (Volant))]
    public abstract partial class Employee : SchoolEntity
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        protected internal override long Id { get; set; }

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

        [Column(Name = "Funcao", IsDiscriminator = true)]
        protected EmployeeRole Role { get; set; }

        [Column(Name = "CargaHoraria")]
        private DateTime SqlWorkload { get; set; }
        public TimeSpan Workload
        {
            get { return SqlWorkload - SqlDateTime.MinValue.Value; }
            set
            {
                var sqlMinDate = SqlDateTime.MinValue.Value;
                SqlWorkload = new DateTime(sqlMinDate.Year, sqlMinDate.Month, sqlMinDate.Day,
                                           value.Hours, value.Minutes, value.Seconds);
                OnPropertyChanged("Workload");
            }
        }
    }
}
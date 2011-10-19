using System;
using System.Data.Linq.Mapping;
using System.Data.SqlTypes;

namespace School_Survey_Timetabling.Model
{
    enum Role
    {
        Administrator,
        Teacher,
        Volant,
    }

    [Table(Name = "Servidores")]
    [InheritanceMapping(Code = Role.Administrator, Type = typeof(Administrator), IsDefault = true)]
    [InheritanceMapping(Code = Role.Teacher, Type = typeof (Teacher))]
    [InheritanceMapping(Code = Role.Volant, Type = typeof (Volant))]
    abstract class Employee
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name = "Nome")]
        public string Name { get; set; }

        [Column(Name = "Funcao", IsDiscriminator = true)]
        protected Role Role { get; set; }

        [Column(Name = "CargaHoraria")]
        private DateTime SqlWorkload { get; set; }

        public TimeSpan Workload
        {
            get { return SqlWorkload - SqlDateTime.MinValue.Value; }
            set
            {
                var dateTime = SqlDateTime.MinValue.Value;
                SqlWorkload = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                           value.Hours, value.Minutes, value.Seconds);
            }
        }
    }
}

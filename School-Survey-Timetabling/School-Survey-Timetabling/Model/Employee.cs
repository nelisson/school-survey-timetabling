using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace School_Survey_Timetabling.Model
{
    enum Role
    {
        Administrator,
        Teacher,
        Volant,
    }

    [Table(Name = "Funcionarios")]
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
        public Role Role { get; set; }

        [Column(Name="CargaHoraria")]
        public TimeSpan Workload { get; set; }
    }
}

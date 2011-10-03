using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace School_Survey_Timetabling.Model
{
    [Table(Name="Disciplinas")]
    class Discipline
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private long Id { get; set; }

        [Column(Name="CargaHoraria")]
        public TimeSpan Workload { get; set; }

        [Column(Name="Nome")]
        public string Name { get; set; }

        [Column(Name="Bloco")]
        public Block Block { get; set; }

        //TODO: modelar prioridade
    }
}

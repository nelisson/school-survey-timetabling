﻿using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlTypes;

namespace School_Survey_Timetabling.Model
{
    internal enum BlockLength
    {
        Long,
        Short,
    }

    [Table(Name = "Blocos")]
    [InheritanceMapping(Code = BlockLength.Short, Type = typeof (ShortBlock), IsDefault = true)]
    [InheritanceMapping(Code = BlockLength.Long, Type = typeof (LongBlock))]
    internal abstract class Block : SchoolEntity
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private int Id { get; set; }

        [Column(Name = "Inicio")]
        public DateTime Start { get; set; }

        [Column(Name = "Duracao")]
        private DateTime SqlDuration { get; set; }

        [Column(Name = "Tamanho", IsDiscriminator = true)]
        protected BlockLength Length { get; set; }

        public TimeSpan Duration
        {
            get { return SqlDuration - SqlDateTime.MinValue.Value; }
            set
            {
                DateTime dateTime = SqlDateTime.MinValue.Value;
                SqlDuration = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                           value.Hours, value.Minutes, value.Seconds);
            }
        }

        private EntityRef<Discipline> _discipline;
        [Association(OtherKey = "Id", Storage = "_discipline")]
        public Discipline Discipline
        {
            get { return _discipline.Entity; }
            set { _discipline.Entity = value; }
        }
    }
}
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics.Contracts;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "Salas")]

    internal class Room : SchoolEntity, IDataErrorInfo
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        private int Id { get; set; }

        private string _code;

        [Column(Name = "Numero")]
        public string Code
        {
            get { return _code; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        private EntityRef<Class> _class;
        [Association(OtherKey= "Id", Storage = "_class")]
        public Class Class
        {
            get { return _class.Entity; }
            set
            {
                _class.Entity = value;
                OnPropertyChanged("Class");
            }
        }

        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
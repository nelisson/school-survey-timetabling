namespace School_Survey_Timetabling.Model
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Diagnostics.Contracts;

    [Table(Name = "Salas")]
    public class Room : SchoolEntity
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        protected internal override long Id { get; set; }

        private string _code;
        [Column(Name = "Numero")]
        public string Code
        {
            get { return _code; }
            set
            {
                Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(value));
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
                Contract.Requires<ArgumentNullException>(value != null);
                _class.Entity = value;
                OnPropertyChanged("Class");
            }
        }
    }
}
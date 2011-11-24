using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Table(Name = "Salas")]
    internal class Room : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
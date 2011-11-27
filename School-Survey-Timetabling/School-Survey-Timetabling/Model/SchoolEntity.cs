namespace School_Survey_Timetabling.Model
{
    using System.ComponentModel;
    using System.Data.Linq.Mapping;

    public abstract class SchoolEntity : INotifyPropertyChanged
    {
        protected abstract long Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

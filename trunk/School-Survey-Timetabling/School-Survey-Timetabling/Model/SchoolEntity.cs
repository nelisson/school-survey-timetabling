namespace School_Survey_Timetabling.Model
{
    using System.ComponentModel;

    public abstract class SchoolEntity : INotifyPropertyChanged
    {
        protected internal abstract long Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

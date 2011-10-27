using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Database(Name = "Escola")]
    internal class EmefFatima : DataContext
    {
        private const string ConnectionString = "database.sdf";

        public EmefFatima()
            : base(ConnectionString)
        {
            if (!DatabaseExists())
                CreateDatabase();
        }

        public Table<Discipline> Disciplines
        {
            get { return GetTable<Discipline>(); }
        }

        public Table<Employee> Employees
        {
            get { return GetTable<Employee>(); }
        }

        public Table<Block> Blocks
        {
            get { return GetTable<Block>(); }
        }

        public Table<Class> Classes
        {
            get { return GetTable<Class>(); }
        }

        public Table<CycleYear> CycleYears
        {
            get { return GetTable<CycleYear>(); }
        }

        public Table<Room> Rooms
        {
            get { return GetTable<Room>(); }
        }
    }
}
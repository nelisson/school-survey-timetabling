using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Database(Name="Escola")]
    public class EmefFatima : DataContext
    {
        const string ConnectionString = "database.sdf";

        public EmefFatima()
            : base(ConnectionString)
        {
            if (!DatabaseExists())
                CreateDatabase();
        }
    }
}

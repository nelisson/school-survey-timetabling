using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace School_Survey_Timetabling.Model
{
    [Database(Name="Escola")]
    internal class EmefFatima : DataContext
    {
        const string ConnectionString = "database.sdf";
        //TODO: Botei uma tabela qualquer, só pra ver funcionar :D
        public Table<Room> Classes;

        public EmefFatima()
            : base(ConnectionString)
        {
            if (!DatabaseExists())
                CreateDatabase();
        }
    }
}

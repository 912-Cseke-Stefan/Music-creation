using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MauiApp1.Repository
{
    public class MusigTagRepository : IMusicTagRepository
    {
        private SqlConnection conn;

        private string getConnectionString()
        {
            return "Data Source=DESKTOP-A6LKOMJ\\SQLEXPRESS;" +
                "Initial Catalog=CargoShipGlobal;Integrated Security=true;";
        }

        public MusigTagRepository() 
        {
            conn = new SqlConnection(getConnectionString());
        }

        public void add(MusicTag elem)
        {

        }

        public MusicTag? search(int id)
        {
            return null;
        }

        public MusicTag[] getAll()
        {
            return [];
        }
    }
}

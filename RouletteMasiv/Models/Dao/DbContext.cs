using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteMasiv.Models.Dao
{
    public class DbContext
    {
        private const string ConnectionString = "Server=DESKTOP-MT1Q6KV\\SQLEXPRESS;DataBase=ROULETTEMASIV;Integrated Security=true";
        protected SqlConnection conectionDB = new SqlConnection(ConnectionString);
    }
}

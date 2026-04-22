using Microsoft.Data.SqlClient;
using System.Data;

namespace DSW_I_Grupo_2_CRM.Data
{
    public class DBConnectionFactory
    {
        private readonly string _connectionString;

        public DBConnectionFactory(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conn");
        }

        public IDbConnection CreateConnection() 
        {
            return new SqlConnection(_connectionString);
        }
    }
}

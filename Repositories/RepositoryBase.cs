using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = @"server=localhost;user=root;password=;database=MyApp";
            //_connectionString = @"server=localhost;user=root;password=;database=MyApp";
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}

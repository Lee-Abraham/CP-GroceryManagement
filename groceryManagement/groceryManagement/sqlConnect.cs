using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace groceryManagement
{
    public abstract class sqlConnect
    {

        protected string connectionString = "Server=localhost;Database=grocerymanagement;User Id=root;Password=password;";

        public string GetConnectionString()
        {
            return connectionString;
        }

    }
}

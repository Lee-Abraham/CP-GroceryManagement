using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace groceryManagement
{
    /// <summary>
    /// Abstract class for managing database connections.
    /// Provides a connection string for accessing the grocery management database.
    /// </summary>
    public abstract class SqlConnect
    {
        // Connection string should ideally be retrieved from a secure config file
        protected readonly string connectionString = "Server=localhost;Database=grocerymanagement;User Id=root;Password=password;";

        //-----------------------------------------------------------------------//
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>Returns the database connection string.</returns>
        public string GetConnectionString()
        {
            return connectionString;
        }

        //-----------------------------------------------------------------------//
        // Constructor
        protected SqlConnect()
        {
        }
    }
}

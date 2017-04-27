using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BugTrackerDAL
{
    public class DB
    {
        /// <summary>
        /// connection string to database
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string connectionString
                    = ConfigurationManager.ConnectionStrings["BugTrackerConnection"].ConnectionString; //huh?

                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(connectionString);
                stringBuilder.ApplicationName = ApplicationName ?? stringBuilder.ApplicationName;
                stringBuilder.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : stringBuilder.ConnectTimeout;

                return stringBuilder.ToString();
            }
        }
        
        /// <summary>
        /// Gets a sql connection, accesses database
        /// </summary>
        /// <returns>connection</returns>
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }

        /// <summary>
        /// Overrides the connection timeout
        /// </summary>
        public static int ConnectionTimeout { get; set; }

        /// <summary>
        /// Property used to override the name of the application
        /// </summary>
        public static string ApplicationName { get; set; }

        /// <summary>
        /// A special method to get and parse SQLServer Error Messages
        /// </summary>
        /// <param name="exception"></param>
        public static string DisplaySqlErrors(SqlException exception)
        {
            //Copied from here: http://stackoverflow.com/questions/10809529/how-can-i-get-the-return-value-from-sql-server-system-message
            string SQLMessages = "ERROR: ";
            foreach (SqlError err in exception.Errors)
            {
                SQLMessages += err.Message + "\n";
            }
            return SQLMessages;
        }
    }
}


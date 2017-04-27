using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BugTrackerDAL
{
    public class StatusCodes
    {
        public static List<StatusCode> GetList()
        {

            List<StatusCode> statuscodes = new List<StatusCode>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"GetAllStatusCodes";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        StatusCode e = new StatusCode();
                        e.Load(reader);
                        statuscodes.Add(e);
                    }
                }
            }

            return statuscodes;
        }
    }

    public class StatusCode
    {
        public int StatusCodeID { get; set; }
        public string StatusCodeDesc { get; set; }
       
        /// <summary>
        /// Load Staus codes
        /// </summary>
        /// <param name="reader"></param>
        public void Load(SqlDataReader reader)
        {
            StatusCodeID = Int32.Parse(reader["StatusCodeID"].ToString());
            StatusCodeDesc = reader["StatusCodeDesc"].ToString();
            
        }

    }//end StatusCode class
}

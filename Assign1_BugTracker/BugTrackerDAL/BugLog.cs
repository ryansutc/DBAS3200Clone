using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BugTrackerDAL
{
    public class BugLogs
    {
        /// <summary>
        /// Get a List of BugLogs for a Bug
        /// </summary>
        /// <param name="BugID">BugID number</param>
        /// <returns></returns>
        public List<BugLog> GetList(int BugID) 
        {

            List<BugLog> BugLogList = new List<BugLog>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"ListAllBugLogs";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BugLog BugLog  = new BugLog();
                        BugLog.Load(reader);
                        BugLogList.Add(BugLog);
                    }
                }
            }

            return BugLogList;
        }

        /// <summary>
        /// Add a new bug log record
        /// </summary>
        /// <param name="StatusCodeID">StatusCodeID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="BugLogDesc">BugLogDesc</param>
        /// <param name="BugID">BugID</param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public static bool AddNewBugLog(int StatusCodeID, int UserID, String BugLogDesc, int BugID, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"AddBugLog";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("StatusCodeID", System.Data.SqlDbType.Int);
                        parameter1.Value = StatusCodeID;
                        command.Parameters.Add(parameter1);

                        SqlParameter parameter2 = new SqlParameter("UserID", System.Data.SqlDbType.Int);
                        parameter2.Value = UserID;
                        command.Parameters.Add(parameter2);

                        //used for concurrency check (manual)
                        SqlParameter parameter3 = new SqlParameter("BugLogDesc", System.Data.SqlDbType.VarChar, 100);
                        parameter3.Value = BugLogDesc;
                        command.Parameters.Add(parameter3);

                        SqlParameter parameter4 = new SqlParameter("BugID", System.Data.SqlDbType.Int);
                        parameter4.Value = BugID;
                        command.Parameters.Add(parameter4);

                        command.ExecuteNonQuery();
                        StatusMsg = "New bug successfully added";
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        StatusMsg = DB.DisplaySqlErrors(ex);
                        return false;

                    }
                    catch (Exception e)
                    {
                        StatusMsg = e.Message;
                        return false;
                    }
                }
            }
        }
    }

    public class BugLog
    {
        public int BugLogID { get; set; }
        public DateTime BugLogDate { get; set; }
        public int StatusCodeID { get; set; }
        public int UserID { get; set; }
        public string BugLogDesc { get; set; }
        public int BugID { get; set; }


        /// <summary>
        /// load a bug record
        /// </summary>
        /// <param name="reader"></param>
        public void Load(SqlDataReader reader)
        {
            BugLogID = Int32.Parse(reader["BugLogID"].ToString());
            BugLogDate = Convert.ToDateTime(reader["BugLogDate"].ToString());
            StatusCodeID = Int32.Parse(reader["StatusCodeID"].ToString());
            UserID = Int32.Parse(reader["UserID"].ToString());
            BugLogDesc = reader["BugLogDesc"].ToString();
            BugID = Int32.Parse(reader["BugID"].ToString());
        }
       
        /// <summary>
        /// return a datatable of the bug records 
        /// </summary>
        /// <param name="BugID">bugid for the data</param>
        /// <returns></returns>
        public static DataTable GetBugLogs(int BugID)
        {
            DataTable table = new DataTable("BugLog"); //Buglog table

            SqlDataAdapter dataAdapter = null;

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"ListAllBugLogsSelectedFields";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("BugID", SqlDbType.Int));
                    command.Parameters["BugID"].Value = BugID;

                    using (dataAdapter = new SqlDataAdapter(command))
                    {
                        int result = dataAdapter.Fill(table);
                    }

                }
            }

            return table;
        }

    }//end application class
}

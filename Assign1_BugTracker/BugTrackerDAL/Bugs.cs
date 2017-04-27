using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BugTrackerDAL
{
    public class Bugs
    {
        static List<Bug> bugsList;
        static List<Bug> filteredbugsList;

        /// <summary>
        /// Get List of all Bugs
        /// </summary>
        /// <returns></returns>
        public static List<Bug> GetList()
        {

            bugsList = new List<Bug>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"GetAllBugs";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Bug e = new Bug();
                        e.Load(reader);
                        bugsList.Add(e);
                    }
                }
            }

            return bugsList;
        }
       
        /// <summary>
        /// Generate a list of Bugs from an application object and status code
        /// Based on makeing a filtered copy of a list of applications
        /// </summary>
        /// <param name="app"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Bug> GetFilteredList(Application app, int status, bool Refresh)
        {
            if (bugsList == null || Refresh == true) 
            {
                GetList(); //get full list from database on orig load or save action of new data
            }
            filteredbugsList = new List<Bug>();
            foreach( Bug bug in bugsList)
            {
                if (bug.AppID == app.AppID)
                {
                    if (status != 0) //0 = All Statuses
                    {
                        if (bug.StatusCodeID == status)
                        {
                            filteredbugsList.Add(bug);
                        }
                    }
                    else //No Status Filter
                    {
                        filteredbugsList.Add(bug);
                    }
                }
            }

            return filteredbugsList;
        }

        /// <summary>
        /// Add a new bug record
        /// </summary>
        /// <param name="AppID">UserID</param>
        /// <param name="UserID">UserID</param>
        /// <param name="BugDesc">BugDesc</param>
        /// <param name="BugDetails">BugDetails</param>
        /// <param name="RepSteps">RepSteps</param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public static bool AddNewBug(int AppID, int UserID, string BugDesc, 
            String BugDetails, String RepSteps, out string StatusMsg)
        {
            // Assume all new bugs will be set to unassigned
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"AddBug";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add("@AppID", System.Data.SqlDbType.Int).Value = AppID;
                        command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = UserID;
                        command.Parameters.Add("@BugDesc", System.Data.SqlDbType.VarChar, 255).Value = BugDesc;
                        command.Parameters.Add("@BugDetails", System.Data.SqlDbType.VarChar, 1000).Value = BugDetails;
                        command.Parameters.Add("@RepSteps", System.Data.SqlDbType.VarChar, 1000).Value = RepSteps;

                        command.ExecuteNonQuery();
                        StatusMsg = "Successfully added bug";
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

    }//End Bugs class

    public class Bug
    {
        public int BugID { get; set; }
        public int AppID { get; set; }
        public int UserID { get; set; }
        public int? BugSignOff { get; set; } //nullable
        public DateTime BugDate { get; set; }
        public string BugDesc { get; set; }
        public string BugDetails { get; set; }
        public string RepSteps { get; set; }
        public DateTime? FixDate { get; set; } //nullable
        public int StatusCodeID { get; set; } //this is the latest StatusCode
        public string StatusCodeDesc { get; set; }
        public DateTime? LastUpdated { get; set; } //date Status Code updated

        /// <summary>
        /// Load Bug data from reader / database
        /// </summary>
        /// <param name="reader"></param>
        public void Load(SqlDataReader reader)
        {
            BugID = Int32.Parse(reader["BugID"].ToString());
            AppID = Int32.Parse(reader["AppID"].ToString());
            UserID = Int32.Parse(reader["UserID"].ToString());
            
            BugDate = Convert.ToDateTime(reader["BugDate"].ToString());
            BugDesc = reader["BugDesc"].ToString();
            BugDetails = reader["BugDetails"].ToString();
            RepSteps = reader["RepSteps"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("FixDate")))
            {
                FixDate = reader.GetDateTime(reader.GetOrdinal("FixDate"));
            }
            else
            {
                FixDate = null;
            }
            //DateTime.TryParse(reader["FixDate"].ToString(), out dt);
           // FixDate = dt;

            string tempBugSignOff = reader["BugSignOff"].ToString();
            //int.TryParse(reader["BugSignOff"].ToString(), out tmpint);
            if (tempBugSignOff != "")
            {
                BugSignOff = Int32.Parse(tempBugSignOff);
            }
         

            StatusCodeID = Int32.Parse(reader["StatusCodeID"].ToString()); //HOW TO PROTECT
            StatusCodeDesc = reader["StatusCodeDesc"].ToString();

            DateTime dt2;
            DateTime.TryParse(reader["LastUpdated"].ToString(), out dt2);
            LastUpdated = dt2;
        }

        /// <summary>
        /// Update Existing bug
        /// </summary>
        /// <param name="BugID">BugID</param>
        /// <param name="BugSignOff">BugSignOff</param>
        /// <param name="BugDate">BugDate</param>
        /// <param name="BugDesc">BugDesc</param>
        /// <param name="BugDetails">BugDetails</param>
        /// <param name="RepSteps">RepSteps</param>
        /// <param name="FixDate">FixDate</param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public bool UpdateBug(int BugID, int? BugSignOff, DateTime BugDate, 
            string BugDesc, string BugDetails, string RepSteps, DateTime? FixDate, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UpdateBug";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("BugId", System.Data.SqlDbType.VarChar);
                        parameter1.Value = BugID;
                        command.Parameters.Add(parameter1);

                        SqlParameter parameter2 = new SqlParameter("BugSignOff", System.Data.SqlDbType.Int);
                        parameter2.Value = ((object)BugSignOff) ?? DBNull.Value;
                        command.Parameters.Add(parameter2);

                        SqlParameter parameter3 = new SqlParameter("BugDate", System.Data.SqlDbType.DateTime);
                        parameter3.Value = BugDate;
                        command.Parameters.Add(parameter3);

                        SqlParameter parameter4 = new SqlParameter("BugDesc", System.Data.SqlDbType.VarChar);
                        parameter4.Value = BugDesc;
                        command.Parameters.Add(parameter4);

                        SqlParameter parameter5 = new SqlParameter("BugDetails", System.Data.SqlDbType.VarChar);
                        parameter5.Value = BugDetails;
                        command.Parameters.Add(parameter5);

                        SqlParameter parameter6 = new SqlParameter("RepSteps", System.Data.SqlDbType.VarChar);
                        parameter6.Value = RepSteps;
                        command.Parameters.Add(parameter6);

                        //null values might throw error?
                        SqlParameter parameter7 = new SqlParameter("FixDate", System.Data.SqlDbType.DateTime);
                        parameter7.Value = ((object)FixDate) ?? DBNull.Value;
                        command.Parameters.Add(parameter7);

                        command.ExecuteNonQuery();
                        StatusMsg = "Successfully updated record";
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

        /// <summary>
        /// Delete a bug
        /// </summary>
        /// <param name="BugId">bugid of  record to delete</param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public static bool DeleteBug(int BugId, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DeleteBug";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("BugId", System.Data.SqlDbType.VarChar);
                        parameter1.Value = BugId;
                        command.Parameters.Add(parameter1);

                        command.ExecuteNonQuery();
                        StatusMsg = "Successfully deleted bug";
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
}

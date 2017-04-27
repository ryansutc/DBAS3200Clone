using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BugTrackerDAL
{

    public class Applications
    {
        /// <summary>
        /// Get list of applications
        /// </summary>
        /// <returns></returns>
        public List<Application> GetList()
        {

            List<Application> applications = new List<Application>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"GetAllApplications";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Application e = new Application();
                        e.Load(reader);
                        applications.Add(e);
                    }
                }
            }

            return applications;
        }

        /// <summary>
        /// Add a new Application to Database
        /// </summary>
        /// <param name="AppName"></param>
        /// <param name="AppVersion"></param>
        /// <param name="AppDesc"></param>
        public static bool AddNewApp(string AppName, String AppVersion, String AppDesc, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"AddApplication";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("AppName", System.Data.SqlDbType.VarChar);
                        parameter1.Value = AppName;
                        command.Parameters.Add(parameter1);

                        SqlParameter parameter2 = new SqlParameter("AppVersion", System.Data.SqlDbType.VarChar, 100);
                        parameter2.Value = AppVersion;
                        command.Parameters.Add(parameter2);

                        //used for concurrency check (manual)
                        SqlParameter parameter3 = new SqlParameter("AppDesc", System.Data.SqlDbType.VarChar, 100);
                        parameter3.Value = AppDesc;
                        command.Parameters.Add(parameter3);

                        command.ExecuteNonQuery();
                        StatusMsg = "New App Successfully added";
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
        /// Delete app record
        /// </summary>
        /// <param name="AppId"></param>
        /// <param name="StatusMsg"></param>
        /// <returns></returns>
        public static bool DeleteApp(int AppId, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DeleteApplication";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("AppId", System.Data.SqlDbType.VarChar);
                        parameter1.Value = AppId;
                        command.Parameters.Add(parameter1);

                        command.ExecuteNonQuery();
                        StatusMsg = "Successfully Deleted App";
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
        /// update existing app
        /// </summary>
        /// <param name="AppId">AppId</param>
        /// <param name="AppName">AppName</param>
        /// <param name="AppVers">AppVers</param>
        /// <param name="AppDesc">AppDesc</param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public bool UpdateApp(int AppId, string AppName, string AppVers, string AppDesc, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UpdateApplication";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("AppId", System.Data.SqlDbType.VarChar);
                        parameter1.Value = AppId;
                        command.Parameters.Add(parameter1);

                        SqlParameter parameter2 = new SqlParameter("AppName", System.Data.SqlDbType.VarChar);
                        parameter2.Value = AppName;
                        command.Parameters.Add(parameter2);

                        SqlParameter parameter3 = new SqlParameter("AppVersion", System.Data.SqlDbType.VarChar);
                        parameter3.Value = AppVers;
                        command.Parameters.Add(parameter3);

                        SqlParameter parameter4 = new SqlParameter("AppDesc", System.Data.SqlDbType.VarChar);
                        parameter4.Value = AppDesc;
                        command.Parameters.Add(parameter4);

                        command.ExecuteNonQuery();

                        StatusMsg = "App Successfully Updated";
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
        /// Get a selected app by Id
        /// </summary>
        /// <param name="AppId">AppId</param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public static Application GetAppByID(int AppId, string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"GetApplicationById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("AppId", System.Data.SqlDbType.Int);
                        parameter1.Value = AppId;
                        command.Parameters.Add(parameter1);

                        SqlDataReader reader = command.ExecuteReader();
                        Application e = new Application();
                        while (reader.Read())
                        {
                            e.Load(reader);
                        }
                        return e;
                    }
                    catch (SqlException ex)
                    {
                        StatusMsg = DB.DisplaySqlErrors(ex);
                        return null;
                    }
                    catch (Exception e)
                    {
                        StatusMsg = e.Message;
                        return null;
                    }

                }
            }
        }
    }//end class applications


    public class Application
    {
        public int AppID { get; set; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string AppDesc { get; set; }


        /// <summary>
        /// Load Application data f rom databawe
        /// </summary>
        /// <param name="reader"></param>
        public void Load(SqlDataReader reader)
        {
            AppID = Int32.Parse(reader["AppID"].ToString());
            AppName = reader["AppName"].ToString();
            AppVersion = reader["AppVersion"].ToString();
            AppDesc = reader["AppDesc"].ToString();
        }
        
    }//end application class
}

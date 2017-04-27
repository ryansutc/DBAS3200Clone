using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BugTrackerDAL
{
    /// <summary>
    /// Get all Users from database into a List
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Get all users in a list
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
           List<User> UsersList = new List<User>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"ListAllUsers";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User User = new User();
                        User.Load(reader);
                        UsersList.Add(User);
                    }
                }
            }

            return UsersList;
        }

        /// <summary>
        /// Add a new user to datbase
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserEmail"></param>
        /// <param name="UserTel"></param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public static bool AddNewUser(string UserName, String UserEmail, String UserTel, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"AddUser";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("UserName", System.Data.SqlDbType.VarChar);
                        parameter1.Value = UserName;
                        command.Parameters.Add(parameter1);

                        SqlParameter parameter2 = new SqlParameter("UserEmail", System.Data.SqlDbType.VarChar, 100);
                        parameter2.Value = UserEmail;
                        command.Parameters.Add(parameter2);

                        //used for concurrency check (manual)
                        SqlParameter parameter3 = new SqlParameter("UserTel", System.Data.SqlDbType.VarChar, 12);
                        parameter3.Value = UserTel;
                        command.Parameters.Add(parameter3);

                        command.ExecuteNonQuery();
                        StatusMsg = "Successfully Added New User"; //get SQL Server Message
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
        /// Update existing user record
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserName"></param>
        /// <param name="UserEmail"></param>
        /// <param name="UserTel"></param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public static bool UpdateUser(int UserID, string UserName, String UserEmail, String UserTel, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"UpdateUser";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("UserID", System.Data.SqlDbType.Int);
                        parameter1.Value = UserID;
                        command.Parameters.Add(parameter1);

                        SqlParameter parameter2 = new SqlParameter("UserName", System.Data.SqlDbType.VarChar);
                        parameter2.Value = UserName;
                        command.Parameters.Add(parameter2);

                        SqlParameter parameter3 = new SqlParameter("UserEmail", System.Data.SqlDbType.VarChar);
                        parameter3.Value = UserEmail;
                        command.Parameters.Add(parameter3);

                        SqlParameter parameter4 = new SqlParameter("UserTel", System.Data.SqlDbType.VarChar);
                        parameter4.Value = UserTel;
                        command.Parameters.Add(parameter4);

                        command.ExecuteNonQuery();

                        StatusMsg = "User Successfully Updated";
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
        /// Delete an existing user
        /// </summary>
        /// <param name="UserId">selected userid</param>
        /// <param name="StatusMsg">message that will return from database</param>
        /// <returns></returns>
        public static bool DeleteUser(int UserId, out string StatusMsg)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = @"DeleteUser";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("UserId", System.Data.SqlDbType.Int);
                        parameter1.Value = UserId;
                        command.Parameters.Add(parameter1);

                        command.ExecuteNonQuery();
                        StatusMsg = "Successfully Deleted User";
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

    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserTel { get; set; }
        public string IsAdmin { get; set; }


        /// <summary>
        /// Load a User from a sql reader
        /// </summary>
        /// <param name="reader"></param>
        public void Load(SqlDataReader reader)
        {
            UserID = Int32.Parse(reader["UserID"].ToString());
            UserName = reader["UserName"].ToString();
            UserEmail = reader["UserEmail"].ToString();
            UserTel = reader["UserTel"].ToString();
            IsAdmin = reader["IsAdmin"].ToString(); //Y, N
        }

        /// <summary>
        /// Validate that user exists, is admin
        /// </summary>
        /// <param name="UserName">name to search</param>
        /// <returns></returns>
        public static User ValidateUserName(string UserName)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"ValidateUser";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@UserName", SqlDbType.Text);
                    command.Parameters["@UserName"].Value = UserName;

                    SqlDataReader reader = command.ExecuteReader();

                    User user = new User();
                   
                      if (reader.HasRows)
                      {
                          while (reader.Read())
                          {
                              user.Load(reader);
                          }
                      }
                      else
                      {
                          user = null;
                      }

                   return user;                    
                }

            }
        }

    }
   
}

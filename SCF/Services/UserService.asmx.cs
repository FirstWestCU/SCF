using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coop
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {
        /// <summary>
        /// Authenticates an existing user with the supplied email and password.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="pass">The user's password.</param>
        /// <returns>This method will return the full user object if the authentication was successfull. If the
        /// authentication failed, it will simply return an AccessLevel of 0. If the user exists and the authentication
        /// was successfull, but the account has not been assigned an access level, the entire user object is returned
        /// with an access level of 0.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public User AuthenticateUser(string email, string pass)
        {
            User requestingUser = new User();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUserIDAndPass", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (BCrypt.CheckPassword(pass, reader["Pass"].ToString()))
                        {
                            int userID = Convert.ToInt32(reader["ID"]);
                            requestingUser.LoadDetails(userID);
                        }
                    }
                }
            }

            return requestingUser;
        }

        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="userHash">The currently logged on user's hash value. For now, this parameter is a dummy parameter.</param>
        /// <param name="name">The new user's full name.</param>
        /// <param name="email">The new user's email address.</param>
        /// <param name="pass">The new user's password.</param>
        /// <param name="creditUnion">The ID value corresponding to the new user's credit union.</param>
        /// <returns>The newly created user object.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public User CreateUser(string userHash, string name, string email, string pass, int creditUnion)
        {
            int newUserID = 0;
            pass = BCrypt.HashPassword(pass, BCrypt.GenerateSalt(10));      //Change 10 to increase hash rounds
            string hash = HashGenerator.GenerateHash(email);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hash", hash);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Pass", pass);
                    cmd.Parameters.AddWithValue("@CreditUnionID", creditUnion);
                    conn.Open();
                    newUserID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            User newUser = new User();
            newUser.LoadDetails(newUserID);
            return newUser;
        }
        
        /// <summary>
        /// Sets a user's access level
        /// </summary>
        /// <param name="userHash">The currently logged on user's hash value. For now, this parameter is a dummy parameter.</param>
        /// <param name="userID">The ID of the user to update.</param>
        /// <param name="newAccessLevel">The access level to grant.</param>
        /// <returns>The updated user object.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public User SetUserAccess(string userHash, int userID, int newAccessLevel)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateUserAccessLevel", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", userID);
                    cmd.Parameters.AddWithValue("@AccessLevel", newAccessLevel);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            User updatedUser = new User();
            updatedUser.LoadDetails(userID);
            return updatedUser;
        }
    }
}

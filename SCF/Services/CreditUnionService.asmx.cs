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
    /// Summary description for CreditUnionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CreditUnionService : System.Web.Services.WebService
    {
        /// <summary>
        /// Gets a Credit Union
        /// </summary>
        /// <param name="id">The ID of the Credit Union to return</param>
        /// <returns>Object representing the credit union</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public CreditUnion GetCreditUnion(int id)
        {
            CreditUnion cu = new CreditUnion();
            cu.LoadDetails(id);
            return cu;
        }

        /// <summary>
        /// Returns a list of all Credit Unions in the database
        /// </summary>
        /// <returns>List of credit unions</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CreditUnion> GetAllCreditUnions()
        {
            List<CreditUnion> creditUnions = new List<CreditUnion>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllCreditUnions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int creditUnionID = Convert.ToInt32(reader["ID"]);
                        CreditUnion cu = new CreditUnion();
                        cu.LoadDetails(creditUnionID);

                        creditUnions.Add(cu);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return creditUnions;
        }

        /// <summary>
        /// Returns a list of credit unions that match or partially match the filter
        /// </summary>
        /// <param name="filter">Used to filter results: LIKE 'filter%'</param>
        /// <returns>List of credit unions</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<CreditUnion> GetCreditUnionsByName(string filter)
        {
            List<CreditUnion> creditUnions = new List<CreditUnion>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCreditUnionsByName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", filter);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int creditUnionID = Convert.ToInt32(reader["ID"]);
                        CreditUnion cu = new CreditUnion();
                        cu.LoadDetails(creditUnionID);

                        creditUnions.Add(cu);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return creditUnions;
        }

        /// <summary>
        /// Updates the credit union information in the database
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="id">The credit union ID to update</param>
        /// <param name="newName">The new credit union name</param>
        /// <param name="newAbbr">The new credit union abbreviation</param>
        /// <param name="newWWW">The new website</param>
        /// <param name="newLat">The new latitude</param>
        /// <param name="newLong">The new longitude</param>
        /// <returns>The updated Credit Union object</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public CreditUnion UpdateCreditUnion(string userHash, int id, string newName, string newAbbr, string newWWW, double newLat, double newLong)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateCreditUnion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@Abbr", newAbbr);
                    cmd.Parameters.AddWithValue("@Website", newWWW);
                    cmd.Parameters.AddWithValue("@Latitude", newLat);
                    cmd.Parameters.AddWithValue("@Longitude", newLong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            CreditUnion cu = new CreditUnion();
            cu.LoadDetails(id);
            return cu;
        }

        /// <summary>
        /// Creates a new credit union object in the database
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="name">The credit union name</param>
        /// <param name="abbr">The credit union abbreviation</param>
        /// <param name="www">The credit union website</param>
        /// <param name="latitude">The credit union latitude</param>
        /// <param name="longitude">The credit union longitude</param>
        /// <returns>The newly created credit union object</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public CreditUnion CreateCreditUnion(string userHash, string name, string abbr, string www, double latitude, double longitude)
        {
            int newCreditUnionID = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertCreditUnion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Abbr", abbr);
                    cmd.Parameters.AddWithValue("@Website", www);
                    cmd.Parameters.AddWithValue("@Latitude", latitude);
                    cmd.Parameters.AddWithValue("@Longitude", longitude);
                    conn.Open();
                    newCreditUnionID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            CreditUnion cu = new CreditUnion();
            cu.LoadDetails(newCreditUnionID);
            return cu;
        }
    }
}

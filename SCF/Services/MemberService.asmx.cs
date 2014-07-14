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

namespace Coop.Services
{
    /// <summary>
    /// Summary description for MemberService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MemberService : System.Web.Services.WebService
    {
        /// <summary>
        /// Validates a member based on the member's hash value
        /// </summary>
        /// <param name="hash">The hash value to check.</param>
        /// <returns>This method will return the full member object if a member was found matching the specified 
        /// hash value. If no matching member can be located, LatLong values of 0 are returned alone.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Member AuthenticateMember(string hash, double latitude, double longitude)
        {
            Member requestingMember = new Member();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetMemberID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hash", hash);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int memberID = Convert.ToInt32(reader["ID"]);
                            requestingMember.LoadDetails(memberID);
                            requestingMember.UpdateAccessHistory(latitude, longitude, ip);
                        }
                        reader.Close();
                    }
                    else
                    {
                        //This indicates a failed member logon. Could be something fishy...
                    }
                    conn.Close();
                }
            }

            return requestingMember;
        }
    }
}

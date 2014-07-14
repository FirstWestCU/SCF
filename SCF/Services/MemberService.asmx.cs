using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;

namespace Coop
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
                            requestingMember.UpdateAccessHistory(latitude, longitude, GetIP());
                        }
                        reader.Close();
                    }
                    else
                    {
                        //This indicates a failed member logon. Could be something fishy...
                        LogFailedAccess(latitude, longitude, GetIP(), hash);
                    }
                    conn.Close();
                }
            }

            return requestingMember;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Member CreateMember(string name, string email, int creditUnion, double latitude = 0, double longitude = 0)
        {
            int newMemberID = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                if (latitude == 0 && longitude == 0)
                {
                    //We want to use the Credit Union's location for the member
                    CreditUnion cu = new CreditUnion();
                    cu.LoadDetails(creditUnion);
                    latitude = cu.Latitude;
                    longitude = cu.Longitude;
                }
                using (SqlCommand cmd = new SqlCommand("InsertMember", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hash", HashGenerator.GenerateHash(email));
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@CreditUnionID", creditUnion);
                    cmd.Parameters.AddWithValue("@Latitude", latitude);
                    cmd.Parameters.AddWithValue("@Longitude", longitude);
                    conn.Open();
                    newMemberID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            Member newMember = new Member();
            newMember.LoadDetails(newMemberID);

            if (newMemberID > 0)
            {
                using (SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EMAIL_SERVER"]))
                {
                    MailMessage notification = new MailMessage("DO-NOT-REPLY@creditunioncoop.org", email);
                    notification.Subject = "Welcome to the Credit Union COOP!";
                    notification.Body = name + ", <br /><br />Welcome to the Credit Union Sustainable COOP Fund! Please use the link " +
                        "below to access the site. Do not share this link with others. The link provided will identify you to the website, " +
                        "so there is no need to remember any usernames or passwords. Take some time to check out the donations " +
                        "that are being made everywhere by credit unions and make sure you vote for a COOP Project you would like to see " +
                        newMember.CU.Name + " get involved with.<br /><br />Thanks for joining the Credit Union Cooperative Fund - creating " +
                        "sustainable impact in all our communities.<br /><br />Your custom access link:<br />" +
                        ConfigurationManager.AppSettings["BASE_URL"] + "?MemberID=" + newMember.Hash;
                    notification.IsBodyHtml = true;
                    client.Send(notification);
                }
            }

            return newMember;
        }

        private void LogFailedAccess(double latitude, double longitude, string ip, string hash)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateFailedMemberAccess", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Latitude", latitude);
                    cmd.Parameters.AddWithValue("@Longitude", longitude);
                    cmd.Parameters.AddWithValue("@IP", ip);
                    cmd.Parameters.AddWithValue("@RequestedHash", hash);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private string GetIP()
        {
            try
            {
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!String.IsNullOrEmpty(ipAddress))
                {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                    {
                        return addresses[0];
                    }
                }

                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            catch
            {
                return "IP Unknown";
            }
        }
    }
}

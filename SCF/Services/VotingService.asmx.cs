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
    public class VotingService : System.Web.Services.WebService
    {
        /// <summary>
        /// Validates a member based on the member's hash value
        /// </summary>
        /// <param name="hash">The hash value to check.</param>
        /// <returns>This method will return the full member object if a member was found matching the specified 
        /// hash value. If no matching member can be located, LatLong values of 0 are returned alone.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<KeyValueStruct> GetProjectVotes(int votingWindowID)
        {
            List<KeyValueStruct> votes = new List<KeyValueStruct>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProjectVoteCounts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VotingWindowID", votingWindowID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            votes.Add(new KeyValueStruct(Convert.ToInt32(reader["ProjectID"]), Convert.ToInt32(reader["Count"])));
                        }
                        reader.Close();
                    }
                }
            }
            return votes;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<KeyValueStruct> SetVote(int votingWindowID, int projectID, int memberID, string memberHash)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("UpsertVote",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VotingWindowID",votingWindowID);
                    cmd.Parameters.AddWithValue("@ProjectID", projectID);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    conn.Open();
                    cmd.ExecuteScalar();
                }
            }
            return GetProjectVotes(votingWindowID);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public VotingWindow GetCurrentVotingWindow()
        {
            VotingWindow votingWindow = new VotingWindow();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCurrentVotingWindow", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        votingWindow.ID = Convert.ToInt32(reader["ID"]);
                        votingWindow.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        votingWindow.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    }
                    reader.Close();
                }
            }
            return votingWindow;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public VotingWindow CreateVotingWindow(DateTime startDate, DateTime endDate, string userHash)
        {
            VotingWindow votingWindow = new VotingWindow();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertVotingWindow", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        votingWindow.ID = Convert.ToInt32(reader["ID"]);
                        votingWindow.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        votingWindow.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    }
                    reader.Close();
                }
            }
            return votingWindow;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public VotingWindow UpdateVotingWindow(DateTime startDate, DateTime endDate, int votingWindowID, string userHash)
        {
            VotingWindow votingWindow = new VotingWindow();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateVotingWindow", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", votingWindowID);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        votingWindow.ID = Convert.ToInt32(reader["ID"]);
                        votingWindow.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        votingWindow.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    }
                    reader.Close();
                }
            }
            return votingWindow;
        }
    }
}

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
    /// Summary description for DonationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DonationService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Donation AddDonation(string userHash, int creditUnion, string title, int category, int onclock, int offclock, int dollars, double latitude, double longitude, string additionalInfo, DateTime donationDate, int userID)
        {
            int newDonationID = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertDonation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreditUnionID", creditUnion);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@CategoryID", category);
                    cmd.Parameters.AddWithValue("@OnClockHours", onclock);
                    cmd.Parameters.AddWithValue("@OffClockHours", offclock);
                    cmd.Parameters.AddWithValue("@Dollars", dollars);
                    cmd.Parameters.AddWithValue("@Latitude", latitude);
                    cmd.Parameters.AddWithValue("@Longitude", longitude);
                    cmd.Parameters.AddWithValue("@AdditionalInfo", additionalInfo);
                    cmd.Parameters.AddWithValue("@DonationDate", donationDate);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    conn.Open();
                    newDonationID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            Donation donation = new Donation();
            donation.LoadDetails(newDonationID);
            return donation;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteDonation(string userHash, int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDonation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Donation UpdateDonation(string userHash, int id, int creditUnion, string title, int category, int onclock, int offclock, int dollars, double latitude, double longitude, string additionalInfo, DateTime donationDate, int userID)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDonation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@CreditUnionID", creditUnion);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@CategoryID", category);
                    cmd.Parameters.AddWithValue("@OnClockHours", onclock);
                    cmd.Parameters.AddWithValue("@OffClockHours", offclock);
                    cmd.Parameters.AddWithValue("@Dollars", dollars);
                    cmd.Parameters.AddWithValue("@Latitude", latitude);
                    cmd.Parameters.AddWithValue("@Longitude", longitude);
                    cmd.Parameters.AddWithValue("@AdditionalInfo", additionalInfo);
                    cmd.Parameters.AddWithValue("@DonationDate", donationDate);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }


            Donation donation = new Donation();
            donation.LoadDetails(id);
            return donation;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Donation GetDonation(int id)
        {
            Donation donation = new Donation();
            donation.LoadDetails(id);
            return donation;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Donation> GetDonationsByCreditUnion(int creditUnion)
        {
            List<Donation> donations = new List<Donation>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDonationsByCreditUnion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreditUnionID", creditUnion);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int donationID = Convert.ToInt32(reader["ID"]);
                        Donation d = new Donation();
                        d.LoadDetails(donationID);
                        donations.Add(d);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return donations;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Donation> GetDonationsByCategory(int category)
        {
            List<Donation> donations = new List<Donation>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDonationsByCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", category);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int donationID = Convert.ToInt32(reader["ID"]);
                        Donation d = new Donation();
                        d.LoadDetails(donationID);
                        donations.Add(d);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return donations;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Donation> GetDonationsByDate(DateTime start, DateTime end)
        {
            List<Donation> donations = new List<Donation>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDonationsByDate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", start);
                    cmd.Parameters.AddWithValue("@EndDate", end);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int donationID = Convert.ToInt32(reader["ID"]);
                        Donation d = new Donation();
                        d.LoadDetails(donationID);
                        donations.Add(d);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return donations;
        }
    }
}

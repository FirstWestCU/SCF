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
            //TODO: Insert into Database

            Donation donation = new Donation();
            donation.LoadDetails(newDonationID);
            return donation;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteDonation(string userHash, int id)
        {
            //TODO: Delete from Database
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Donation UpdateDonation(string userHash, int id, int creditUnion, string title, int category, int onclock, int offclock, int dollars, double latitude, double longitude, string additionalInfo, DateTime donationDate)
        {
            //TODO: Update Database

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
            //TODO: Retrieve list of donations

            return donations;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Donation> GetDonationsByCategory(int category)
        {
            List<Donation> donations = new List<Donation>();
            //TODO: Retrieve list of donations

            return donations;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Donation> GetDonationsByDate(DateTime start, DateTime end)
        {
            List<Donation> donations = new List<Donation>();
            //TODO: Retrieve list of donations

            return donations;
        }
    }
}

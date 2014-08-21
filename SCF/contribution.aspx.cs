using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net;

namespace Coop
{
    public partial class ContributionPage : System.Web.UI.Page
    {
        protected CreditUnionService.CreditUnion[] creditUnionList;
        protected CategoryService.Category[] categoryList;

        protected void Page_Load(object sender, EventArgs e)
        {
            CreditUnionService.CreditUnionService creditUnionService = new CreditUnionService.CreditUnionService();
            creditUnionList = creditUnionService.GetAllCreditUnions();

            CategoryService.CategoryService categoryService = new CategoryService.CategoryService();
            categoryList = categoryService.GetDonationCategories();


        }


        [WebMethod(EnableSession = true)]
        public static string addContribution(string creditUnionId, string categoryId, string address1, string address2, string city,string provState, string postalZip, string country, string charityName, string lat, string lng, string description, string amount, string contributedDollarValue, string volunteerHours)
        {

            try
            {
                DonationService.DonationService donationService = new DonationService.DonationService();
                DonationService.Donation donation = new DonationService.Donation();

                string userHash = "ABC";
                int cuID = Convert.ToInt32(creditUnionId);
                int catID = Convert.ToInt32(categoryId);
                int onClock = Convert.ToInt32(volunteerHours);
                int offClock = 0;
                int dollars = Convert.ToInt32(amount);
                int otherContributions=0;
               // string additionalInfo ="";
              
                Double latitude = Convert.ToDouble(lat);
                Double longitude= Convert.ToDouble(lng);
                DateTime donationDate = DateTime.Today;
                int userId=1;

             
                DonationService.Donation submittedDonation =  donationService.AddDonation(userHash, cuID, charityName,catID,onClock, offClock, dollars,
                        otherContributions,address1,address2,city,provState,postalZip, country, 
                        latitude, longitude, description,donationDate, userId );
           
               
             
                return "success";


            }
            catch (Exception e)
            {
                return e.Message;
            }


        }


    }
}
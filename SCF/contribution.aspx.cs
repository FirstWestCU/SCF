using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net;


using System.IO;


namespace Coop
{
    public partial class ContributionPage : System.Web.UI.Page
    {
        protected CreditUnionService.CreditUnion[] creditUnionList;
        protected CategoryService.Category[] categoryList;

        protected static System.Web.UI.HtmlControls.HtmlInputFile File1;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            CreditUnionService.CreditUnionService creditUnionService = new CreditUnionService.CreditUnionService();
            creditUnionList = creditUnionService.GetAllCreditUnions();

            CategoryService.CategoryService categoryService = new CategoryService.CategoryService();
            categoryList = categoryService.GetDonationCategories();


        }


        [WebMethod(EnableSession = true)]
       // public static string addContribution(string creditUnionId, string categoryId, string address1, string address2, string city,string provState, string postalZip, string country, string charityName, string lat, string lng, string description, string amount, string contributedDollarValue, string volunteerHours)
        public string addContribution(object sender, System.EventArgs e)
       {

            try
            {


                HttpPostedFile file = Request.Files["myFile"];

                //check file was submitted
                if (file != null && file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
                }

                /*
                DonationService.DonationService donationService = new DonationService.DonationService();
                DonationService.Donation donation = new DonationService.Donation();

                string creditUnionId = context.Request.Form["creditUnionId"];
                string categoryId = context.Request.Form["categoryId"];
                string volunteerHours = context.Request.Form["volunteerHours"];
                string amount = context.Request.Form["amount"];
                string lat = context.Request.Form["lat"];
                string lng = context.Request.Form["long"];
                string charityName = context.Request.Form["charityName"];
                string address1 = context.Request.Form["address1"];
                string address2 = context.Request.Form["address2"];
                string city = context.Request.Form["city"];
                string provState = context.Request.Form["provState"];
                string postalZip = context.Request.Form["postalZip"];
                string country = context.Request.Form["country"];
                string description = context.Request.Form["description"];

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
                */
                //File upload code
                if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
                {
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string SaveLocation = HttpContext.Current.Server.MapPath("uploadedFiles") + "\\" + fn;
                  
                    File1.PostedFile.SaveAs(SaveLocation);
                    return "success";
                }
                else
                {
                    return "failure2";
                    //Response.Write("Please select a file to upload.");
                }

             
                

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }//end method

    }//end class
}//end namespace
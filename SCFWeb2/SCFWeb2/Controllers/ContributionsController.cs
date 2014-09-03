using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SCFWeb2.Controllers
{
    public class ContributionsController : Controller
    {

        protected CategoryService.CategoryServiceSoap categoryService = new CategoryService.CategoryServiceSoapClient("CategoryServiceSoap");
        protected CreditUnionService.CreditUnionServiceSoap creditUnionService = new CreditUnionService.CreditUnionServiceSoapClient("CreditUnionServiceSoap");
        protected DonationService.DonationServiceSoap donationService = new DonationService.DonationServiceSoapClient("DonationServiceSoap");



        public HttpPostedFileBase UploadedFile { get; set; }

        public ActionResult Index()
        {

            DateTime startDate = DateTime.Today;
            startDate = startDate.AddYears(-2);

            DateTime endDate = DateTime.Today;
            endDate = endDate.AddYears(1);       
            
            ViewBag.donationList = donationService.GetDonationsByDate(startDate, endDate);
            ViewBag.categoryService = new CategoryService.CategoryServiceSoapClient("CategoryServiceSoap");

            ViewBag.imagePath = Url.Content("~/Content/Files/");

            //Some temporary code - to delete test contributions - needs to be updated with ID
            //donationService.DeleteDonation("ABC",16);
            

            //end temp code


            return View();
        }



        public ActionResult ContributionForm()
        {



            ViewBag.categoryList = categoryService.GetDonationCategories();
            ViewBag.creditUnionList = creditUnionService.GetAllCreditUnions();

            return View();
        }


        [HttpPost]
        public ActionResult Add(string creditUnionId, string categoryId, string address1, string address2, string city,
                                string provState, string postalZip, string country, string charityName, string lat, 
                                string lng, string description, string amount, string contributedDollarValue, 
                                string volunteerHours,HttpPostedFileBase file) 
        {


                DonationService.DonationServiceSoap donationService = new DonationService.DonationServiceSoapClient("DonationServiceSoap");
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
                





            //Get file upload dir from settings

               string path = Server.MapPath("~/Content/uploads/");
            

            if (file != null)
            {
                //Check if id for this contribution exists (it shouldn't)
                string contributionPath =path + "contrib" + submittedDonation.ID+ "\\";
                if (!Directory.Exists(contributionPath))
                {
                    Directory.CreateDirectory(contributionPath);
                }

                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(contributionPath + "uploadedImage" + extension);
            }

            //TODO - set a message here (alert)

            return RedirectToAction("Index");
        }

    }
}
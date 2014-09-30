using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Xml.Linq;
using SCFWeb2.Models;

namespace SCFWeb2.Controllers
{
    public class ContributionController : Controller
    {

        protected CategoryService.CategoryServiceSoap categoryService = new CategoryService.CategoryServiceSoapClient("CategoryServiceSoap");
        protected CreditUnionService.CreditUnionServiceSoap creditUnionService = new CreditUnionService.CreditUnionServiceSoapClient("CreditUnionServiceSoap");
        protected DonationService.DonationServiceSoap donationService = new DonationService.DonationServiceSoapClient("DonationServiceSoap");



        public HttpPostedFileBase UploadedFile { get; set; }

        public ActionResult Index(int? id)
        {

            DateTime startDate = DateTime.Now.AddDays(-1000);
            DateTime endDate = DateTime.Now.AddDays(1000);

            int countPerPage = 12;
            int pageIndex = 1;
            
//            ViewBag.donationList = donationService.GetDonationsByDate(startDate, endDate);

            //shorten number of donations
            DonationService.Donation[] donationArray = donationService.GetDonationsByDate(startDate, endDate);
            ViewBag.totalPageCount = (donationArray.Length + 12 - 1) / 12;


            if(id != null){
                pageIndex = id.Value;
            }

            ViewBag.currentPageNumber = pageIndex;


            ViewBag.donationList = donationArray.Skip(countPerPage * (pageIndex - 1)).Take(countPerPage).ToArray();


            ViewBag.categoryService = new CategoryService.CategoryServiceSoapClient("CategoryServiceSoap");
            ViewBag.imagePath = Url.Content("~/Content/Files/");

            //Some temporary code - to delete test contributions - needs to be updated with ID
           // donationService.DeleteDonation("ABC",57);
            //end temp code



            int totalContributions = 0;
            int totalContributedDollars = 0;
            int totalContributedHours = 0;
            int totalCreditUnions = 0;

            //Get all Contribution details

            DonationService.Donation[] donations = donationService.GetDonationsByDate(startDate, endDate);
            foreach (DonationService.Donation donation in donations)
            {
                totalContributions++;
                totalContributedDollars += donation.Dollars;
                totalContributedHours += donation.OnClockHours;
            }

            totalCreditUnions = creditUnionService.GetAllCreditUnions().Length;

            ViewBag.totalContributions = totalContributions;
            ViewBag.totalContributedDollars = totalContributedDollars;
            ViewBag.totalContributedHours = totalContributedHours;
            ViewBag.totalCreditUnions = totalCreditUnions;


            return View();
        }



        public ActionResult ContributionForm()
        {

            //TEMP - there is for sure a better way to do this.
            if (Session["userHash"] == null)
            {
                TempData["errorMessage"] = "You must log in to provide contribution information";
                return RedirectToAction("Registration", "User");
            }

            ViewBag.categoryList = new SelectList(categoryService.GetDonationCategories(), "ID","Description");
            ViewBag.creditUnionList = new SelectList(creditUnionService.GetAllCreditUnions(), "ID", "Name") ;


            ContributionViewModel cb = new ContributionViewModel();
            return View();
        }


        [HttpPost]
        public ActionResult ContributionForm(ContributionViewModel contribution, HttpPostedFileBase file)
        {


            //Do mandatory checks
            //List<string> errorMessages = new List<string>();
          
        
            //Now try to get lat and long
            string address = contribution.address1 + "," 
                + contribution.address2 + "," 
                + contribution.city + ","
                + contribution.provState + ","
                + contribution.postalZip + ","
                + contribution.country;
                  
            Tuple<double,double> latlng = GoogleGeoCode(address);


                DonationService.DonationServiceSoap donationService = new DonationService.DonationServiceSoapClient("DonationServiceSoap");
                DonationService.Donation donation = new DonationService.Donation();
    
                string userHash = "ABC";


                int onClock = Convert.ToInt32(contribution.volunteerHours);
                int offClock = 0;//Not used yet

                int dollars = Convert.ToInt32(Math.Floor(Convert.ToDouble(String.IsNullOrWhiteSpace(contribution.amount) ? "0" : contribution.amount)));
                int other = Convert.ToInt32(Math.Floor(Convert.ToDouble(String.IsNullOrWhiteSpace(contribution.otherContributions) ? "0" : contribution.otherContributions)));
              
               
                DateTime donationDate = DateTime.Today;
                int userId=1;


                DonationService.Donation submittedDonation = donationService.AddDonation(userHash, contribution.creditUnionId, contribution.charityName, contribution.categoryId, onClock, offClock, dollars,
                        other, contribution.address1, contribution.address2, contribution.city, contribution.provState, contribution.postalZip, contribution.country,
                        latlng.Item1, latlng.Item2, contribution.description, donationDate, userId);
                

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

            return RedirectToAction("Index");
        }



        //TODO - move somewhere
        Tuple<double,double> GoogleGeoCode(string address)
        {
            string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            double lat = (double)locationElement.Element("lat");
            double lng = (double)locationElement.Element("lng");

            return Tuple.Create(lat, lng);
        }


    }
}
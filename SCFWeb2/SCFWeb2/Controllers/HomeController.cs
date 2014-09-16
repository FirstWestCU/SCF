using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCFWeb2.Controllers
{
    public class HomeController : Controller
    {

        protected CategoryService.CategoryServiceSoap categoryService = new CategoryService.CategoryServiceSoapClient("CategoryServiceSoap");

        protected DonationService.DonationServiceSoap donationService = new DonationService.DonationServiceSoapClient("DonationServiceSoap");

        protected CreditUnionService.CreditUnionServiceSoap creditUnionService = new CreditUnionService.CreditUnionServiceSoapClient("CreditUnionServiceSoap");


        public ActionResult Index()
        {

            int totalContributions = 0;
            int totalContributedDollars = 0;
            int totalContributedHours = 0;
            int totalCreditUnions = 0;

            //Get all Contribution details
            DateTime startDate = DateTime.Now.AddDays(-1000);
            DateTime endDate = DateTime.Now.AddDays(1000);
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

            ViewBag.categories = categoryService.GetProjectCategories();
            return View();
        }

      /*  public ActionResult Contributions()
        {

            DateTime startDate = DateTime.Today;
            startDate = startDate.AddYears(-2);

            DateTime endDate = DateTime.Today;
            endDate = endDate.AddYears(1);

            
            ViewBag.donationList = donationService.GetDonationsByDate(startDate, endDate);

            return View();
        }*/

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
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
       // protected CategoryService.Category[] categories;

        protected DonationService.DonationServiceSoap donationService = new DonationService.DonationServiceSoapClient("DonationServiceSoap");
       // protected 

        public ActionResult Index()
        {
            
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
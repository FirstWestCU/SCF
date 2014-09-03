using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCFWeb2.Controllers
{

    public class UserController : Controller
    {


        // protected CreditUnionService.CreditUnion[] creditUnionList;
        // protected CategoryService.Category[] categoryList;

        // GET: User
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Registration()
        {

            CreditUnionService.CreditUnionServiceSoap creditUnionService = new CreditUnionService.CreditUnionServiceSoapClient("CreditUnionServiceSoap");
            // creditUnionList = creditUnionService.GetAllCreditUnions();

            CategoryService.CategoryServiceSoap categoryService = new CategoryService.CategoryServiceSoapClient("CategoryServiceSoap");
            // categoryList = categoryService.GetProjectCategories();

            ViewBag.categoryList = categoryService.GetDonationCategories();
            ViewBag.creditUnionList = creditUnionService.GetAllCreditUnions();

            return View();
        }


        public ActionResult ProcessRegistration(string firstName, string lastName, string emailAddress, string creditUnionId, string password, string passwordConfirm)
        {



            //Check mandatories
            if (String.IsNullOrEmpty(emailAddress))
            {
              //  ModelState.AddModelError();
            }

            //Check mandatories
            if (String.IsNullOrEmpty(creditUnionId))
            {

            }

            if (String.IsNullOrEmpty(password))
            {

            }




            return Redirect("Registration");
        }



        public ActionResult Login()
        {



            return View();
        }






        [HttpPost]
        public ActionResult ProcessLogin(string userName, string password)
        {


            MemberService.MemberServiceSoap memberService = new MemberService.MemberServiceSoapClient("MemberServiceSoap");
            return Redirect("Registration");
        }

    }
}
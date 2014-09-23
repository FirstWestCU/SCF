using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCFWeb2.Models;


namespace SCFWeb2.Controllers
{



    public class UserController : Controller
    {

        CreditUnionService.CreditUnionServiceSoap creditUnionService = new CreditUnionService.CreditUnionServiceSoapClient("CreditUnionServiceSoap");
    
        CategoryService.CategoryServiceSoap categoryService = new CategoryService.CategoryServiceSoapClient("CategoryServiceSoap");
         

        // GET: User
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Registration()
        {

            //Test code for deleting credit unions
           

          
            //A bit of complicated code to ensure 'other' is a viable final option in the list
            ViewBag.categoryList = categoryService.GetDonationCategories();
            List<SelectListItem> creditUnionSelectList = new SelectList(creditUnionService.GetAllCreditUnions(), "ID", "Name").ToList(); 
            SelectListItem otherSelectItem = new SelectListItem();
            otherSelectItem. Value = "-1";
            otherSelectItem.Text ="Other";
            creditUnionSelectList.Add(otherSelectItem);
            ViewBag.creditUnionList = new SelectList(creditUnionSelectList,"Value","Text");

            RegistrationViewModel rv = new RegistrationViewModel();

            return View(rv);
        }


        [HttpPost]
        //public ActionResult Registration(string firstName, string lastName, string emailAddress, string creditUnionId, string password, string passwordConfirm)
        public ActionResult Registration(RegistrationViewModel registration)
        {

            if (registration.creditUnionId>=0){
                ModelState.Remove("creditUnionName");
            }


            if (!ModelState.IsValid){


                //A bit of complicated code to ensure 'other' is a viable final option in the list
                ViewBag.categoryList = categoryService.GetDonationCategories();
                List<SelectListItem> creditUnionSelectList = new SelectList(creditUnionService.GetAllCreditUnions(), "ID", "Name").ToList();
                SelectListItem otherSelectItem = new SelectListItem();
                otherSelectItem.Value = "other";
                otherSelectItem.Text = "Other";
                creditUnionSelectList.Add(otherSelectItem);
                ViewBag.creditUnionList = new SelectList(creditUnionSelectList, "Value", "Text");

                return View(registration);
            }


            //Test if we need to add a new CU
            if (registration.creditUnionId<0){
                creditUnionService.CreateCreditUnion("ABC", registration.creditUnionName, "","",50,50);
            }

                //Need the voting windows
                UserService.UserServiceSoap userService = new UserService.UserServiceSoapClient("UserServiceSoap");
                userService.CreateUser(registration.firstName + " " + registration.lastName, registration.emailAddress, registration.password, Convert.ToInt32(registration.creditUnionId));

                TempData["successMessage"] = "You have successfully registered and may log in.";
                return RedirectToAction("Login");
            //}
        }



        public ActionResult Login()
        {



            return View();
        }






        [HttpPost]
        public ActionResult Login(string userName, string password)
        {


            UserService.UserServiceSoap userService = new UserService.UserServiceSoapClient("UserServiceSoap");
            UserService.User user = userService.AuthenticateUser(userName,password);

            if (user == null)
            {
                ViewBag.errorMessage="Log in not successful";
                return Redirect("/User/Login");
            }else if (String.IsNullOrEmpty(user.Email))
            {
                ViewBag.errorMessage = "Log in not successful";
                return Redirect("/User/Login");

            }
            else
            {
               

                Session["userHash"] = user.Hash;

                TempData["successMessage"] = "You have successfully logged in.";
                return Redirect("/Home");
            }

            
        }


        public ActionResult Logout()
        {

            Session.Abandon();
            TempData["successMessage"] = "You have successfully logged out.";
            return Redirect("/Home");
        }

    }
}
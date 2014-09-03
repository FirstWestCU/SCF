using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

          

            ViewBag.categoryList = categoryService.GetDonationCategories();
            ViewBag.creditUnionList = creditUnionService.GetAllCreditUnions();

            return View();
        }


        [HttpPost]
        public ActionResult Registration(string firstName, string lastName, string emailAddress, string creditUnionId, string password, string passwordConfirm)
        {

           List<string> errorMessages = new List<string>();


            //Check mandatories
            if (String.IsNullOrEmpty(emailAddress))
            {
                errorMessages.Add("Email Address is a required field");
            }


            if (String.IsNullOrEmpty(password))
            {
                   errorMessages.Add("Password is a required field");
            }




            if (errorMessages.Count >0){
                ViewBag.errorMessages = errorMessages;
                ViewBag.categoryList = categoryService.GetDonationCategories();
                ViewBag.creditUnionList = creditUnionService.GetAllCreditUnions();
                return View();

            //Next level of validation
            }else if (password !=passwordConfirm ){
                    errorMessages.Add("The Password fields did not match.");
                    ViewBag.errorMessages = errorMessages;
                    ViewBag.categoryList = categoryService.GetDonationCategories();
                    ViewBag.creditUnionList = creditUnionService.GetAllCreditUnions();
                    return View();
                
            //Else hunky dory
            }else{

                //Need the voting windows
                UserService.UserServiceSoap userService = new UserService.UserServiceSoapClient("UserServiceSoap");
                userService.CreateUser(firstName + " " + lastName, emailAddress, password,Convert.ToInt32(creditUnionId));

                TempData["successMessage"] = "You have successfully registered and may log in.";
                return Redirect("Registration");
            }
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

                TempData["successMessage"] = "You have successfully registered and may log in.";
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
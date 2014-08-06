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
 

         public partial class RegistrationPage : System.Web.UI.Page
    {

              protected CreditUnionService.CreditUnion[] creditUnionList;
        protected void Page_Load(object sender, EventArgs e)
        {
            CreditUnionService.CreditUnionService creditUnionService = new CreditUnionService.CreditUnionService();
            creditUnionList = creditUnionService.GetAllCreditUnions();

           
       }


        [WebMethod(EnableSession = true)]
        public static string registerMember(string firstName, string lastName, string emailAddress, string creditUnionId, string password)
        {

            try
            {

                //Need the voting windows
                MemberService.MemberService memberService = new MemberService.MemberService();
                MemberService.Member member =  memberService.CreateMember(firstName + " " + lastName, emailAddress, Convert.ToInt32(creditUnionId), 49.5014700, -119.5921800);

                HttpContext.Current.Session["memberHash"] = member.Hash;
                return "success";
            

            }
            catch (Exception e)
            {
                return e.Message;
            }

           
        }


        /* Not currently used - but used to register non members */
        [WebMethod]
        public static string register(string firstName, string lastName, string emailAddress, string creditUnionId, string password)
        {

            try
            {

                //Need the voting windows
                //MemberService.MemberService memberService = new MemberService.MemberService();
                //MemberService.Member member =  memberService.CreateMember(firstName + " " + lastName, emailAddress, Convert.ToInt32(creditUnionId), 49.5014700, -119.5921800);

                UserService.UserService userService = new UserService.UserService();
                UserService.User user = userService.CreateUser(firstName + " " + lastName, emailAddress, password, Convert.ToInt32(creditUnionId));


            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "success";
        }

    }
}
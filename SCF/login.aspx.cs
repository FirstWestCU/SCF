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


    public partial class LoginPage : System.Web.UI.Page
    {

    
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }


        [WebMethod]
        public static string login(string userName, string password)
        {

            try
            {

              //  UserService.UserService userService = new UserService.UserService();
               // UserService.User user = userService.AuthenticateUser(userName, password);

                MemberService.MemberService memberService = new MemberService.MemberService();
               // memberService.CreateMember();

              //  user.

             /*   if (user.)
                {
                    return user.Email;// user.Name;
                }
                else
                {
                    return "nope";
                }*/


            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "success";
        }

    }
}
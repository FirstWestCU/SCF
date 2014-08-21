using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coop
{
    public partial class ContributionsPage : System.Web.UI.Page
    {
        protected DonationService.Donation[] donationList;

          

        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime startDate = DateTime.Today;
            startDate = startDate.AddYears(-2);

            DateTime endDate = DateTime.Today;
            endDate = endDate.AddYears(1);

            DonationService.DonationService donationService = new DonationService.DonationService();
            donationList = donationService.GetDonationsByDate(startDate, endDate);

           



        }

    }
}
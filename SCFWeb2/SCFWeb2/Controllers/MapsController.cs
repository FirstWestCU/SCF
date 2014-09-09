using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCFWeb2.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        public ActionResult Index()
        {

            List<Tuple<double, double>> canadianContributionLocations =  new List<Tuple<double, double>>();
            List<Tuple<double, double>> indianapolisContributionLocations= new List<Tuple<double, double>>();
            List<Tuple<double, double>> coloradoContributionLocations= new List<Tuple<double, double>>();

            //First - get all credit unions
            CreditUnionService.CreditUnionServiceSoap creditUnionService = new CreditUnionService.CreditUnionServiceSoapClient("CreditUnionServiceSoap");
            CreditUnionService.CreditUnion[] creditUnionList= creditUnionService.GetAllCreditUnions();


            //Loop over credit unions
            foreach (CreditUnionService.CreditUnion creditUnion in creditUnionList)
            {
                //Second - get all contributions for each area
                DonationService.DonationServiceSoap donationService = new DonationService.DonationServiceSoapClient("DonationServiceSoap");
                DonationService.Donation[] donationList= donationService.GetDonationsByCreditUnion(creditUnion.ID);

                foreach (DonationService.Donation donation in donationList)
                {
                    if ((donation.DonatingCreditUnion.ID == 4) || (donation.DonatingCreditUnion.ID == 5) || (donation.DonatingCreditUnion.ID == 6))
                    {
                        //donation.Latitude;
                        //donation.Longitude;
                        canadianContributionLocations.Add(Tuple.Create(donation.Latitude, donation.Longitude));
                    }
                    else if (donation.DonatingCreditUnion.ID == 1)
                    {
                        coloradoContributionLocations.Add(Tuple.Create(donation.Latitude, donation.Longitude));
                    }
                    else if (donation.DonatingCreditUnion.ID == 3)
                    {
                        indianapolisContributionLocations.Add(Tuple.Create(donation.Latitude, donation.Longitude));
                    }
                 
                }
            }


            ViewBag.canadianContributionLocations = canadianContributionLocations;
            ViewBag.indianapolisContributionLocations = indianapolisContributionLocations;
            ViewBag.coloradoContributionLocations = coloradoContributionLocations;

            return View();
        }
    }
}
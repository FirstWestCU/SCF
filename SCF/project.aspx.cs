using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net;
using System.IO;

namespace Coop
{
    public partial class ProjectPage : System.Web.UI.Page
    {

       // protected String projectTitle;
        //protected String projectText;
        protected Coop.ProjectService.Project project;
        protected int projectVoteCount;

        protected void Page_Load(object sender, EventArgs e)
        {

            ProjectService.ProjectService projectService = new ProjectService.ProjectService();
           

            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            project = projectService.GetProject(id);

            //Get project votes
            Voting_Service.VotingWindow votingWindow = new Voting_Service.VotingWindow();
             Voting_Service.VotingService votingService = new Voting_Service.VotingService();
             votingWindow = votingService.GetCurrentVotingWindow();

            Voting_Service.KeyValueStruct[] votingResults = votingService.GetProjectVotes(1);

            //This is super lame
            foreach(Voting_Service.KeyValueStruct votingResult in votingResults){
                if (votingResult.Key == id)
                {
                    projectVoteCount = votingResult.Value;

                }
            }

           
           // projectVoteCount = 1;

            /*
            switch (id)
            {
                case "1":
                    projectTitle = "Over Fishing";
                    projectText = "Over the last 50 years, the growing human population, demand for food and increase in fishing technology has resulted in the mass utilization of marine resources, exploiting an estimated 70% of the world’s fish stocks. Continuously trying to catch more fish than the system can naturally produce has depleted fish stocks to a point where they may be unable to recover, threatening the vitality of our oceans. Through informed decision making and management controls such as closed breeding zones and marine protected areas, we can mitigate overfishing. Sustaining the diversity of our water’s marine life is the key in maintaining the health of our economy, ecosystem and communities all over the world. ";
                    break;
                case "2":
                    projectTitle = "Shipping Emissions - Save the Oceans";
                    projectText = "Home to 80% of all life forms on earth, more than three quarters of our planet is covered by oceans.  Their vastness, however, greatly increases their susceptibility to harm. Primarily made up of carbon dioxide, harsh shipping emissions are being released through water transportation vehicles that use fossil fuels. Contributing to the rise in global climate change and ocean acidification, the steady increase in emissions has greatly added to our global warming crisis due to the fact that 90% of world trade is across oceans. Additionally, the great risks accompanied by oceanic trade, for example oil spills, are cause to conclude that better preventative actions must be taken. Through operational changes, technological advances and alternative fuel sources, a full range of strategies can help sustain global trade without jeopardizing the safety of our oceans.";
                    break;
                case "3":
                    projectTitle = "Reducing Our Carbon Footprint";
                    projectText = "Due to the depletion of resources of which we have depended on for fuel for the last few hundred years, new technologies and power systems have been developed in order  to provide comparable or better energy sources without releasing harmful chemicals. Largely attributed to this growing awareness of environmental pollution and climate change, many organizations and homes have chosen to adapt to better, more eco friendly lifestyles in order to lessen the world’s carbon footprint. Of these renewable energies, wind and solar power are among the fastest growing alternate sources in the world. They harness natural, green energy by utilizing inexhaustible power which generate few greenhouse gases. These renewable forms of power offer users a clearer conscience in addition to providing thousands of jobs whilst encouraging great economic growth for our future. ";
                    break;
                case "4":
                    projectTitle = "Run for Water";
                    projectText = "Over 1 billion people do not have access to drinking water, and for every 19 seconds passed, a child dies for lack of clean water.  Conceptualized in 2007, Run for Water is an annual charity event  raising awareness and funds for people in the developing world who do not have  access to clean drinking water. Organized by a volunteer board, the run’s success has encouraged the development of a gala event, race expo and extensive involvement with students in Vancouver’s lower mainland, teaching them what it means to be a compassionate global citizen. Offering run distances across the spectrum of 5kms to ultra marathons, the event was designed for every age and level of athlete in order to expose the cause and generate funds.  Currently building water projects in Gezesso in southern Ethiopia, Run for Water has helped over 17,000 people and raised more than $1,000,0000 for the cause. ";
                    break;
                case "5":
                    projectTitle = "Homeless Youth";
                    projectText = "An estimated one third of the North American homeless population is youths, whom after experiencing abuse and neglect, take to the streets. Without a place to call home, street youths are greatly more susceptible to physical and mental abuse, sickness, injury and mental health problems. These issues substantially affect their long term situations, lessening their chances of staying in school, decreasing literacy rates and increasing drug and alcohol dependency. The outcomes of these issues implicate their self esteem and ability to become self supporting. Unutilized investments, many street youths lack the opportunity to show and develop their potential.  However through mentoring programs, youth shelters and educational opportunities, they are given the chance to become contributing members to their society. Breaking the cycle of poverty among homeless youth is a great challenge, yet necessary for the social and financial future of our global community.";
                    break;
                case "6":
                    projectTitle = "Cancer Research";
                    projectText = "Although research has progressed, an expected 4,000 North Americans are diagnosed with, and 1,700 die from cancer every day.  Mostly affecting those aged 50 or older, cancer can hit any person at any age, making it the most likely cause of death in Canada and the United States.  Cancer starts in our cells after a tumor is formed and can move throughout the body. It occurs in stages, from 0 to 4, and at each stage, a different medical direction is taken. Though the prevalence of the disease has increased due to technological advancements allowing us to detect it earlier, the many biological, environmental and inflicted risks have been discovered allowing people to mitigate their chances of becoming sick. There are still many changes needed to be made in order to fully understand and eradicate the disease which can be made possible through further educating our population, generating more funds and working with government to input legislation to help discourage the consumption of cancerous substances.";
                    break;
                default:
                    projectText = "Not supplied";
                    break;
            }*/
        }


       [WebMethod(EnableSession = true)]
        public static string setVote(string projectIdString)
        {


            try
            {

                int projectId = Convert.ToInt32(projectIdString);


                //Need the voting windows
                  Voting_Service.VotingWindow votingWindow = new Voting_Service.VotingWindow();


                  String memberHash = (string)HttpContext.Current.Session["memberHash"];
                  int memberId = (int)HttpContext.Current.Session["memberId"];



                Voting_Service.VotingService votingService = new Voting_Service.VotingService();
                votingWindow = votingService.GetCurrentVotingWindow();



                votingService.SetVote(votingWindow.ID, projectId, memberId, memberHash);

          
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "success";
        }

    }
}
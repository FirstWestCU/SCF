using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCFWeb2.Controllers
{
    public class ProjectsController : Controller
    {

      //  protected ProjectService.ProjectServiceSoap Project[] projects;

        // GET: Projects
        public ActionResult Index()
        {

            ProjectService.ProjectServiceSoap projectService = new ProjectService.ProjectServiceSoapClient("ProjectServiceSoap");
            ViewBag.projects = projectService.GetAllProjects();
            return View();
        }

        // GET: Projects
        public ActionResult Project()
        {

            ProjectService.ProjectServiceSoap projectService = new ProjectService.ProjectServiceSoapClient("ProjectServiceSoap");

            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            SCFWeb2.ProjectService.Project project = projectService.GetProject(id);

            //Get project votes
            /*
            Voting_Service.VotingWindow votingWindow = new Voting_Service.VotingWindow();
            Voting_Service.VotingService votingService = new Voting_Service.VotingService();
            votingWindow = votingService.GetCurrentVotingWindow();

            Voting_Service.KeyValueStruct[] votingResults = votingService.GetProjectVotes(1);

            //This is super lame
            foreach (Voting_Service.KeyValueStruct votingResult in votingResults)
            {
                if (votingResult.Key == id)
                {
                    projectVoteCount = votingResult.Value;

                }
            }
            */
            ViewBag.project = project;
            
            
            return View();
        }
    }
}
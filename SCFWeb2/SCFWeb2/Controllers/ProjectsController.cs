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
    }
}
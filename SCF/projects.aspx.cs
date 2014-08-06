using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop
{
    public partial class ProjectsPage : System.Web.UI.Page
    {
        protected ProjectService.Project[] projects;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectService.ProjectService projectService = new ProjectService.ProjectService();
            projects =  projectService.GetAllProjects();

          //  foreach(ProjectService.Project project in projects){
               // test += project.Name;
           // }
            

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop
{
    public partial class ProjectsPage : System.Web.UI.Page
    {
        protected string test = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           /* ProjectService.ProjectService projectService = new ProjectService.ProjectService();
            ProjectService.Project[] projects =  projectService.GetAllProjects();

            foreach(ProjectService.Project project in projects){
                test += project.Name;
            }
            */

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coop
{
    /// <summary>
    /// Summary description for ProjectService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProjectService : System.Web.Services.WebService
    {
        /// <summary>
        /// Inserts a new project into the database
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access.</param>
        /// <param name="name">The project name.</param>
        /// <param name="description">The project description.</param>
        /// <param name="www">The project website</param>
        /// <param name="category">The project category ID</param>
        /// <param name="creditUnion">The credit union's ID</param>
        /// <returns>The newly created project object.</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Project CreateProject(string userHash, string name, string description, string www, int category, int creditUnion)
        {
            int newProjectID = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertProject", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Website", www);
                    cmd.Parameters.AddWithValue("@CategoryID", category);
                    cmd.Parameters.AddWithValue("@CreditUnionID", creditUnion);
                    conn.Open();
                    newProjectID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            Project newProject = new Project();
            newProject.LoadDetails(newProjectID);
            return newProject;
        }

        /// <summary>
        /// Updates the given project in the database
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="projectID">The project ID to update</param>
        /// <param name="newName">The new project name</param>
        /// <param name="newDescription">The new project description</param>
        /// <param name="newWWW">The new project website</param>
        /// <param name="newCategory">The new project category ID</param>
        /// <param name="newCreditUnion">The new project credit union's ID</param>
        /// <returns>The updated project object</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Project UpdateProject(string userHash, int projectID, string newName, string newDescription, string newWWW, int newCategory, int newCreditUnion)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateProject", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", projectID);
                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@Description", newDescription);
                    cmd.Parameters.AddWithValue("@Website", newWWW);
                    cmd.Parameters.AddWithValue("@CategoryID", newCategory);
                    cmd.Parameters.AddWithValue("@CreditUnionID", newCreditUnion);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            Project newProject = new Project();
            newProject.LoadDetails(projectID);
            return newProject;
        }

        /// <summary>
        /// Deletes a project from the database
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="projectID">The project ID to delete</param>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteProject(string userHash, int projectID)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteProject", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", projectID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Returns the project details for the specified project ID
        /// </summary>
        /// <param name="projectID">The project ID to return</param>
        /// <returns>The corresponding project object</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Project GetProject(int projectID)
        {
            Project project = new Project();
            project.LoadDetails(projectID);
            return project;
        }

        /// <summary>
        /// Returns an array of all the projects in the database, regardless of activation status
        /// </summary>
        /// <returns>List of projects</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllProjects", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int projectID = Convert.ToInt32(reader["ID"]);
                        Project p = new Project();
                        p.LoadDetails(projectID);
                        projects.Add(p);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return projects;
        }

        /// <summary>
        /// Returns an array of all currently active projects in the database
        /// </summary>
        /// <returns>List of projects</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Project> GetActiveProjects()
        {
            List<Project> projects = new List<Project>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetActiveProjects", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int projectID = Convert.ToInt32(reader["ID"]);
                        Project p = new Project();
                        p.LoadDetails(projectID);
                        projects.Add(p);
                    }
                }
            }

            return projects;
        }

        /// <summary>
        /// Returns an array of projects in the specified category
        /// </summary>
        /// <param name="categoryID">The category of projects to select</param>
        /// <returns>List of projects</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Project> GetProjectsByCategory(int categoryID)
        {
            List<Project> projects = new List<Project>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProjectsByCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int projectID = Convert.ToInt32(reader["ID"]);
                        Project p = new Project();
                        p.LoadDetails(projectID);
                        projects.Add(p);
                    }
                }
            }

            return projects;
        }

        /// <summary>
        /// Adds a new FAQ to a project
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="projectID">The project ID to add to</param>
        /// <param name="question">The question</param>
        /// <param name="answer">The answer</param>
        /// <returns>The ID of the newly created FAQ</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int AddProjectFAQ(string userHash, int projectID, string question, string answer)
        {
            int faqID = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertProjectFAQ", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", projectID);
                    cmd.Parameters.AddWithValue("@Question", question);
                    cmd.Parameters.AddWithValue("@Answer", answer);
                    conn.Open();
                    faqID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            return faqID;
        }

        /// <summary>
        /// Adds a new project update
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="projectID">The project ID to add to</param>
        /// <param name="message">The update message</param>
        /// <param name="userID">The ID of the user posting the message</param>
        /// <returns>The ID of the newly created update</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int AddProjectUpdate(string userHash, int projectID, string message, int userID)
        {
            int updateID = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertProjectUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", projectID);
                    cmd.Parameters.AddWithValue("@Message", message);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    conn.Open();
                    updateID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }

            return updateID;
        }

        /// <summary>
        /// Returns a projects FAQ list
        /// </summary>
        /// <param name="projectID">The project ID to filter</param>
        /// <returns>List of project FAQs</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ProjectFAQ> GetProjectFAQ(int projectID)
        {
            List<ProjectFAQ> faqs = new List<ProjectFAQ>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProjectFAQ", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", projectID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProjectFAQ faq = new ProjectFAQ();
                        faq.ID = Convert.ToInt32(reader["ID"]);
                        faq.Question = reader["Question"].ToString();
                        faq.Answer = reader["Answer"].ToString();

                        faqs.Add(faq);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return faqs;
        }
        
        /// <summary>
        /// Deletes a FAQ from the database
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="id">The ID of the FAQ to delete</param>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteProjectFAQ(string userHash, int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteProjectFAQ", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Returns a projects updates list
        /// </summary>
        /// <param name="projectID">The project ID to filter</param>
        /// <returns>List of project updates</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<ProjectUpdate> GetProjectUpdates(int projectID)
        {
            List<ProjectUpdate> updates = new List<ProjectUpdate>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProjectUpdates", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProjectID", projectID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProjectUpdate update = new ProjectUpdate();
                        update.ID = Convert.ToInt32(reader["ID"]);
                        update.Message = reader["Message"].ToString();
                        update.DatePosted = Convert.ToDateTime(reader["UpdateDate"]);
                        int userID = Convert.ToInt32(reader["UserID"]);
                        User u = new User();
                        u.LoadDetails(userID);
                        update.PostedBy = u;

                        updates.Add(update);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return updates;
        }

        /// <summary>
        /// Deletes an update from the database
        /// </summary>
        /// <param name="userHash">The hash of the currently logged on user. For future use in confirming user access</param>
        /// <param name="id">The ID of the update to delete</param>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteProjectUpdate(string userHash, int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteProjectUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}

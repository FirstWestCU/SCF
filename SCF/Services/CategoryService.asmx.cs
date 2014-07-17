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
    /// Summary description for CategoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CategoryService : System.Web.Services.WebService
    {
        /// <summary>
        /// Returns a given categories description
        /// </summary>
        /// <param name="id">The ID of the category to search for</param>
        /// <returns>Category description</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCategoryDescription(int id)
        {
            string category = "N/A";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCategoryDescription", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        category = reader["Description"].ToString();
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return category;
        }

        /// <summary>
        /// Returns the given categories ID value
        /// </summary>
        /// <param name="description">The category description</param>
        /// <returns>ID value corresponding to the provided description</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int GetCategoryID(string description)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCategoryID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Description", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["ID"]);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return id;
        }

        /// <summary>
        /// Returns a list of all of the Project/Donation categories in the database
        /// </summary>
        /// <returns>List of categories</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllCategories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Category c = new Category();
                        c.ID = Convert.ToInt32(reader["ID"]);
                        c.Description = reader["Description"].ToString();
                        categories.Add(c);
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return categories;
        }
    }
}

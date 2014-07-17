using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coop
{
    /// <summary>
    /// Summary description for ShowProjectImage
    /// </summary>
    public class ShowProjectImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["ID"] != null)
            {
                int id = Convert.ToInt32(context.Request.QueryString["ID"]);
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetProjectImage", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProjectID", id);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                context.Response.ContentType = reader["ContentType"].ToString();
                                context.Response.BinaryWrite((byte[])reader["COOPImage"]);
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                            reader.Close();
                        }
                        else
                        {
                            //Return the default image. Change the path below to return the proper image
                            string filepath = context.Server.MapPath(ConfigurationManager.AppSettings["DEFAULT_PROJECT_IMAGE"]);
                            context.Response.ContentType = "image/png";
                            context.Response.WriteFile(filepath);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }
                        conn.Close();
                    }
                }

                context.Response.ContentType = "text/plain";
                context.Response.Write("Hello World");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
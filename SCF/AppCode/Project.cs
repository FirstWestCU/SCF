using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coop
{
    public class Project
    {
        private int id;

        public void LoadDetails(int id)
        {
            this.id = id;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetProjectDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Name = reader["Name"].ToString();
                        Description = reader["Description"].ToString();
                        Website = reader["Website"].ToString();
                        int creditUnionID = Convert.ToInt32(reader["CreditUnionID"]);
                        CreditUnion cu = new CreditUnion();
                        cu.LoadDetails(creditUnionID);
                        ProposedBy = cu;
                    }
                    reader.Close();
                    conn.Close();
                }
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Website
        {
            get;
            set;
        }

        public CreditUnion ProposedBy
        {
            get;
            set;
        }
    }
}
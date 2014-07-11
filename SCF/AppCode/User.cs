using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Coop
{
    public class User
    {
        private int id;

        public void LoadDetails(int id)
        {
            this.id = id;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Hash = reader["Hash"].ToString();
                        Name = reader["Name"].ToString();
                        Email = reader["Email"].ToString();
                        AccessLevel = Convert.ToInt32(reader["AccessLevelID"]);
                        int creditUnionID = Convert.ToInt32(reader["CreditUnionID"]);
                        CreditUnion cu = new CreditUnion();
                        cu.LoadDetails(creditUnionID);
                        CU = cu;
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

        public string Hash
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public CreditUnion CU
        {
            get;
            set;
        }

        public int AccessLevel
        {
            get;
            set;
        }
    }
}
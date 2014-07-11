using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Coop
{
    public class CreditUnion
    {
        private int id;

        public void LoadDetails(int id)
        {
            this.id = id;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCreditUnionDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Name = reader["Name"].ToString();
                        Abbr = reader["Abbr"].ToString();
                        Website = reader["Website"].ToString();
                        Latitude = Convert.ToDouble(reader["Latitude"]);
                        Longitude = Convert.ToDouble(reader["Longitude"]);
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

        public string Abbr
        {
            get;
            set;
        }

        public string Website
        {
            get;
            set;
        }

        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }
    }
}
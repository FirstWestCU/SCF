using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coop
{
    public class Member
    {
        private int id;

        public void LoadDetails(int id)
        {
            this.id = id;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetMemberDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Hash = reader["Hash"].ToString();
                        Name = reader["Name"].ToString();
                        Latitude = Convert.ToDouble(reader["Latitude"]);
                        Longitude = Convert.ToDouble(reader["Longitude"]);
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

        public void UpdateAccessHistory(double latitude, double longitude, string ip)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("", conn))
                {

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

        public CreditUnion CU
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
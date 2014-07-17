using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Coop
{
    public class Donation
    {
        private int id;

        public void LoadDetails(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SCF"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetDonationDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        this.id = id;
                        int creditUnionID = Convert.ToInt32(reader["CreditUnionID"]);
                        CreditUnion cu = new CreditUnion();
                        cu.LoadDetails(creditUnionID);
                        DonatingCreditUnion = cu;
                        Title = reader["Title"].ToString();
                        Category = Convert.ToInt32(reader["CategoryID"]);
                        OnClockHours = Convert.ToInt32(reader["OnClockHours"]);
                        OffClockHours = Convert.ToInt32(reader["OffClockHours"]);
                        Dollars = Convert.ToInt32(reader["Dollars"]);
                        Latitude = Convert.ToDouble(reader["Latitude"]);
                        Longitude = Convert.ToDouble(reader["Longitude"]);
                        AdditionalInfo = reader["AdditionalInfo"].ToString();
                        DonationDate = Convert.ToDateTime(reader["DonationDate"]);
                        DateAdded = Convert.ToDateTime(reader["DateAdded"]);
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

        public CreditUnion DonatingCreditUnion
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int Category
        {
            get;
            set;
        }

        public int OnClockHours
        {
            get;
            set;
        }

        public int OffClockHours
        {
            get;
            set;
        }

        public int Dollars
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

        public string AdditionalInfo
        {
            get;
            set;
        }

        public DateTime DonationDate
        {
            get;
            set;
        }

        public DateTime DateAdded
        {
            get;
            set;
        }
    }
}
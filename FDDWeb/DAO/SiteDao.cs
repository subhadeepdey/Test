using FDDWeb.Utility;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FDDWeb.DAO
{
    public interface ISiteDao
    {
        Dictionary<string, string> GetSiteData();
        bool UpdateSiteData(string publishingOffer, string deliveryTime, string menuOfTheDay);
    }

    public class SiteDao : ISiteDao
    {
        public Dictionary<string, string> GetSiteData()
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GET_FDD_SITE_DATA"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<string, string> siteData = new Dictionary<string, string>();
                        while (reader.Read())
                        {
                            siteData.Add(reader.GetFieldValue<string>("FDD_KEY"), reader.GetFieldValue<string>("FDD_VALUE"));
                        }
                        return siteData;
                    }
                }
            }
        }

        public bool UpdateSiteData(string publishingOffer, string deliveryTime, string menuOfTheDay)
        {
            string constr = ConfigurationManager.ConnectionStrings["FDDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_FDD_SITE_DATA"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PublishingOffer", publishingOffer);
                    cmd.Parameters.AddWithValue("@DeliveryTime", deliveryTime);
                    cmd.Parameters.AddWithValue("@MenuOfTheDay", menuOfTheDay);
                    cmd.Connection = con;
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}
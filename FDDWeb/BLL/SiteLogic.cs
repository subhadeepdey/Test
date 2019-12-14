using FDDWeb.DAO;
using System.Collections.Generic;

namespace FDDWeb.BLL
{
    public interface ISiteLogic
    {
        Dictionary<string, string> GetSiteData();
        bool UpdateSiteData(string publishingOffer, string deliveryTime, string menuOfTheDay);
    }
    public class SiteLogic : ISiteLogic
    {
        public ISiteDao siteDao { get; set; }

        public SiteLogic(ISiteDao siteDao)
        {
            this.siteDao = siteDao;
        }

        public Dictionary<string, string> GetSiteData() => siteDao.GetSiteData();

        public bool UpdateSiteData(string publishingOffer, string deliveryTime, string menuOfTheDay) => siteDao.UpdateSiteData(publishingOffer, deliveryTime, menuOfTheDay);
    }
}
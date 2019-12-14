using FDDWeb.DAO;
using System.Collections.Generic;

namespace FDDWeb.BLL
{
    public interface ISiteLogic
    {
        Dictionary<string, string> GetSiteData();
    }
    public class SiteLogic : ISiteLogic
    {
        public ISiteDao siteDao { get; set; }

        public SiteLogic(ISiteDao siteDao)
        {
            this.siteDao = siteDao;
        }

        public Dictionary<string, string> GetSiteData() => siteDao.GetSiteData();
    }
}
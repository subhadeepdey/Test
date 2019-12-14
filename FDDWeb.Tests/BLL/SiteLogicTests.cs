using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDDWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDDWeb.DAO;

namespace FDDWeb.BLL.Tests
{
    [TestClass()]
    public class SiteLogicTests : TestBase
    {
        public ISiteLogic siteLogic { get; set; }

        public ISiteDao siteDao { get; set; }

        [TestInitialize]
        public void Setup()
        {
            siteDao = new SiteDao();
            siteLogic = new SiteLogic(siteDao);
        }

        [TestMethod()]
        public void GetSiteDataTest()
        {
            Assert.IsNotNull(siteLogic.GetSiteData());
        }
    }
}
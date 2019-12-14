using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FDDWeb.BLL;
using FDDWeb.Utility;
using Microsoft.Practices.Unity;

namespace FDDWeb
{
    public partial class _Default : PageBase
    {
        [Dependency]
        public ISiteLogic siteLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSiteData();
            }
        }

        private void LoadSiteData()
        {
            var siteData = siteLogic.GetSiteData();
            if (siteData.TryGetValue(Constants.PUBLISHING_OFFER, out string publishingOffer))
            {
                PublishingOffer.Text = publishingOffer;
            }

            if (siteData.TryGetValue(Constants.DELIVERY_TIME, out string deliveryTime))
            {
                DeliveryTime.Text = deliveryTime;
            }

            if (siteData.TryGetValue(Constants.MENU_OF_THE_DAY, out string menuOfTheDay))
            {
                MenuOfTheDay.Text = menuOfTheDay;
            }
        }
    }
}
using FDDWeb.BLL;
using FDDWeb.Utility;
using Microsoft.Practices.Unity;
using System;
using System.Web.UI.WebControls;

namespace FDDWeb.Admin
{
    public partial class ManageSite : PageBase
    {
        [Dependency]
        public ISiteLogic siteLogic { get; set; }

        [Dependency]
        public IUserLogic userLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadSiteData();
            }
        }

        private void LoadUsers()
        {
            Users.DataSource = userLogic.GetUsers();
            Users.DataBind();
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

        protected void UpgradeUser(object sender, CommandEventArgs e)
        {
            userLogic.UpgradeToPremium(e.CommandArgument.ToString());
            LoadUsers();
        }
    }
}
using FDDWeb.BLL;
using FDDWeb.Utility;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FDDWeb.Admin
{
    public partial class ManageSite : PageBase
    {
        [Dependency]
        public IUserLogic userLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            Users.DataSource = userLogic.GetUsers();
            Users.DataBind();
        }

        protected void UpgradeUser(object sender, CommandEventArgs e)
        {
            userLogic.UpgradeToPremium(e.CommandArgument.ToString());
            LoadUsers();
        }
    }
}
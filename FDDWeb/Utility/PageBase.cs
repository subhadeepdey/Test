using Microsoft.AspNet.Identity;
using System.Web.UI;

namespace FDDWeb.Utility
{
    public class PageBase : Page
    {
        public string USERNAME { get { return Context.User.Identity.GetUserName(); } }

        public bool IS_ADMIN { get { return !string.IsNullOrEmpty(Context.User.Identity.GetUserName()) && Context.User.IsInRole(Constants.ADMIN_ROLE); } }
    }
}
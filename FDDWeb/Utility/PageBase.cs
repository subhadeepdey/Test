using Microsoft.AspNet.Identity;
using System.Web.UI;

namespace FDDWeb.Utility
{
    public class PageBase : Page
    {
        public string USERNAME { get { return Context.User.Identity.GetUserName(); } }
    }
}
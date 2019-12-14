using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using FDDWeb.Models;
using FDDWeb.BLL;
using Microsoft.Practices.Unity;
using System.Web.Security;
using FDDWeb.Utility;

namespace FDDWeb.Account
{
    public partial class Login : PageBase
    {
        [Dependency]
        public IUserLogic userLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (!IsValid)
                {
                    return;
                }

                var user = userLogic.IsValidUser(Username.Text, Password.Text);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Current.Response.Cookies.Add(authCookie);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    //Response.Redirect("/Home");
                }
                else
                {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }

            }
        }

        protected void Reset(object sender, EventArgs e)
        {
            Username.Text = string.Empty;
            Password.Text = string.Empty;
        }
    }
}
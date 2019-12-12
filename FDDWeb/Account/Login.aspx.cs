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

namespace FDDWeb.Account
{
    public partial class Login : Page
    {
        [Dependency]
        public IUserLogic userLogic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
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
                    Response.Redirect("/Account/Login");
                }

                //// Validate the user password
                ////var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ////var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                ////// This doen't count login failures towards account lockout
                ////// To enable password failures to trigger lockout, change to shouldLockout: true
                //// var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);
                //SignInStatus result = SignInStatus.Success;
                //var user = userLogic.IsValidUser(Username.Text, Password.Text);
                //if (user != null)
                //{
                //    var role = user.Roles;
                //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Username.Text, DateTime.Now,
                //        DateTime.Now.AddMinutes(2880), RememberMe.Checked, "User", FormsAuthentication.FormsCookiePath);
                //    string hash = FormsAuthentication.Encrypt(ticket);
                //    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                //    if (ticket.IsPersistent)
                //    {
                //        cookie.Expires = ticket.Expiration;
                //    }
                //    Response.Cookies.Add(cookie);
                //    Response.Redirect(FormsAuthentication.GetRedirectUrl(Username.Text, RememberMe.Checked));
                //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //}
                //else
                //{
                //    FailureText.Text = "Invalid login attempt";
                //    ErrorMessage.Visible = true;
                //}
            }
        }

        protected void Reset(object sender, EventArgs e)
        {
            Username.Text = string.Empty;
            Password.Text = string.Empty;
        }
    }
}
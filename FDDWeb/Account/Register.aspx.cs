using System;
using System.Web.UI;
using FDDWeb.Models;
using FDDWeb.BLL;
using Microsoft.Practices.Unity;
using FDDWeb.Utility;
using System.Web.Security;
using System.Web;

namespace FDDWeb.Account
{
    public partial class Register : PageBase
    {
        [Dependency]
        public IUserLogic userLogic { get; set; }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var user = userLogic.Register(new User
            {
                Username = Username.Text,
                Password = Password.Text,
                Name = Name.Text,
                Email = Email.Text,
                Phone = Phone.Text,
                Address = Address.Text,
                AlternateAddress = AlternateAddress.Text,
                Role = Constants.DEFAULT_ROLE
            });
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
                ErrorMessage.Text = "Error occured please try again after some time.";
                ErrorMessage.Visible = true;
                Response.Redirect("/Account/Login");
            }

            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new User() { Username = Email.Text, Email = Email.Text };
            //var aa = userLogic.Register(user);

            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }
    }
}
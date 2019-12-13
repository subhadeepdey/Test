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

        protected void Page_Load(object sender, EventArgs e)
        {
            AddUserAsAdmin.Visible = IS_ADMIN;
        }
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
                Role = (IS_ADMIN && AdminUser.Checked) ? Constants.ADMIN_ROLE : Constants.DEFAULT_ROLE
            });
            if (user != null)
            {
                // Admin User Added
                if (string.IsNullOrEmpty(USERNAME) && IS_ADMIN)
                {
                    SuccessMessage.Text = "User created successfully";
                    SuccessMessage.Visible = true;
                    return;
                }

                FormsAuthentication.SetAuthCookie(user.Username, false);

                var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Current.Response.Cookies.Add(authCookie);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }

            else
            {
                ErrorMessage.Text = "Error occured please try again after some time.";
                ErrorMessage.Visible = true;
                Response.Redirect("/Account/Login");
            }
        }
    }
}
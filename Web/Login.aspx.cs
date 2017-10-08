using System;
using System.Web.UI;
using Web.Common;
using System.Configuration;
using System.Web.Security;
using System.Web;

namespace Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LogIn(object sender, EventArgs e)
        {
            var ldapAuth = new LdapAuthentication(ConfigurationManager.AppSettings.Get("AWLDAP"));
            if (IsValid)
            {
                var domain = ConfigurationManager.AppSettings.Get("Domain");
                var userName = txtUserID.Text;
                var splittedUserName = txtUserID.Text.Split('\\');
                if (splittedUserName.Length > 1)
                {
                    domain = splittedUserName[0];
                    userName = splittedUserName[1];
                }
                var result = ldapAuth.IsAuthenticated(domain, userName, txtPassword.Text);

                if (result)
                {
                    ///////////////////////////////////////////////////////////
                    String groups = ldapAuth.GetGroups(domain, userName, txtPassword.Text);

                    //Create the ticket, and add the groups.
                    bool isCookiePersistent = false;
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userName,
              DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, groups);

                    //Encrypt the ticket.
                    String encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    //Create a cookie, and then add the encrypted ticket to the cookie as data.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    if (true == isCookiePersistent)
                        authCookie.Expires = authTicket.Expiration;

                    //Add the cookie to the outgoing cookies collection.
                    Response.Cookies.Add(authCookie);

                    //You can redirect now.
                    FormsAuthentication.RedirectFromLoginPage(userName, true);
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(userName, false));
                }
                else
                {
                    ErrorMessage.Visible = true;
                    FailureText.Text = "Authentication did not succeed. Check user name and password.";
                }

                //FormsAuthentication.RedirectFromLoginPage(userName, true);
                //Response.Redirect("Account/default.aspx");
            }
            else
            {
                FailureText.Text = "Invalid login attempt";
                ErrorMessage.Visible = true;
            }

        }
    }
}

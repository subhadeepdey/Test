using FormsAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormsAuthAd.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var la = new LdapAuthentication("LDAP://ldap.amwater.net/DC=amwaternp,DC=net,DC=amwater,DC=net");

            //var la = new LdapAuthentication("LDAP://ldap.amwater.net");
            //var la = new LdapAuthentication("LDAP://DC=amwater,DC=net");
            var la = new LdapAuthentication("LDAP://DC=amwaternp,DC=net");


            try
            {
              var x =  la.IsAuthenticated("AWW", "DEYS", "Yad%1984");
            }
            catch (Exception ex)
            {

            }
        }

        protected void loginAD_LoggingIn(object sender, LoginCancelEventArgs e)
        {

        }
    }
}
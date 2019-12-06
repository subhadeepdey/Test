using Microsoft.Owin;
using Owin;
using FDDWeb.Utility;
using Microsoft.Practices.Unity;
using System.Web;
using Unity.WebForms;
using FDDWeb.BLL;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;

[assembly: OwinStartupAttribute(typeof(FDDWeb.Startup))]
namespace FDDWeb
{
    public partial class Startup
    {

        IUnityContainer container;
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);

            container = HttpContext.Current.Application.GetContainer();
            // var userLogic = container.Resolve<IUserLogic>();
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //    Provider = new CookieAuthenticationProvider
            //    {
            //        //OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
            //        //   validateInterval: TimeSpan.FromMinutes(30),
            //        //   regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            //    }
            //});

            //app.FDDAuthentication(userLogic);
            app.Use((context, next) => AddFDDAuthorizations(next, context));
        }

        protected async Task AddFDDAuthorizations(Func<Task> next, IOwinContext context)
        {

            container = HttpContext.Current.Application.GetContainer();
      //      var userLogic = container.Resolve<IUserLogic>();

            // If there is a user associated with the request...
            if (context?.Authentication?.User != null)
            {
                // And if they're in LDAP...
                var user = context.Authentication.User;
                var ldap = user?.FindFirst(c => "User L".Equals(c.Type));
                var match = new Regex(@"(?:^|,)unitnumber=([^,]{1,9})(?:,|$)").Match(ldap?.Value ?? string.Empty);
                if (match.Groups.Count > 1)
                {
                    // Add their FDD roles to their identity.
                    var unitNumber = new Regex(@"(?:^|,)unitnumber=([^,]{1,9})(?:,|$)").Match(ldap.Value).Groups[1].Value;
                    //var roles = await ((DAL.IUserDao)config.DependencyResolver.GetService(typeof(DAL.IUserDao))).GetRoles(unitNumber);
                    //user.AddIdentity(new ClaimsIdentity(roles.Select(r => new Claim(ClaimTypes.Role, r.ToString()))));
                }
            }

            // Continue the OWIN pipeline.
            await next.Invoke();
        }
    }
}

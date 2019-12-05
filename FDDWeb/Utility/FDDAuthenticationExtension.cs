using FDDWeb.BLL;
using Microsoft.Owin;
using NLog;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace FDDWeb.Utility
{
    public static class FDDAuthenticationExtension
    {
        public static IAppBuilder FDDAuthentication(this IAppBuilder app, IUserLogic userLogic, ILogger logger = null)
        {
            return app;
        }

    }
}
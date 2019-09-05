using Rafitec.Cloud.Portal.Web.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Rafitec.Cloud.Portal.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /*Metodo que faz a validação de permissao do usuáio*/
        public void Application_OnAuthorizeRequest()
        {
            var cookie = FormsAuthentication.FormsCookieName;
            if (!String.IsNullOrEmpty(cookie))
            {
                var httpCookie = Context.Request.Cookies[cookie];
                if (httpCookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(httpCookie.Value);
                    FormsIdentity identity = new FormsIdentity(ticket);
                    GenericPrincipal principal = new GenericPrincipal(identity, null);
                    HttpContext.Current.User = principal;
                }

            }
        }
    }
}

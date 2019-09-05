using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.RelatorioComercial
{
    public class RelatorioComercialAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RelatorioComercial";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RelatorioComercial_default",
                "RelatorioComercial/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
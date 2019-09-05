using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.TecnologiaInformacao
{
    public class TecnologiaInformacaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TecnologiaInformacao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TecnologiaInformacao_default",
                "TecnologiaInformacao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
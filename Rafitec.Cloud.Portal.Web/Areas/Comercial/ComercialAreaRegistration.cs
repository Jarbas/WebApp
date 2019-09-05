using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial
{
    public class ComercialAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Comercial";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Comercial_index",
                url: "Comercial/{controller}/{action}/{pagina}",
                defaults: new { pagina = 1 },
                namespaces: new[] { "Rafitec.Cloud.Portal.Web.Areas.Comercial.Controllers" },
                constraints: new { action = "Index" }
            );
               
            context.MapRoute(
                "Comercial_editar",
                "Comercial/{controller}/{action}/{id}",
                new { action = "Editar", id = UrlParameter.Optional },
                constraints: new { action = "Editar" }
            );

            context.MapRoute(
                "Comercial_create",
                "Comercial/{controller}/{action}/{id}",
                new { action = "Create", id = UrlParameter.Optional },
                constraints: new { action = "Create" }
            );

            context.MapRoute(
                "ComercialCadastro",
                "Comercial/{controller}/{action}/{id}",
                new { action = "Create", id = UrlParameter.Optional },
                constraints: new { action = "Cadastro" }
            );
            context.MapRoute(
                "ComercialDashboard",
                "Comercial/{controller}/{action}/{id}",
                new { action = "Dashboard", id = UrlParameter.Optional },
                constraints: new { action = "Dashboard" }
            );

        }
    }
}
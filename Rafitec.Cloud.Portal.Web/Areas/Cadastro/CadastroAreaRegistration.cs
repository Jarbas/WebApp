using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro
{
    public class CadastroAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cadastro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                   name: "Cadastro_Index",
                   url: "Cadastro/{controller}/{action}/{pagina}",
                   defaults: new { pagina = 1 },
                   constraints: new { action= "Index"}
            );

            context.MapRoute(
                   name: "Cadastro_Cadastro",
                   url: "Cadastro/{controller}/{action}",
                   defaults: null,
                   constraints: new { action = "Cadastro" }
            );

            context.MapRoute(
                   name: "Cadastro_Editar",
                   url: "Cadastro/{controller}/{action}/{id}",
                   defaults: null,
                   constraints: new { action = "Editar" }
            );
            
            context.MapRoute(
                   name: "Cadastro_Get",
                   url: "Cadastro/{controller}/{action}/{id}",
                   defaults: null,
                   constraints: new { action = "Get" }
            );

            context.MapRoute(
                   name: "Cadastro_Default",
                   url: "Cadastro/{controller}/{action}/"
            );
        }
    }
}
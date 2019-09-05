using System.Web.Mvc;
using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Portal.Web.Objeto.Filtro;

namespace Rafitec.Cloud.Portal.Web.Controllers
{ 
    public class FiltroController : Controller
    {
     
        public PartialViewResult FiltroDefault(string action, FiltroDefault filtro)
        {
            var model = new FiltroDefaultViewModel()
            {
                Action = action,
                Filtro = filtro
            };
            return PartialView("_FiltroDefault", model);
        }



    }
}
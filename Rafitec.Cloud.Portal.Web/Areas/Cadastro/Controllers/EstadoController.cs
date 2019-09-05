using System.Linq;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Dominio.Entidades;

namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro.Controllers
{
    public class EstadoController : Controller
    {
        private Repositorio<Estado> _repositorio;// = new Repoitorio();

      /*  [HttpGet]
        public JsonResult GetEstado()
        {
            _repositorio = new Repositorio<Estado>();
            return Json(_repositorio.Get.Select(e => new { e.idEstado, e.Sigla }) , JsonRequestBehavior.AllowGet);
        }*/

        [HttpGet]
        public JsonResult GetEstado(int idPais)
        {
            _repositorio = new Repositorio<Estado>();
            return Json(_repositorio.Get.Where(e => e.idPais == idPais).OrderBy(e=> e.Sigla).Select(e => new { e.idEstado, e.Sigla }), JsonRequestBehavior.AllowGet);
        }




        /*   // GET: Cadastro/Estado
           public ActionResult Index()
           {
               return View();
           }*/
    }
}
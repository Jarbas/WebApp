using System.Linq;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Dominio.Entidades;

namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro.Controllers
{
    public class CidadeController : Controller
    {
        private Repositorio<Cidade> _repositorio;

        [HttpGet]
        public JsonResult GetCidade(int idEstado)
        {
            _repositorio = new Repositorio<Cidade>();
            return Json(_repositorio.Get.Where(c => c.idEstado == idEstado).OrderBy(c => c.Nome).Select(c => new {c.idCidade, c.Nome}), JsonRequestBehavior.AllowGet);
        }

    }
}
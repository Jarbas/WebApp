using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;

namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro.Controllers
{
    [Authorize]
    public class UnidadeVendaController : Controller
    {

            private Repositorio<UnidadeVenda> _repositorio;

            [HttpGet]
            public JsonResult Get(int id)
            {
                _repositorio = new Repositorio<UnidadeVenda>();
                return Json(_repositorio.Get.Where(uv => uv.idUnidadeNegocio == id).Select(uv => new {uv.idUnidadeVenda, uv.Descricao }), JsonRequestBehavior.AllowGet);
            }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models;
using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Portal.Web.Models;


namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro.Controllers
{
    public class PaisController : Controller
    {

        private Repositorio<Pais> _repositorio;

        [HttpGet]
        public JsonResult GetPais()
        {
            _repositorio = new Repositorio<Pais>();
            return Json(_repositorio.Get.OrderBy(p => p.Nome), JsonRequestBehavior.AllowGet);
            
        }
    }
}
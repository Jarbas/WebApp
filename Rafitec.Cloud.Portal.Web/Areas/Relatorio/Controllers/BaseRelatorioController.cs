using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Portal.Web.Areas.Relatorio.Models.Filtro;

namespace Rafitec.Cloud.Portal.Web.Areas.Relatorio.Controllers
{

    [Authorize]
    public abstract class BaseRelatorioController : Controller
    {
        protected void SetViewBagStatusFiltro(StatusFiltro status)
        {
            ViewBag.StatusFiltro = status;
        }

        protected ActionResult RedirecionamentoFiltroNullo()
        {
            SetViewBagStatusFiltro(StatusFiltro.NaoPermitirFiltrar);    
            return RedirectToAction("Filtro");
        }


        [HttpGet]
        public abstract ActionResult Filtro();
        [HttpGet]
        public abstract ActionResult Gerar(FiltroRelatorioDefault filtro = null);
        protected abstract void ExecutaFiltrar(FiltroRelatorioDefault filtro);



    }
}
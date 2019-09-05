using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Web.Areas.Relatorio.Controllers;
using Rafitec.Cloud.Portal.Web.Areas.Relatorio.Models.Filtro;
using Rafitec.Cloud.Portal.Web.Areas.RelatorioComercial.Models.Filtro;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;

namespace Rafitec.Cloud.Portal.Web.Areas.RelatorioComercial.Controllers
{

    [Authorize]
    public class OrdemProducaoAcompanhamentoController : BaseRelatorioController
    {

        private IEnumerable<OrdemProducaoAcompanhamento> _model;
        private Repositorio<OrdemProducaoAcompanhamento> _repositorio;

        [HttpGet]
        public override ActionResult Filtro()
        {
            var model = new Models.Filtro.FiltroOrdemProducaoAcompanhamento();
            return View("Filtro", model);
        }

        [HttpGet]
        public override ActionResult Gerar(FiltroRelatorioDefault filtro = null) 
        {
            if (filtro == null)
                return RedirecionamentoFiltroNullo();
            ExecutaFiltrar(filtro);
            return View("Relatorio", _model);
        }
        
        protected override void ExecutaFiltrar(FiltroRelatorioDefault filtro)
        {
            _repositorio = new Repositorio<OrdemProducaoAcompanhamento>();
            var filtroConcreto = filtro as FiltroOrdemProducaoAcompanhamento;
            var usuarioLogado = Admin.Controllers.UsuarioController.GetUsuarioLogado();
            _model = _repositorio.Get.Where(op => op.IdEmpresa == usuarioLogado.idEmpresa);

            if (!string.IsNullOrEmpty(filtroConcreto.Op))
            {
                _model = _model.Where(op => op.Numero == filtroConcreto.Op);
            }
        }
    }
}
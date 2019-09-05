using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models;
using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Portal.Web.Objeto.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Controllers
{
    [Authorize]
    public class RepresentanteController : Controller
    {
        private Repositorio<Entidade> _repositorio;
        private ResponseModelView _response;

        [HttpGet]
        public ActionResult Index(int pagina, FiltroDefault filtro = null)
        {

            _repositorio = new Repositorio<Entidade>();
            var model = new RepresentanteViewModel<Entidade>();
            model.Lista = _repositorio.Get.Where(r => r.TipoEntidade == Utils.Enums.EntidadeTipo.Representante);
            if (filtro.Codigo != null)
                model.Lista = _repositorio.Get.Where(r => r.idEntidade == filtro.Codigo);
            if (! String.IsNullOrEmpty(filtro.Descricao))
                model.Lista = _repositorio.Get.Where(r => r.RazaoSocial == filtro.Descricao);
            model.Filtro = filtro;
            model.Paginacao = new Paginacao();
            model.Paginacao.PaginaAtual = pagina;
            model.Lista = model.Paginacao.Paginar<Entidade>(model.Lista, false);
            return View(model);

        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            return View(new Entidade() { TipoEntidade = Utils.Enums.EntidadeTipo.Representante, DataCadastramento = DateTime.Now });
        }

        [HttpPost]
        public PartialViewResult Cadastro(Entidade e)
        {
            _response = new ResponseModelView();
            _repositorio = new Repositorio<Entidade>();
            ValidarRepresentante(e);

            if (_response.Status == Utils.Enums.StatusResponse.Success)
            {
                
                e.TipoEntidade = Utils.Enums.EntidadeTipo.Representante;
                e.DataCadastramento = DateTime.Now;
                _repositorio.Adicionar(e);
                _response.SuccessMessage.Add("Representante Cadastro com Sucesso.");
                _response.RotaSuccess = Url.Action("Index", "Representante", new { Area = "Comercial" });
            }

            return PartialView("_ModalResponseMensagem", _response);
        }

        private void ValidarRepresentante(Entidade e)
        {
            // implementar validação conforme necessario
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            _repositorio = new Repositorio<Entidade>();
            return View(_repositorio.Get.FirstOrDefault(r => r.idEntidade == id));
        }

        [HttpPost]
        public ActionResult Editar(Entidade e)
        {
            _repositorio = new Repositorio<Entidade>();
            var representante = _repositorio.Get.FirstOrDefault(r => r.idEntidade == e.idEntidade);
            if  (representante != null)
            {
                _response = new ResponseModelView();
                ValidarRepresentante(e);
                if (_response.Status == Utils.Enums.StatusResponse.Success)
                {
                    _repositorio = new Repositorio<Entidade>();
                    _repositorio.Editar(e);
                    _response.SuccessMessage.Add("Representante Editado com Sucesso.");
                    _response.RotaSuccess = Url.Action("Index", "Representante", new { Area = "Comercial" });
                }

            }

            return PartialView("_ModalResponseMensagem", _response);
        }
    }
}
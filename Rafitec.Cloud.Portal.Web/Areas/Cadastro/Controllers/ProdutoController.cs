using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Portal.Web.Areas.Admin.Controllers;
using Rafitec.Cloud.Portal.Web.Areas.Cadastro.Models;
using Rafitec.Cloud.Portal.Web.Areas.Cadastro.Models.Filtro;
using Rafitec.Cloud.Portal.Web.Controllers;
using Rafitec.Cloud.Portal.Web.HtmlHelpers;
using Rafitec.Cloud.Portal.Web.Objeto.Extensions;


namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {

        private Repositorio<Produto> _repositorio;
        private ResponseModelView _response;

        [HttpGet] 
        public ActionResult Index(int pagina, FiltroProduto filtro = null)
        {
            _repositorio = new Repositorio<Produto>();
            var model = new BaseConsultaDefaultViewModel<Produto>();
            model.FiltroViewModel.Filtro = filtro;
            model.Lista = Filtrar(filtro);
            model.Paginacao.PaginaAtual = pagina;
            model.Paginar();

            return View(model);
        }

        private IEnumerable<Produto> Filtrar(FiltroProduto filtro = null)
        {
            var produtos = _repositorio.Get.Where(p => p.idEmpresa == UsuarioController.GetUsuarioLogado().idEmpresa);

            if (filtro != null)
            {
                if (filtro.Codigo != null)
                    produtos = produtos.Where(p => p.idProduto == filtro.Codigo);

                if (filtro.Status != Status.None)
                    produtos = produtos.Where(p => p.Status == filtro.Status);

                if (! String.IsNullOrEmpty(filtro.Descricao))
                    produtos = produtos.Where(p => p.Descricao.Contains(filtro.Descricao));
                //
            }

            return produtos;           
        }

        [HttpGet]
        public ViewResult Cadastro()
        {
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Cadastro(Produto produto)
        {
            
            _response = new ResponseModelView();        
            _repositorio = new Repositorio<Produto>();

            produto.idEmpresa = UsuarioController.GetUsuarioLogado().idEmpresa;
            produto.Status = Status.Ativo;
            if (_repositorio.Adicionar(produto))
            {
                _response.SuccessMessage.Add("Produto Cadastrado Com Succeso.");
                _response.RotaNovoCadastro = Url.Action("Cadastro", "Produto");
                _response.RotaSuccess = Url.Action("Index", "Produto");
                _response.NovoCadastro = true;
            }
            else
            {
                _response.Status = StatusResponse.Warning;
                _response.ErrorMessage.Add("Erro ao Cadastrar Produto. Tente Novamente Mais Tarde.");
            };
            var response = new Response();
            response.Status = _response.Status;
            response.View = ControllerExtensions.RenderPartialViewToString(this, "_ModalResponseMensagem", _response);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult Editar(int id)
        {
            _repositorio = new Repositorio<Produto>();
            return View(_repositorio.Get.FirstOrDefault(p => p.idProduto == id));
        }

        [HttpPost]
        public PartialViewResult Editar(Produto produto)
        {
            _response = new ResponseModelView();
            _repositorio = new Repositorio<Produto>();

            var produtoEditar = _repositorio.Get.FirstOrDefault(p => p.idProduto == produto.idProduto);
            
            if (produtoEditar != null)
            {
                produtoEditar.Status = produto.Status;
                produtoEditar.idTipoProduto = produto.idTipoProduto;
                produtoEditar.idUnidadeNegocio = produto.idUnidadeNegocio;
                produtoEditar.idUnidadeVenda = produto.idUnidadeVenda;

                if (_repositorio.Editar(produtoEditar))
                {
                    _response.SuccessMessage.Add("Produto Editado Com Succeso.");
                    _response.RotaSuccess = Url.Action("Index", "Produto");
                }
                else
                {
                    _response.Status = StatusResponse.Warning;
                    _response.ErrorMessage.Add("Erro ao Editar Produto. Tente Novamente Mais Tarde.");
                };
            }
            else
            {
                _response.ErrorMessage.Add("Produto informado é inexistente");
                _response.Status = StatusResponse.Warning;
            };

            return PartialView("_ModalResponseMensagem", _response);
        }

    }
}
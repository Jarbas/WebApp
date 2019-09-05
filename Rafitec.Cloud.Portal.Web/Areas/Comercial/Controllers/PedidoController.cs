using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Web.Areas.Admin.Controllers;
using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models;
using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models.Filtro;
using Rafitec.Cloud.Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {

        private Repositorio<Pedido> _repositorio;
        private ResponseModelView _response;

        [HttpGet]
        public ActionResult Index(int pagina = 1, FiltroPedido filtro = null)
        {

            _repositorio = new Repositorio<Pedido>();
            var model = new PedidoViewModel();
            model.Pedidos = Filtrar(filtro);
            model.Paginacao = new Paginacao();
            model.Paginacao.PaginaAtual = pagina;
            model.Pedidos = model.Paginacao.Paginar<Pedido>(model.Pedidos);
            model.Filtro = filtro;
            return View("Index", model);
        }

        private IEnumerable<Pedido> Filtrar(FiltroPedido filtro)
        {
            var pedidos = _repositorio.Get;
            if (filtro.Codigo != null)
                pedidos = pedidos.Where(p => p.idPedido == filtro.Codigo);
            if (filtro.idRepresentante != null)
                pedidos = pedidos.Where(p => p.idRepresentante == filtro.idRepresentante);
            if (filtro.Status != Utils.Enums.StatusPedido.None)
                pedidos = pedidos.Where(p => p.Status == filtro.Status);

            return pedidos;
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            var UsuarioLogado = UsuarioController.GetUsuarioLogado();
            var novoPedido = new Pedido();
            novoPedido.DataEmissao = DateTime.Now;
           /* if (UsuarioLogado.idEmpresaRepresentante != null)
                novoPedido.idRepresentante = UsuarioLogado.idUsuario; */
            return View(novoPedido);
        }
    
        [HttpPost]
        public PartialViewResult Cadastro(Pedido p)
        {
            _response = new ResponseModelView();
            CadastroValido(p);
            if (_response.Status == Utils.Enums.StatusResponse.Success)
            {
                _repositorio = new Repositorio<Pedido>();
                p.Status = Utils.Enums.StatusPedido.Aberto;
                p.DataEmissao = DateTime.Now;
               // p.idEmpresa = UsuarioController.GetUsuarioLogado().idEntidade;

                _repositorio.Adicionar(p);

                _response.SuccessMessage.Add("Pedido Cadastrado com sucesso.");
                _response.Status = Utils.Enums.StatusResponse.Success;
                _response.RotaSuccess = Url.Action("Dashboard", "Pedido", new { id = p.idPedido });
            }
            return PartialView("_ModalResponseMensagem", _response);

        }

        private void CadastroValido(Pedido p)
        {
            if (p.idCliente == 0) {
                _response.ErrorMessage.Add("Cliente não foi informado.");
                _response.Status = Utils.Enums.StatusResponse.Warning;
            }

            if (p.PrazoPagamento1 == null)
            {
                _response.ErrorMessage.Add("Um Prazo de Pagamento Deve Ser Informado.");
                _response.Status = Utils.Enums.StatusResponse.Warning;
            }
            
        }

        [HttpGet]
        public ActionResult Dashboard(int id)
        {
            _repositorio = new Repositorio<Pedido>();
            return View(_repositorio.Get.FirstOrDefault(p => p.idPedido == id));
        }

    }
}
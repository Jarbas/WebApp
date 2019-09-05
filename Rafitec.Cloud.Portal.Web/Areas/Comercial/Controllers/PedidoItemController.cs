using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Web.Areas.Admin.Controllers;
using Rafitec.Cloud.Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Controllers
{
    [Authorize]
    public class PedidoItemController : Controller
    {

        private Repositorio<PedidoItem> _repositorio;
        private ResponseModelView _response;


        [HttpGet]
        public ActionResult Cadastro(int id)
        {
            return View(new PedidoItem()
            {
                idPedido = id
            });

        }

        [HttpPost]
        public PartialViewResult Cadastro(PedidoItem item)
        {
            _response = new ResponseModelView();
            ValidarCadastro(item);

            if (_response.Status == Utils.Enums.StatusResponse.Success)
            {
                _repositorio = new Repositorio<PedidoItem>();
               // item.idEmpresa = UsuarioController.GetUsuarioLogado().idEntidade;
                item.Total = CalcularValorItemTotal(item.Quantidade, item.ValorUnitario);

                if (_repositorio.Adicionar(item))
                {
                    _response.NovoCadastro = true;
                    _response.RotaNovoCadastro = Url.Action("Cadastro", "PedidoItem", new { id = item.idPedido });
                    _response.RotaSuccess = Url.Action("Dashboard", "Pedido", new { id = item.idPedido });
                }
                else
                {
                    _response.Status = Utils.Enums.StatusResponse.Warning;
                    _response.ErrorMessage.Add("Erro ao cadastrar Item.");
                    _response.ErrorMessage.Add("Tente novamente mais tarde");
                }

            }

            return PartialView("_ModalResponseMensagem", _response);
        }

        [HttpGet]
        public double CalcularValorItemTotal(int quantidade, double valorUnitario)
        {
            return quantidade * valorUnitario;
        }

        private void ValidarCadastro(PedidoItem item)
        {

            if (item.idProduto <= 0)
            {
                _response.Status = Utils.Enums.StatusResponse.Warning;
                _response.ErrorMessage.Add("Produto Deve ser infromado.");
            }

            if (item.Quantidade <= 0)
            {
                _response.Status = Utils.Enums.StatusResponse.Warning;
                _response.ErrorMessage.Add("Quantidade informada é invalida.");
            }

            if (item.ValorUnitario <= 0)
            {
                _response.Status = Utils.Enums.StatusResponse.Warning;
                _response.ErrorMessage.Add("Valor unitário informada é invalida.");
            }
        }
        
        [HttpGet]
        public ActionResult Dashboard(IEnumerable<PedidoItem> itens)
        {
          //  _repositorio = new Repositorio<PedidoItem>();
            return PartialView("_Dashboard", itens);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            _repositorio = new Repositorio<PedidoItem>();
            return View(_repositorio.Get.FirstOrDefault(pi => pi.idPedidoItem == id));
        }

    }
}
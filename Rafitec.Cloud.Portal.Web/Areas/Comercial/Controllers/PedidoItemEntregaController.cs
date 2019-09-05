using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Web.Areas.Admin.Controllers;
using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Utils.ClassExtensions;
using Rafitec.Cloud.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Controllers
{
    [Authorize]
    public class PedidoItemEntregaController : Controller
    {

        private Repositorio<PedidoItemEntrega> _repositorio;
        private ResponseModelView _response;
        
        [HttpGet]
        public PartialViewResult Index(int id)
        {
            _repositorio = new Repositorio<PedidoItemEntrega>();
            return PartialView("_EntregaItem", _repositorio.Get.Where(pie => pie.idPedidoItem == id).OrderBy(pie=> pie.Sequencia));
        }

        [HttpGet]
        public PartialViewResult Cadastro(int id)
        {

            var idPedido = new Repositorio<PedidoItem>().Get.First(pi => pi.idPedidoItem == id).idPedido;
            return PartialView("_ModalCadastro", new PedidoItemEntrega() {
                idPedido = idPedido,
                idPedidoItem = id
            });
        }

        [HttpPost]
        public PartialViewResult Cadastro(PedidoItemEntrega entrega)
        {
            _response = new ResponseModelView();
            ValidarCadastro(entrega);
            if (_response.Status == Utils.Enums.StatusResponse.Success)
            {
                //entrega.idEmpresa = UsuarioController.GetUsuarioLogado().idEntidade;
                _repositorio = new Repositorio<PedidoItemEntrega>();
                entrega.Sequencia = _repositorio.Get.Where(pie => pie.idPedidoItem == entrega.idPedidoItem).Count() + 1;
                _repositorio.Adicionar(entrega);

                _response.SuccessMessage.Add("Entrega Cadastrada Com Sucesso.");
                _response.RotaSuccess = Url.Action("Editar", "PedidoItem", new { id = entrega.idPedidoItem});
            }
            return PartialView("_ModalResponseMensagem", _response);
        }

        public PartialViewResult Editar(PedidoItemEntrega entrega)
        {
            _response = new ResponseModelView();
            ValidarCadastro(entrega);
            if (_response.Status == Utils.Enums.StatusResponse.Success)
            {
                _repositorio = new Repositorio<PedidoItemEntrega>();
                var entregaEditar = _repositorio.Get.FirstOrDefault(pie => pie.idEntrega == entrega.idEntrega);
                if(entregaEditar != null)
                {
                    entregaEditar.Quantidade = entrega.Quantidade;
                    entregaEditar.DataEnterga = entrega.DataEnterga;
                    _repositorio.Editar(entregaEditar);

                    _response.SuccessMessage.Add("Entrega Editada Com Sucesso.");
                }
            }
            return PartialView("_ModalResponseMensagem", _response);
        }

        private void ValidarCadastro(PedidoItemEntrega entrega)
        {
            var repositorioItem = new Repositorio<PedidoItem>();
            var pedidoItem = repositorioItem.Get.FirstOrDefault(pi => pi.idPedidoItem == entrega.idPedidoItem);

            if (!pedidoItem.Produto.Importado)
            {
                _response.SetWarring("Esse produto ainda não foi importado para calcular a disponíbilidade de venda.");
                _response.SetWarring("Entre em contato com comercial da sua empresa.");
                return;
            }

            if (! entrega.DataEnterga.DataValida())
            {
                _response.SetWarring("Data de entrega não é valida.");
                return;
            }
                

            ValidarQuantidade(pedidoItem, entrega);
            ValidarDisponibilidade(pedidoItem, entrega);
        }

        private void ValidarDisponibilidade(PedidoItem item, PedidoItemEntrega entrega)
        {   
             var conexao = new ConexaoDB();
             var parametros = new Dictionary<string, object>() {
                 { "PRODUTO", item.Produto.idImportacao },
                 { "DATA_ENTREGA", entrega.DataEnterga },
                 { "QTDADE", entrega.Quantidade }
             };
             var retorno = conexao.ExecutaComandoComRetorno("SELECT DISPONIBILIDADE_VENDA(@PRODUTO, @DATA_ENTREGA, @QTDADE) AS DISPONIBILIDADE FROM DUAL", parametros).First();

             if (retorno.ContainsKey("DISPONIBILIDADE"))
             {
                 var disponibilidade = (DisponibilidadeVenda)Convert.ToInt32(retorno["DISPONIBILIDADE"]);
                 if (disponibilidade == DisponibilidadeVenda.Indisponivel)
                     _response.SetWarring("Disponíbilidade Excedida para data enformada.");
             }
             else
             {
                 _response.SetWarring("Disponíbilidade não calculada para produto informado.");
                 _response.SetWarring("Entre em contato com comercial da sua empresa.");
             }           
                
        }

        private void ValidarQuantidade(PedidoItem item, PedidoItemEntrega entrega)
        {
            if (entrega.Quantidade == 0)
                _response.SetWarring("Quantidade informada deve ser maior que zero.");

            if(item.Quantidade < entrega.Quantidade)
                _response.SetWarring("Quantidade infromada é maior que a quantidade do Item.");
        }


        public PartialViewResult Dashboard(IEnumerable<PedidoItemEntrega> entregas)
        {
            return PartialView("_Dashboard", entregas);
        }

        [HttpGet]
        public PartialViewResult Dashboard(int id)
        {
            var repositorio = new Repositorio<PedidoItemEntrega>();

            return PartialView("_Dashboard", repositorio.Get.Where(pie => pie.idPedidoItem == id));
        }
    }
}
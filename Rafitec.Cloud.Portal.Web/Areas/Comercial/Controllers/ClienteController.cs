using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models;
using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Utils.Fiscal;
using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models.Filtro;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {

        private Repositorio<Entidade> _repositorio;
        private ResponseModelView response;

        private void IniciaResponse()
        {

            response = new ResponseModelView();
            response.RotaSuccess = Url.Action("Index", "Cliente");
        }

        private bool Validar(Entidade Cliente)
        {
            IniciaResponse();
            ValidarCnpjCpf(Cliente);

                
            return (response.Status == StatusResponse.Success);
        }

        private void ValidarCnpjCpf(Entidade Cliente)
        {
            if (Cliente.Pessoa == EntidadePessoa.Fisica)
            {
                Cliente.CnpjCpf = Cpf.Montar(Cliente.CnpjCpf);
                if (! Cpf.Valido(Cliente.CnpjCpf))
                {
                    response.Status = StatusResponse.Warning;
                    response.ErrorMessage.Add("Número de Cpf Invalido.");
                    return;
                }
            }else
            {
                Cliente.CnpjCpf = Cnpj.Montar(Cliente.CnpjCpf);
                if (! Cnpj.Valido(Cliente.CnpjCpf))
                {
                    response.Status = StatusResponse.Warning;
                    response.ErrorMessage.Add("Número de Cnpj Invalido.");
                    return;
                }
            };

            ValidarCnpjCpfExisteDb(Cliente);
        }

        private void ValidarCnpjCpfExisteDb(Entidade Cliente)
        {
            var entidadeExistente = _repositorio.Get.FirstOrDefault(e => e.CnpjCpf == Cliente.CnpjCpf && e.TipoEntidade == EntidadeTipo.Cliente);
            if (entidadeExistente != null && entidadeExistente.idEntidade != Cliente.idEntidade)
            {

                response.Status = StatusResponse.Warning;
                if (Cliente.Pessoa == EntidadePessoa.Fisica)
                    response.ErrorMessage.Add($"Cpf informado ja esta cadastro para o cliente: {entidadeExistente.RazaoSocial}");
                else
                    response.ErrorMessage.Add($"Cnpj informado ja esta cadastro para o cliente: {entidadeExistente.RazaoSocial}");
            }
        }

       [HttpGet]
        public ActionResult Index(int pagina, FiltroCliente filtro = null)
        {
            _repositorio = new Repositorio<Entidade>();
            var ClienteModel = new ClienteModelView();
            ClienteModel.Clientes = Filtrar(filtro);
            ClienteModel.Paginacao = new Paginacao();
            ClienteModel.Paginacao.PaginaAtual = pagina;
            ClienteModel.Clientes = ClienteModel.Paginacao.Paginar<Entidade>(ClienteModel.Clientes, filtro != null);
            ClienteModel.Filtro = filtro;

         /*   if (filtro == null)
                ClienteModel.Filtro = new FiltroCliente() { Status = EntidadeSituacao.None, TipoCliente = TipoCliente.None };
            else    */    
                
            return View(ClienteModel);
        }


        private IEnumerable<Entidade> Filtrar(FiltroCliente filtro = null)
        {

            var clientes = _repositorio.Get.Where(c => c.TipoEntidade == EntidadeTipo.Cliente);

            if (filtro != null)
            {
                if (filtro.CnpjCpf != null)
                    clientes = clientes.Where(c => c.CnpjCpf == filtro.CnpjCpf);
                if (filtro.idRepresentante > 0)
                    clientes = clientes.Where(c => c.idRepresentante == filtro.idRepresentante);
                if (filtro.TipoCliente != TipoCliente.None)
                    clientes = clientes.Where(c => c.TipoCliente == filtro.TipoCliente);
                if (filtro.Status != EntidadeSituacao.None)
                    clientes = clientes.Where(c => c.Situacao == filtro.Status);
                if (!String.IsNullOrEmpty(filtro.RazaoSocial))
                    clientes = clientes.Where(c => c.RazaoSocial.Contains(filtro.RazaoSocial));
            }
            return clientes;

        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            return View("Create", new Entidade() {DataCadastramento = DateTime.Now });
        }
        
        [HttpPost]
        public PartialViewResult Cadastro(Entidade Cliente)
        {
            _repositorio = new Repositorio<Entidade>();
            if (Validar(Cliente))
            {
                Cliente.TipoEntidade = EntidadeTipo.Cliente;
                Cliente.DataCadastramento = DateTime.Now;
                _repositorio.Adicionar(Cliente);
                response.SuccessMessage.Add("Cliente Cadastrado com Succeso.");
            }
            return PartialView("_ModalResponseMensagem", response);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            _repositorio = new Repositorio<Entidade>();
            return View("Editar", _repositorio.Get.FirstOrDefault(e => e.idEntidade == id));
        }

        private Entidade CarregaPropertyEdicao(Entidade Cliente)
        {
            var clienteEditar = _repositorio.Get.FirstOrDefault(c => c.idEntidade == Cliente.idEntidade);
            clienteEditar.TipoCliente = Cliente.TipoCliente;
            clienteEditar.TelefoneCelular = Cliente.TelefoneCelular;
            clienteEditar.TelefoneRamal = Cliente.TelefoneRamal;
            clienteEditar.Telefone = Cliente.Telefone;
            clienteEditar.Endereco = Cliente.Endereco;
            clienteEditar.EnderecoComplemento = Cliente.EnderecoComplemento;
            clienteEditar.EnderecoNumero = Cliente.EnderecoNumero;
            clienteEditar.Bairro = Cliente.Bairro;
            clienteEditar.Cep = Cliente.Cep;
            clienteEditar.idCidade = Cliente.idCidade;
            clienteEditar.idPais = Cliente.idPais;
            clienteEditar.idEstado = Cliente.idEstado;
            clienteEditar.idRepresentante = Cliente.idRepresentante;
            clienteEditar.InscricaoEstadual = Cliente.InscricaoEstadual;
            clienteEditar.InscricaoMunicipal = Cliente.InscricaoMunicipal;
            clienteEditar.InscricaoProdutorRural = Cliente.InscricaoProdutorRural;
            clienteEditar.LimiteCredito = Cliente.LimiteCredito;
            clienteEditar.Observacoes = Cliente.Observacoes;
            clienteEditar.Suframa = Cliente.Suframa;
            clienteEditar.SuspensaoIpi = Cliente.SuspensaoIpi;
            clienteEditar.Venda = Cliente.Venda;
            clienteEditar.Email = Cliente.Email;
            clienteEditar.EmailNfe = Cliente.EmailNfe;
            return clienteEditar;

        }

        [HttpPost]
        public PartialViewResult Editar(Entidade Cliente)
        {
            _repositorio = new Repositorio<Entidade>();
            IniciaResponse();
            //if (Validar(clienteEditar))
            if (_repositorio.Editar(CarregaPropertyEdicao(Cliente)))
            {
                response.SuccessMessage.Add("Cliente Editado com sucesso.");
                return PartialView("_ModalResponseMensagem", response);
            }                
            else
            {
                response.Status = StatusResponse.Warning;
                response.ErrorMessage.Add($"Erro ao editar Cliente {Cliente.RazaoSocial}. Tente novamente mais tarde.");
                return PartialView("_ModalResponseMensagem", response);
            }
        }

    }
}
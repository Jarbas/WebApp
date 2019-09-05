using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Web.Areas.TecnologiaInformacao.Models.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.Areas.TecnologiaInformacao.Controllers
{
    [Authorize]
    public class HelpDeskController : Controller
    {

        private Repositorio<OsTi> _repositorio;
        private Web.Models.ResponseModelView _response;
        [HttpGet]
        public ActionResult Index(int pagina = 1, Models.Filtro.HelpDeskFiltro filtro = null)
        {

            _repositorio = new Repositorio<OsTi>();
            var model = new Models.HelpDeskConsultaViewModel();
            model.Paginacao.PaginaAtual = pagina;
            model.Filtro = filtro;
            model.Lista = Filtrar(filtro);
            model.Lista = model.Paginacao.Paginar(model.Lista);

            return View(model);
        }

        public ActionResult Filtro(HelpDeskFiltro filtro)
        {
            return PartialView("_Filtro", filtro);
        }

        private IEnumerable<OsTi> Filtrar(HelpDeskFiltro filtro)
        {
            var chamados = _repositorio.Get.Where(ot => ot.ChamadoWeb == true);


            if (filtro.Codigo != null)
                chamados = chamados.Where(ot => ot.IdOsTi == filtro.Codigo);

            if (!string.IsNullOrEmpty(filtro.Descricao))
                chamados = chamados.Where(ot => ot.Titulo.ToLower().Contains(filtro.Descricao.ToLower()));

            if (filtro.IdStatus != null)
                chamados = chamados.Where(ot => ot.IdStatus == filtro.IdStatus);

            if (filtro.IdUsuario != null)
                chamados = chamados.Where(ot => ot.IdUsuario == filtro.IdUsuario);

            if (filtro.IdSetor != null)
                chamados = chamados.Where(ot => ot.IdSetor == filtro.IdSetor);

            return chamados;
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            var usuarioLogado = Aplicacao.UsuarioLogado;
            var model = new OsTi()
            {
                IdSetor = usuarioLogado.IdSetor,
                IdUsuario = usuarioLogado.idUsuario,
                IdStatus = 1,
                DataAbertura = DateTime.Now,
                Grupo = Utils.Enums.GrupoOsTi.HARDWARE,
                MaquinaParada = false
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Validar(int id)
        {
            _repositorio = new Repositorio<OsTi>();
            var model = _repositorio.Get.FirstOrDefault(ot => ot.IdOsTi == id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Validar(OsTi param)
        {
           
            _response = new Web.Models.ResponseModelView();
            _repositorio = new Repositorio<OsTi>();

            ValidarValidacaoChamado(param);
            var chamadoDB = _repositorio.Get.FirstOrDefault(ot => ot.IdOsTi == param.IdOsTi);

            if ((chamadoDB.IdStatus != 7) && (chamadoDB.IdStatus != 6))
                _response.SetWarring("Chamado ainda não foi finalizado. Necessario esta finalizado para gerar uma avaliação.");

            if (_response.IsResponseValido())
            {
                try
                {
                    chamadoDB.Avaliacao = param.Avaliacao;
                    if (param.Avaliacao == Utils.Enums.AvaliacaoOsTi.REVISAR)
                        chamadoDB.IdStatus = 2;
                    else chamadoDB.IdStatus = 6;

                    _repositorio.Editar(chamadoDB);
                    _response.SetSussess("Chamado Avaliado com Sucesso.");
                    _response.RotaSuccess = Url.Action("Index", "HelpDesk");

                }
                catch(Exception e)
                {

                    if (Aplicacao.UsuarioLogado.Admin)
                        _response.SetWarring($"Erro Fatal Para Validar o Chamado. Erro ==>{e.ToString()}");
                    else
                        _response.SetWarring("Erro Fatal Para Validar o Chamado. Entre em contato com o suporte Técnico");
                }


            }

            return PartialView("_ModalResponseMensagem", _response);
        }

        private void ValidarValidacaoChamado(OsTi param)
        {
            if (param.Avaliacao == Utils.Enums.AvaliacaoOsTi.NAO_EXISTE)
                _response.SetWarring("Informe a Validação do chamado");

            if (string.IsNullOrEmpty(param.Observacao))
                _response.SetWarring("Informe uma observação");

        }

        [HttpPost]
        public ActionResult Cadastro(OsTi param)
        {
            _response = new Web.Models.ResponseModelView();
            ValidarCadastro(param);
            if (_response.IsResponseValido())
            {
                try
                {
                    var usuarioLogado = Aplicacao.UsuarioLogado;
                    _repositorio = new Repositorio<OsTi>();
                    param.IdOsTi = _repositorio.GetSequencia("IdOsTi");
                    param.IdSetor = usuarioLogado.IdSetor;
                    param.IdUsuario = usuarioLogado.idUsuario;
                    param.DataAbertura = DateTime.Now;
                    param.IdStatus = 1;
                    param.ChamadoWeb = true;
                    _repositorio.Adicionar(param);
                    _response.SetSussess("Chamado Aberto Com Sucesso.");
                    _response.RotaSuccess = Url.Action("Index", "HelpDesk");
                }
                catch (Exception e)
                {
                    if (Aplicacao.UsuarioLogado.Admin)
                        _response.SetWarring($"Erro Fatal Para Salvar o Chamado. Erro ==>{e.ToString()}");
                    else
                       _response.SetWarring("Erro Fatal Para Salvar o Chamado. Entre em contato com o suporte Técnico");
                }
            }


            return PartialView("_ModalResponseMensagem", _response);
        }

        private void ValidarCadastro(OsTi param)
        {
            if (string.IsNullOrEmpty(param.Titulo))
                _response.SetWarring("Informe o Título do chamado");


            if (string.IsNullOrEmpty(param.Descricao))
                _response.SetWarring("Informe a descrição do problema do chamado");            
        }
    }
}
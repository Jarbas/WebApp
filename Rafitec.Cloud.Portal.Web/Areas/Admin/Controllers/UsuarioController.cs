using System.Linq;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Web.Areas.Admin.Models;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Web.Models;
using System;
using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Utils.Seguranca;
using System.Web;
using System.Collections.Generic;
using Rafitec.Cloud.Portal.Web.Objeto.Filtro;

namespace Rafitec.Cloud.Portal.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {

        private Repositorio<Usuario> _repositorio;
        private ResponseModelView _response;
      

        public static Usuario UsuarioLogado { get; private set; }

        public static Usuario GetUsuarioLogado()
        {
            //if (UsuarioLogado == null)
            SetUsuarioLogado();
            return UsuarioLogado;
        }

        private static void SetUsuarioLogado()
        {
            UsuarioLogado = new Repositorio<Usuario>().Get.FirstOrDefault(u => u.Email == Cookie.GetValorUsuarioLogado());
        }

     /*   public static string[] GetPermissaoUsuario()
        {
            var rules = GetUsuarioLogado().Permissoes;
            if (!string.IsNullOrEmpty(rules))
                return rules.Split(',');
            return null;
        }*/

        [HttpGet, Authorize(Roles ="Admin")]
        public ActionResult Index(int pagina = 1, FiltroDefault filtro = null)
        {
            
            var _modelUsuario = new UsuarioModelView();
            _modelUsuario.Usuarios = Filtrar(filtro);
            _modelUsuario.Filtro = filtro;
            _modelUsuario.Paginacao = new Paginacao();
            _modelUsuario.Paginacao.PaginaAtual = pagina;
            _modelUsuario.Usuarios = _modelUsuario.Paginacao.Paginar<Usuario>(_modelUsuario.Usuarios);
            
            return View("Index", _modelUsuario);
        }

        public IEnumerable<Usuario> Filtrar(FiltroDefault filtro)
        {
            _repositorio = new Repositorio<Usuario>();
            var list = _repositorio.Get;

            if (filtro.Codigo != null)
                list = list.Where(u => u.idUsuario == filtro.Codigo);
            if (!string.IsNullOrEmpty(filtro.Descricao))
                list = list.Where(u => u.Nome.Contains(filtro.Descricao));
            return list;
        }


        [HttpGet, Authorize(Roles = "Admin")]
        public ActionResult Cadastro()
        {
            return View("Create", new Usuario());
        }



        [HttpPost, Authorize(Roles = "Admin")]
        public PartialViewResult Cadastro(Usuario newUser, HttpPostedFileBase imagem = null)
        {

            _response = new ResponseModelView();
            _repositorio = new Repositorio<Usuario>();
            ValidarCadastro(newUser);


         

            if (_response.Status == StatusResponse.Success)
            {                
                newUser.DataCadastro = DateTime.Now;
               //  newUser.idEntidade = GetUsuarioLogado().idEntidade;
               //  newUser = SetImagemUsuario(newUser, imagem);

                newUser.Senha = new CriptografiaMD5().Criptografar(newUser.Senha);

                if (_repositorio.Adicionar(newUser))
                {
                    _response.SuccessMessage.Add("Usuário gravado com sucesso.");
                    _response.RotaSuccess = Url.Action("Index", "Usuario");
                }
                else
                {
                    _response.ErrorMessage.Add("Erro no gravar novo usuário");
                    _response.Status = StatusResponse.Warning;
                }

            }
            return PartialView("_ModalResponseMensagem", _response);    
        }

        private void ValidarCadastro(Usuario newUser)
        {
            
            if (string.IsNullOrEmpty(newUser.Senha))
            {
                _response.Status = StatusResponse.Warning;
                _response.ErrorMessage.Add("Preencha uma senha para o usuário.");
            }

            if (string.IsNullOrEmpty(newUser.Nome))
            {
                _response.Status = StatusResponse.Warning;
                _response.ErrorMessage.Add("Preencha o nome do usuário.");
            }

            if (string.IsNullOrEmpty(newUser.Email))
            {
                _response.Status = StatusResponse.Warning;
                _response.ErrorMessage.Add("Preencha o email do usuário.");
            }

          /*  if (string.IsNullOrEmpty(newUser.Sobrenome))
            {
                _response.Status = StatusResponse.Warning;
                _response.ErrorMessage.Add("Preencha o sobrenome do usuário.");
            }*/

            var usuarios = _repositorio.Get;
            var userDbComEmail = usuarios.FirstOrDefault(u => u.Email == newUser.Email);
            if (userDbComEmail != null)
            {
                _response.Status = StatusResponse.Warning;
                _response.ErrorMessage.Add("Email Já Cadastrado no Bando de dados.");
            }

            var userDbComLogin = usuarios.FirstOrDefault(u => u.Login == newUser.Login);
            if (userDbComLogin != null)
            {
                _response.Status = StatusResponse.Warning;
                _response.ErrorMessage.Add("Login Já Cadastrado no Bando de dados.");
            }
        }

      /*  private Usuario SetImagemUsuario(Usuario user, HttpPostedFileBase imagem)
        {
            if (imagem != null)
            {
                user.ImagemTipo = imagem.ContentType;
                user.Imagem = new byte[imagem.ContentLength];
                imagem.InputStream.Read(user.Imagem, 0, imagem.ContentLength);
            }
            return user;
        }*/

        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            var user = _repositorio.Get.Where(u => u.idUsuario == id);
            return PartialView("Detalhe", user);
        }

        [HttpGet]
        public string ValidarLogin(string login)
        {
            _repositorio = new Repositorio<Usuario>();
            var loginDb = _repositorio.Get.FirstOrDefault(u => u.Login.ToLower() == login.ToLower());

            if (loginDb == null)
                return "t";
            else return "f";

        }

        [HttpGet]
        public ActionResult Perfil()
        {
            _repositorio = new Repositorio<Usuario>();
            return View("Perfil", _repositorio.Get.FirstOrDefault(u => u.idUsuario == GetUsuarioLogado().idUsuario && u.Status == Status.Ativo));
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public ActionResult Editar(Usuario user, HttpPostedFileBase FormImagem = null)  
        {
           
            _response = new ResponseModelView();

            if (_response.Status == StatusResponse.Success)
            {
                _repositorio = new Repositorio<Usuario>();
                var userAlterar = _repositorio.Get.FirstOrDefault(u => u.idUsuario == user.idUsuario);

                if (userAlterar != null)
                {
                    userAlterar.Nome = user.Nome;
                   // userAlterar.Sobrenome = user.Sobrenome;

                  //  userAlterar = SetImagemUsuario(userAlterar, FormImagem);


                    if (_repositorio.Editar(userAlterar))
                    {
                        _response.SuccessMessage.Add("Perfil Alterado com sucesso.");
                        _response.RotaSuccess = Url.Action("Index", "Dashboard", new { Area = "" });
                    } else
                    {
                        _response.Status = StatusResponse.Warning;
                        _response.ErrorMessage.Add("Falha ao gravar alterações no perfil do Usuário");
                    }
                }
            }

            return PartialView("_ModalResponseMensagem", _response);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public string ValidarEmail(string email)
        {
            _repositorio = new Repositorio<Usuario>();
            var emailDb = _repositorio.Get.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (emailDb == null)
                return "t";
            else return "f";

        }

        [HttpGet]
        public PartialViewResult AlterarSenha()
        {
            return PartialView("_AlterarSenha", new AlteracaoSenhaViewModel());
        }

        [HttpPost]
        public PartialViewResult AlterarSenha(AlteracaoSenhaViewModel alteracao)
        {
            _repositorio = new Repositorio<Usuario>();
            var usuarioDb = _repositorio.Get.FirstOrDefault(u => u.Email == Cookie.GetValorUsuarioLogado());
            var criptoMd5 = new CriptografiaMD5();

            if (!String.Equals(usuarioDb.Senha, criptoMd5.Criptografar(alteracao.SenhaAtual)))
            {
                ViewBag.MensagemAlteracaoSenha = "Senha Atual Invalida";
                return PartialView("_AlterarSenha", new AlteracaoSenhaViewModel());
            }
            else if (!String.Equals(alteracao.NovaSenha, alteracao.RepeticaoNovaSenha))
            {
                ViewBag.MensagemAlteracaoSenha = "As Senhas Não Conferem";
                return PartialView("_AlterarSenha", new AlteracaoSenhaViewModel());
            }
            usuarioDb.Senha = criptoMd5.Criptografar(alteracao.NovaSenha);
            _repositorio.Editar(usuarioDb);
            ViewBag.MensagemAlteracaoSenha = "True";
            return PartialView("_AlterarSenha", new AlteracaoSenhaViewModel());

        }

        [HttpGet]
        public PartialViewResult Detalhe()
        {
            return PartialView(GetUsuarioLogado());
        }

        [HttpGet]
        public FileContentResult ObterImagem(int idUsuario)
        {
            _repositorio = new Repositorio<Usuario>();
            Usuario usuario = _repositorio.Get.FirstOrDefault(u => u.idUsuario == idUsuario);

          /*  if ((usuario != null) && (usuario.Imagem != null))
            {
                return File(usuario.Imagem, usuario.ImagemTipo);
            }*/
            return null;
        }

        [HttpGet]
        public ActionResult Permissao(int id)
        {
            _repositorio = new Repositorio<Usuario>();
            var user = _repositorio.Get.FirstOrDefault(u => u.idUsuario == id);
            return View(user);
        }
    }
}
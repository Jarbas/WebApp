﻿using System;
using System.Linq;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Utils.Seguranca;
using Rafitec.Cloud.Utils.Enums;

using System.Web.Security;

namespace Rafitec.Cloud.Portal.Web.Controllers
{
    public class LoginController : Controller
    {
        private Repositorio<Usuario> _repositorio;
        private Usuario _usuarioDb;

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Login(Usuario login)
        {
            
            CarregarUsuarioBancoDeDados(login);
            if (ExisteUsuarioBancoDeDados())
            {
               /* if ((ExpeirouTentativas()) && (ExpirouTempoLimite()))
                {
                    CarregarViewBagErroLogin("Número de tentativas expirou. Tente Novamente Mais Tarde");
                    return Login();
                }*/

                if (ValidarSenha(login))
                {
                    AutenticarUsuario();

                    return RedirectToAction("App", "Dashboard");
//                    return RedirectToAction("Index", "HelpDesk", new { Area = "TecnologiaInformacao", IdSetor = _usuarioDb.IdSetor } );

                }
                //else AtualizarTentativaErroLogin();
            }
            CarregarViewBagErroLogin("E-mail ou Senha Invalida");
            return Login();
        }

        [HttpPost]
        public ActionResult LoginCodigo(Usuario login)
        {

            var teste = login.idUsuario;
            CarregarUsuarioBancoDeDados(login);
            if (ExisteUsuarioBancoDeDados())
            {
                if (ValidarSenha(login))
                {
                    AutenticarUsuario();
                    return RedirectToAction("App", "Dashboard");
                }
            }
            CarregarViewBagErroLogin("Código Invalido");
            return Login();
        }

        private void AutenticarUsuario()
        {
           // AtualizaTentativaLoginSucesso();
            FormsAuthentication.SetAuthCookie(_usuarioDb.Email, false);
            
        }

        private void CarregarViewBagErroLogin(string Erro)
        {
            ViewBag.ErroLogin = Erro;
        }

       /* private void AtualizaTentativaLoginSucesso()
        {
            _usuarioDb.TentativaLogin = 0;
            _repositorio.Editar(_usuarioDb);
        }*/

       /* private void AtualizarTentativaErroLogin()
        {
            _usuarioDb.DataTentativaLogin = DateTime.Now;
            _usuarioDb.TentativaLogin += 1;
            _repositorio.Editar(_usuarioDb);
        }*/

        private bool ValidarSenha(Usuario u)
        {

            string senhaCript;
            MhsCript.Criptografar(out senhaCript, u.Senha);

            return (_usuarioDb.Senha == senhaCript);
        }

      /*  private bool ExpirouTempoLimite()
        {
            var tempoDiferenca = DateTime.Now - _usuarioDb.DataTentativaLogin;
            return (tempoDiferenca.Hours < 1);
        }

        private bool ExpeirouTentativas()
        {
            return (_usuarioDb.TentativaLogin > 3);
        }*/

        private bool ExisteUsuarioBancoDeDados()
        {
            return (_usuarioDb != null);
        }

        private void CarregarUsuarioBancoDeDados(Usuario usuario)
        {
             _repositorio = new Repositorio<Usuario>();
            var useres = _repositorio.Get;
            _usuarioDb = useres.FirstOrDefault(u => (u.Email == usuario.Email || u.Login == usuario.Email) && (u.Status == Status.Ativo));
        }

        private void CarregarCodigoUsuarioBancoDeDados(Usuario usuario)
        {
            _repositorio = new Repositorio<Usuario>();
            var users = _repositorio.Get;
            _usuarioDb = users.FirstOrDefault(u => ((u.idUsuario == usuario.idUsuario)  && (u.Status == Status.Ativo)));
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }



    }
}
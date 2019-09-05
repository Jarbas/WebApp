using System.Linq;
using System.Web.Http;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Utils.Seguranca;

namespace Rafitec.Cloud.Api.Areas.Admin.Controllers
{
    public class UsuarioController : ApiController
    {
            private Repositorio<Usuario> _repositorio;
            public bool ValidarUsuarioSenha(string User, string Senha)
            {
                _repositorio = new Repositorio<Usuario>();
                var usuarios = _repositorio.Get;
                var user = usuarios.FirstOrDefault(u => u.Email == User && u.Senha == new CriptografiaMD5().Criptografar(Senha));

                if (user == null)
                    user = usuarios.FirstOrDefault(u => u.Email == User && u.Senha == Senha);

                return (user != null);
            }

            [HttpGet, Authorize]
            public IHttpActionResult Get(string email)
            {
                _repositorio = new Repositorio<Usuario>();
                var user = from u in _repositorio.Get
                           where (u.Email == email)
                           select new { u.idUsuario, u.idEmpresa, u.Nome, u.Email };
                return Ok(user);
            }
        
    }
}
using System.Collections.Generic;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Portal.Web.Objeto.Filtro;

namespace Rafitec.Cloud.Portal.Web.Areas.Admin.Models
{
    public class UsuarioModelView : BaseConsultaViewModel
    {
        public IEnumerable<Usuario> Usuarios { get; set; }
       // public Paginacao Paginacao { get; set; }    
        public FiltroDefault Filtro { get; set; }
    }

    public class AlteracaoSenhaViewModel
    {
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
        public string RepeticaoNovaSenha { get; set; }
    }
}
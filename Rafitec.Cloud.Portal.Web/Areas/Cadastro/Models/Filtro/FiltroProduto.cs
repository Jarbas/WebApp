using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Portal.Web.Objeto.Filtro;

namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro.Models.Filtro
{
    public class FiltroProduto : FiltroDefault
    {
        public int? idCliente { get; set; }
        public Status Status { get; set; } = Status.None;
    }
}
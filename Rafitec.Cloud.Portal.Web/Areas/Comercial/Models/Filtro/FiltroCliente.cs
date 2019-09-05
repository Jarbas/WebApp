using Rafitec.Cloud.Portal.Web.Objeto.Filtro;
using Rafitec.Cloud.Utils.Enums;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Models.Filtro
{
    public class FiltroCliente : FiltroEntidade
    {
        public TipoCliente TipoCliente { get; set; } = TipoCliente.None;
    }
}
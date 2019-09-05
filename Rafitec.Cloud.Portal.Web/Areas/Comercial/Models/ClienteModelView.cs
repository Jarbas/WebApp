using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Utils.Enums;
using System.Collections.Generic;

using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models.Filtro;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Models
{
    public class ClienteModelView : BaseConsultaViewModel
    {
        public IEnumerable<Entidade> Clientes { get; set; }
    //      public PaginacaoNextPrior Paginacao { get; set; }
        public FiltroCliente Filtro { get; set; }
    }

}
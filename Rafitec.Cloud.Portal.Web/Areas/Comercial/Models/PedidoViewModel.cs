using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using System.Collections.Generic;
using Rafitec.Cloud.Portal.Web.Areas.Comercial.Models.Filtro;


namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Models
{
    public class PedidoViewModel : BaseConsultaViewModel
    {
        public IEnumerable<Pedido> Pedidos { get; set; }
        public FiltroPedido Filtro { get; set; }
    }


}
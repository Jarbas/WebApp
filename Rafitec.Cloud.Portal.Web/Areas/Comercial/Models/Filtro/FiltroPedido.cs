using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rafitec.Cloud.Portal.Web.Objeto.Filtro;
using Rafitec.Cloud.Utils.Enums;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Models.Filtro
{
    public class FiltroPedido : FiltroDefault
    {
        public StatusPedido Status { get; set; } = StatusPedido.None;
        public int? idRepresentante { get; set; }
        public int? idCliente { get; set; }
    }
}
using Rafitec.Cloud.Portal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Models
{
    public class PedidoItemEntergaModelView
    {
        public string DescricaoProduto { get; set; }
        public PedidoItemEntrega PedidoItemEntrega { get; set; }
    }
}
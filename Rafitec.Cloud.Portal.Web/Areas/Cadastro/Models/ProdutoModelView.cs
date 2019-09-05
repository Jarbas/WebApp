using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Web.Areas.Cadastro.Models.Filtro;
using Rafitec.Cloud.Portal.Web.Models;
using Rafitec.Cloud.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Areas.Cadastro.Models
{
    public class ProdutoModelView
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public Paginacao Paginacao { get; set; }
        public FiltroProduto Filtro { get; set; }
    }
}
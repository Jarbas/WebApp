using Rafitec.Cloud.Portal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Models
{
    public class ConsultaViewModel<T> where T : BaseEntidade
    {
        public Paginacao Paginacao { get; set; }
        public IEnumerable<T> Lista { get; set; }
    }
}
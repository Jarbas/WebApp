using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Web.Objeto.Filtro;
using Rafitec.Cloud.Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Areas.Comercial.Models
{
    public class RepresentanteViewModel<T> : ConsultaViewModel<T> where T : BaseEntidade
    {
        public FiltroDefault Filtro { get; set; }
    }
    
}
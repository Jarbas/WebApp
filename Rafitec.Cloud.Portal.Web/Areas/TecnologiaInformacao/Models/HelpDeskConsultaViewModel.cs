
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Web.Models;
using System.Collections.Generic;

namespace Rafitec.Cloud.Portal.Web.Areas.TecnologiaInformacao.Models
{
    public class HelpDeskConsultaViewModel 
    {
        public Filtro.HelpDeskFiltro Filtro { get; set; }
        public IEnumerable<OsTi> Lista { get; set; }
        public Paginacao Paginacao = new Paginacao();
    }
}
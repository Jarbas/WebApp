using Rafitec.Cloud.Portal.Web.Objeto.Filtro;

namespace Rafitec.Cloud.Portal.Web.Areas.TecnologiaInformacao.Models.Filtro
{
    public class HelpDeskFiltro : FiltroDefault
    {
        public int? IdStatus { get; set; }
        public int? IdSetor { get; set; }
        public int? IdUsuario { get; set; }
        
    }
}
using Rafitec.Cloud.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Objeto.Filtro
{
    public class FiltroEntidade : FiltroDefault
    {
        public EntidadeSituacao Status { get; set; } = EntidadeSituacao.None;
        public string CnpjCpf { get; set; }
        public int? idRepresentante { get; set; }
        public string RazaoSocial { get; set; }
    }
}
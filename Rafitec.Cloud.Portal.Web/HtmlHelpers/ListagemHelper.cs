using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using System.Text;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.HtmlHelpers
{
    public static class ListagemHelper
    {
        public static MvcHtmlString Listar<T>(this HtmlHelper helper, string Value, string Descricao) where T : BaseEntidade
        {
            var Repositorio = new Repositorio<T>();
            var result = new StringBuilder();

            foreach (var r in Repositorio.Get)
            {
                var _value = r.GetType().GetProperty(Value).GetValue(r);
                var _html = r.GetType().GetProperty(Descricao).GetValue(r);

                var tag = new TagBuilder("option");
                tag.MergeAttribute("value", _value.ToString());
                tag.InnerHtml = _html.ToString();
                result.Append(tag);
            }
            return MvcHtmlString.Create(result.ToString());
        }




    }
}
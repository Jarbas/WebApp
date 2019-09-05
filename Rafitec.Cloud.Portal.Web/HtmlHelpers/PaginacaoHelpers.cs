using System;
using System.Text;
using System.Web.Mvc;
using Rafitec.Cloud.Portal.Web.Models;

namespace Rafitec.Cloud.Portal.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder();
            for (int i = 1; i <= paginacao.TotalPagina; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href",paginaUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                tag.AddCssClass("btn-xs");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }

        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, string paginaUrl, object filter)
        {
            StringBuilder resultado = new StringBuilder();
            var urlFilter = FilterDefaultHelpers.ToQueryString(filter);
            for (int i = 1; i <= paginacao.TotalPagina; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                if (!string.IsNullOrEmpty(urlFilter))
                    tag.MergeAttribute("href", $"{paginaUrl.Replace($"/{paginacao.PaginaAtual.ToString()}", null)}/{i}/?{urlFilter}");
                else
                    tag.MergeAttribute("href", $"{paginaUrl.Replace($"/{paginacao.PaginaAtual.ToString()}", null)}/{i}");
                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                tag.AddCssClass("btn-xs");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }


    }
}
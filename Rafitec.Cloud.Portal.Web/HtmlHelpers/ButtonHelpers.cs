using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafitec.Cloud.Portal.Web.HtmlHelpers
{
    public static class ButtonHelpers
    {
        private static string MontarDescricaoButton(string descricao)
        {
            
            if (!String.IsNullOrEmpty(descricao))
            {
                var desc = new TagBuilder("i");
                desc.AddCssClass("desc-btn");
                desc.InnerHtml += descricao;

                return desc.ToString();
            }
            return String.Empty;
        }
        

        public static MvcHtmlString ButtonFiltro(this HtmlHelper html, string descricao = "")
        {
            var btn = new TagBuilder("button");
            var icon = new TagBuilder("i");  

            icon.AddCssClass("glyphicon glyphicon-filter");       

            btn.InnerHtml += icon.ToString();
            btn.InnerHtml += MontarDescricaoButton(descricao);

            btn.AddCssClass("btn btn-primary btn-minimizar btn-xs");
            btn.Attributes.Add("type", "button");
            return MvcHtmlString.Create(btn.ToString());
        }

        public static MvcHtmlString ButtonCadastro(this HtmlHelper html, string action, string descricao, object htmlAttribute)
        {
            var btn = new TagBuilder("a");
            var icon = new TagBuilder("i");
            var desc = new TagBuilder("i");
            var htmlAtributo = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttribute);


            icon.AddCssClass("glyphicon glyphicon-plus-sign");
            desc.AddCssClass("desc-btn");
            desc.InnerHtml += descricao;

            btn.InnerHtml += icon.ToString();
            btn.InnerHtml += desc.ToString();

            foreach(var prop in htmlAtributo)
                btn.Attributes.Add(prop.Key, prop.Value.ToString());
            
            btn.AddCssClass("btn btn-default  btn-xs");
            btn.Attributes.Add("href", action);
            return MvcHtmlString.Create(btn.ToString());
        }

        public static MvcHtmlString ButtonCadastro(this HtmlHelper html, string action, object htmlAttribute)
        {
            return ButtonCadastro(html, action, "Cadastro", htmlAttribute);
        }


        public static MvcHtmlString ButtonCadastro(this HtmlHelper html, string action)
        {
            return ButtonCadastro(html, action, "Cadastro", null);
        }

        public static MvcHtmlString ButtonCadastro(this HtmlHelper html, string action, string descricao)
        {
            return ButtonCadastro(html, action, descricao, null);
        }

        public static MvcHtmlString ButtonEditar(this HtmlHelper html, string action)
        {
            return ButtonEditar(html, action, "Editar");
        }

        public static MvcHtmlString ButtonEditar(this HtmlHelper html, string action, string descricao)
        {
            var btn = new TagBuilder("a");
            var icon = new TagBuilder("i");
            var desc = new TagBuilder("i");

            icon.AddCssClass("glyphicon glyphicon-pencil");
            desc.AddCssClass("desc-btn");
            desc.InnerHtml += descricao;

            btn.InnerHtml += icon.ToString();
            btn.InnerHtml += desc.ToString();

            btn.AddCssClass("btn btn-primary btn-xs");
            btn.Attributes.Add("href", action);
            return MvcHtmlString.Create(btn.ToString());
        }

        public static MvcHtmlString ButtonVisualizacao(this HtmlHelper html, string action)
        {
            return ButtonVisualizacao(html, action, "Visualisar");
        }

        public static MvcHtmlString ButtonVisualizacao(this HtmlHelper html, string action, string descricao)
        {
            var btn = new TagBuilder("a");
            var icon = new TagBuilder("i");
            var desc = new TagBuilder("i"); 

            icon.AddCssClass("glyphicon glyphicon-eye-open");
            desc.AddCssClass("desc-btn");
            desc.InnerHtml += descricao;

            btn.InnerHtml += icon.ToString();
            btn.InnerHtml += desc.ToString();

            btn.AddCssClass("btn btn-primary btn-xs");
            btn.Attributes.Add("href", action);
            return MvcHtmlString.Create(btn.ToString());
        }


        public static MvcHtmlString ButtonSalvar(this HtmlHelper html)
        {
            var btn = new TagBuilder("button");
            var icon = new TagBuilder("i");
            var desc = new TagBuilder("i");

            icon.AddCssClass("glyphicon glyphicon-ok");
            desc.AddCssClass("desc-btn");
            desc.InnerHtml += "Salvar";

            btn.InnerHtml += icon.ToString();
            btn.InnerHtml += desc.ToString();

            btn.AddCssClass("btn btn-success  btn-xs");
            btn.Attributes.Add("type", "submit");
            return MvcHtmlString.Create(btn.ToString());
        }

        public static MvcHtmlString ButtonCancelar(this HtmlHelper html, string action)
        {
            var btn = new TagBuilder("a");
            var icon = new TagBuilder("i");
            var desc = new TagBuilder("i");

            icon.AddCssClass("glyphicon glyphicon-remove");
            desc.AddCssClass("desc-btn");
            desc.InnerHtml += "Cancelar";

            btn.InnerHtml += icon.ToString();
            btn.InnerHtml += desc.ToString();
             
            btn.AddCssClass("btn btn-danger  btn-xs");
            btn.Attributes.Add("href", action);
            return MvcHtmlString.Create(btn.ToString());
        }




        public static MvcHtmlString ButtonSearch(this HtmlHelper html, string descricao = "")
        {
            var btn = new TagBuilder("button");
            var icon = new TagBuilder("i");


            icon.AddCssClass("glyphicon glyphicon-search");
            btn.InnerHtml += icon.ToString();

            if (!string.IsNullOrEmpty(descricao))
            {
                var desc = new TagBuilder("i");
                desc.InnerHtml += descricao;
                desc.AddCssClass("desc-btn");
                btn.InnerHtml += desc.ToString();
            }


            btn.AddCssClass("btn btn-primary btn-xs");
            btn.Attributes.Add("type", "submit");
            return MvcHtmlString.Create(btn.ToString());
        }


        public static MvcHtmlString ButtonReset(this HtmlHelper html)
        {
            var btn = new TagBuilder("button");
            var icon = new TagBuilder("i");
            var desc = new TagBuilder("i");

            icon.AddCssClass("glyphicon glyphicon-remove");
            desc.AddCssClass("desc-btn");
            desc.InnerHtml += " Cancelar";

            btn.InnerHtml += icon.ToString();
            btn.InnerHtml += desc.ToString();

            btn.AddCssClass("btn btn-danger  btn-xs");
            btn.Attributes.Add("type", "reset");
            return MvcHtmlString.Create(btn.ToString());
        }


    }
}
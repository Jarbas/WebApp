using System.Web.Mvc;
using System.Linq;
using Rafitec.Cloud.Portal.Dominio.Entidades;
using Rafitec.Cloud.Portal.Dominio.Repositorio;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Rafitec.Cloud.Utils.ClassExtensions;

namespace Rafitec.Cloud.Portal.Web.HtmlHelpers
{
    public static class DropDownListHelpers
    {

        public static MvcHtmlString BoolDropDownList(this HtmlHelper html, bool? ValueAtual, string ColumName, IDictionary<string, string> htmlAtributo)
        {
            var select = new TagBuilder("select");
            select.MergeAttribute("name", ColumName);
            string valueKey;
            if (htmlAtributo.ContainsKey("class"))
            {
                htmlAtributo.TryGetValue("class", out valueKey);
                select.AddCssClass(valueKey);
            }

            if (htmlAtributo.ContainsKey("id"))
            {
                htmlAtributo.TryGetValue("id", out valueKey);
                select.MergeAttribute("id", valueKey);
            }

            var optionSim = new TagBuilder("option");
            optionSim.InnerHtml = "Sim";
            optionSim.MergeAttribute("value", "true");

            var optionNao = new TagBuilder("option");
            optionNao.InnerHtml = "Não";
            optionNao.MergeAttribute("value", "false");

            if (ValueAtual != null)
            {
                if (ValueAtual == true)
                    optionSim.MergeAttribute("selected", "selected");
                else if (ValueAtual == false)
                    optionNao.MergeAttribute("selected", "selected");
            }

            select.InnerHtml = select.InnerHtml + optionSim.ToString();
            select.InnerHtml = select.InnerHtml + optionNao.ToString();

            return MvcHtmlString.Create(select.ToString());



        }

        public static MvcHtmlString EntidadeDropDownList<T>(this HtmlHelper html, string ColumValue, string ColumDesc, string ColumName, Expression<Func<T, bool>> condicao,
                                                object htmlAttibuttes) where T : BaseEntidade
        {
            return EntidadeDropDownList<T>(html, null, ColumValue, ColumDesc, ColumName, condicao, htmlAttibuttes);

        }


        public static MvcHtmlString EntidadeDropDownList<T>(this HtmlHelper html, object ValueAtual, string ColumValue, string ColumDesc, string ColumName, Expression<Func<T, bool>> condicao,
                                                                object htmlAttibuttes) where T : BaseEntidade
        {            
            var select = new TagBuilder("select");            
            var htmlAtributo = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttibuttes);

            select.MergeAttribute("name", ColumName);

            foreach (var atributo in htmlAtributo)
                select.MergeAttribute(atributo.Key, atributo.Value.ToString());
            

            select.InnerHtml = "<option></option>";
            var _repositorio = new Repositorio<T>();

            foreach (var prop in _repositorio.GetMetodo(condicao))
            {
                var value = prop.GetType().GetProperty(ColumValue).GetValue(prop).ToString();

                var option = new TagBuilder("option");
                option.MergeAttribute("value", value);
                option.InnerHtml = prop.GetType().GetProperty(ColumDesc).GetValue(prop).ToString();
                if (ValueAtual != null)
                    if (value.Equals(ValueAtual.ToString()))
                        option.MergeAttribute("selected", "selected");
                select.InnerHtml = select.InnerHtml + option.ToString();
            }
            return MvcHtmlString.Create(select.ToString());
        }

        public static MvcHtmlString EntidadeDropDownList<T>(this HtmlHelper html, string ColumValue, string ColumDesc, string ColumName, object htmlAttibuttes) where T : BaseEntidade
        {
            return EntidadeDropDownList<T>(html, null, ColumValue, ColumDesc, ColumName, htmlAttibuttes);
           
        }

        public static MvcHtmlString EntidadeDropDownList<T>(this HtmlHelper html, object ValueAtual, string ColumValue, string ColumDesc, string ColumName, object htmlAttibuttes) where T : BaseEntidade
        {
            var select = new TagBuilder("select");
            var htmlAtributo = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttibuttes);
            select.MergeAttribute("name", ColumName);

            foreach (var atributo in htmlAtributo)
                select.MergeAttribute(atributo.Key, atributo.Value.ToString());


            select.InnerHtml = "<option></option>";
            var _repositorio = new Repositorio<T>();
            foreach (var prop in _repositorio.Get)
            {
                var value = prop.GetType().GetProperty(ColumValue).GetValue(prop).ToString();

                var option = new TagBuilder("option");
                option.MergeAttribute("value", value);
                option.InnerHtml = prop.GetType().GetProperty(ColumDesc).GetValue(prop).ToString();

                if (ValueAtual != null)
                    if (value.Equals(ValueAtual.ToString()))
                        option.MergeAttribute("selected", "selected");

                select.InnerHtml = select.InnerHtml + option.ToString();
            }
            return MvcHtmlString.Create(select.ToString());

        }
        
        public static MvcHtmlString EnumDropDownList<T>(this HtmlHelper html, Enum e, string fieldKey, object htmlAttibuttes) where T : struct, IConvertible
        {
            return EnumDropDownList<T>(html, e, fieldKey, null, htmlAttibuttes);
        }

        public static MvcHtmlString EnumDropDownList<T>(this HtmlHelper html, Enum e, string fieldKey, Enum Selected, object htmlAttibuttes) where T : struct, IConvertible
        {

            var select = new TagBuilder("select");
            var htmlAtributo = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttibuttes);

            foreach (var atributo in htmlAtributo)
                select.MergeAttribute(atributo.Key, atributo.Value.ToString());

            select.MergeAttribute("name", fieldKey);
            foreach (var t in Enum.GetValues(typeof(T)))
            {
                if (t.Equals("value__")) // varios ponteiros com esse valor pula o loop (é uma viage)
                    continue;
                var option = new TagBuilder("option");
                option.MergeAttribute("value", t.ToString());
                option.InnerHtml = EnumDescricao.Get((System.Enum)t);
                if (t.Equals(Selected))
                    option.MergeAttribute("selected", "selected");
                select.InnerHtml += option.ToString();
            }

            return MvcHtmlString.Create(select.ToString());
        }





    }
}
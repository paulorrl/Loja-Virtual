using PauloRodrigues.LojaVirtual.Web.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace PauloRodrigues.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelpersExtensions
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= paginacao.TotalPaginas; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                tag.MergeAttribute("href", paginaUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                result.Append(tag);
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}
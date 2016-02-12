using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PauloRodrigues.LojaVirtual.Web.Models;
using System.Web.Mvc;
using PauloRodrigues.LojaVirtual.Web.HtmlHelpers;

namespace PauloRodrigues.LojaVirtual.UnitTest
{
    [TestClass]
    public class TestePaginacao
    {
        // Test AAA (Arrange, Act, Assert)
        [TestMethod]
        public void TestarGeracaoDePaginacao()
        {
            // Arrange
            HtmlHelper helper = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            // Act
            MvcHtmlString result = helper.PageLinks(paginacao, paginaUrl);

            // Assert
            Assert.AreEqual
            (
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>",
                result.ToString()
            );
        }
    }
}
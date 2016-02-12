using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using PauloRodrigues.LojaVirtual.Web.Controllers;
using PauloRodrigues.LojaVirtual.Web.Models.ViewModel;

namespace PauloRodrigues.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoController
    {
        // Test AAA (Arrange, Act, Assert)
        [TestMethod]
        public void AdicionarItem()
        {
            // Arrange
            Produto produto1 = new Produto()
            {
                ProdutoID = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoID = 2,
                Nome = "Teste2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 3);
            carrinho.AdicionarItem(produto2, 4);

            CarrinhoController controller = new CarrinhoController();

            // Act
            controller.Adicionar(carrinho, 2, 1, ""); // 2 = ID do Produto que NÃO há no BD

            // Assert
            Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 2); // PASSED
            // Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 1); // FAIL
            Assert.AreEqual(carrinho.ItensCarrinhos.ToArray()[0].Produto.ProdutoID, 1);
        }
        
        [TestMethod]
        public void AdicionarProduto_VoltarParaCategoria()
        {
            #region Comentário
            // Ao adicionar um produto, o usuário é direcionado para o carrinho
            // ... ao clicar em "Continuar comprando", o mesmo deve ser redirecionado para sua página de origem inicial
            // Exemplo: URL = http://localhost:4393/Futebol <- Voltar para categoria FUTEBOL
            #endregion

            // Arrange
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();

            // Act
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, 1, "minhaUrl");

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");
        }

        [TestMethod]
        public void ConteudoCarrinho()
        {
            // Arrange
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();

            // Act
            CarrinhoViewModel resultado = (CarrinhoViewModel) controller.Index(carrinho, "minhaUrl").ViewData.Model;

            // Assert
            Assert.AreSame(resultado.Carrinho, carrinho);
            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");
        }
    }
}
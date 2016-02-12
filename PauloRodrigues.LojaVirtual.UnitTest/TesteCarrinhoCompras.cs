using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;

namespace PauloRodrigues.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        // Test AAA (Arrange, Act, Assert)

        [TestMethod]
        public void TestarAdicionarItem()
        {
            // Arrange
            Produto produto1 = new Produto()
            {
                ProdutoID = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoID = 2,
                Nome = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinhos.ToArray();

            // Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);

        }

        [TestMethod]
        public void TestarAdicionarItemExistente()
        {
            // Arrange
            Produto produto1 = new Produto()
            {
                ProdutoID = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoID = 2,
                Nome = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 4);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinhos.OrderBy(i => i.Produto.ProdutoID).ToArray();

            // Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Quantidade, 5);
        }

        [TestMethod]
        public void TestarRemoverItem()
        {
            // Arrange
            Produto produto1 = new Produto()
            {
                ProdutoID = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto()
            {
                ProdutoID = 2,
                Nome = "Teste 2"
            };

            Produto produto3 = new Produto()
            {
                ProdutoID = 3,
                Nome = "Teste 3"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            // Act
            carrinho.RemoverItem(produto2);

            // Assert
            Assert.AreEqual(carrinho.ItensCarrinhos.Where(p => p.Produto == produto2).Count(), 0); // PASS
            // Assert.AreEqual(carrinho.ItensCarrinhos.Where(p => p.Produto == produto2).Count(), 1); // FAIL
            Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 2);
        }

        [TestMethod]
        public void TestarObterValorTotal()
        {
            // Arrange
            Produto produto1 = new Produto()
            {
                ProdutoID = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto()
            {
                ProdutoID = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 1);

            // Act
            decimal valorTotal = carrinho.ObterValorTotal();

            // Assert
            Assert.AreEqual(valorTotal, 250M); // PASS
            // Assert.AreEqual(valorTotal, 300M); // FAIL
        }

        [TestMethod]
        public void TestarLimparCarrinho()
        {
            // Arrange
            Produto produto1 = new Produto()
            {
                ProdutoID = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto()
            {
                ProdutoID = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);

            // Act
            carrinho.LimparCarrinho();

            // Assert
            Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 0); // PASS
            // Assert.AreEqual(carrinho.ItensCarrinhos.Count(), 1); // FAIL
        }
    }
}
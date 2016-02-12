using System.Collections.Generic;
using System.Linq;

namespace PauloRodrigues.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itensCarrinho = new List<ItemCarrinho>(); 

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoID == produto.ProdutoID);

            if (item == null)
            {
                _itensCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade = quantidade;
            }
        }

        public void RemoverItem(Produto produto)
        {
            _itensCarrinho.RemoveAll(p => p.Produto.ProdutoID == produto.ProdutoID);
        }

        public decimal ObterValorTotal()
        {
            return _itensCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }

        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }

        public IEnumerable<ItemCarrinho> ItensCarrinhos
        {
            get{ return _itensCarrinho; }
        }
    }
}
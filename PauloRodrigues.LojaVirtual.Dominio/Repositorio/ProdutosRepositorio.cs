using System;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace PauloRodrigues.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EntityFrameDbContext _context = new EntityFrameDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        public Boolean Salvar(Produto produto)
        {
            Boolean salvar;

            if (produto.ProdutoID == 0)
            {
                // Novo registro
                _context.Produtos.Add(produto);
                salvar = true;
            }
            else
            {
                // Atualização de registro
                Produto prod = _context.Produtos.Find(produto.ProdutoID);
                salvar = false;

                if (prod != null)
                {
                    prod.Nome           = produto.Nome;
                    prod.Descricao      = produto.Descricao;
                    prod.Preco          = produto.Preco;
                    prod.Categoria      = produto.Categoria;
                    prod.Imagem         = produto.Imagem;
                    prod.ContentType    = produto.ContentType;
                }
            }

            _context.SaveChangesAsync();
            return salvar;
        }

        public Produto Remover(int produtoID)
        {
            Produto produto = _context.Produtos.Find(produtoID);

            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }

            return produto;
        }

        public Int32 GetTopID()
        {
            return _context.Produtos.Max(p => p.ProdutoID) + 1;

        }
    }
}
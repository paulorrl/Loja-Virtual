using System;
using System.Collections.Generic;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;

namespace PauloRodrigues.LojaVirtual.Web.Models.ViewModel
{
    public class ProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        // public Paginacao Paginacao { get; set; }

        public String CategoriaAtual { get; set; }
    }
}
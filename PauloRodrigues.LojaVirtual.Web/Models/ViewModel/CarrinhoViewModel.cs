using System;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;

namespace PauloRodrigues.LojaVirtual.Web.Models.ViewModel
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public String ReturnUrl { get; set; }
    }
}
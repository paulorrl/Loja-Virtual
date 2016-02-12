using System;

namespace PauloRodrigues.LojaVirtual.Dominio.Entidades
{
    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public Int32 Quantidade { get; set; }
    }
}
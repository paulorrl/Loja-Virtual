using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PauloRodrigues.LojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public Int32 ProdutoID { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite a descrição")]
        [DataType(DataType.MultilineText)]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Digite o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria")]
        public String Categoria { get; set; }

        public String Imagem { get; set; }

        public String ContentType { get; set; }
    }
}
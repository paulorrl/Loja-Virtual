using System;
using System.ComponentModel.DataAnnotations;

namespace PauloRodrigues.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        [Display(Name = "Nome do cliente:")]
        [Required(ErrorMessage = "Informe seu nome")]
        public String NomeCliente { get; set; }

        [Display(Name = "Cep:")]
        [Required(ErrorMessage = "Informe seu Cep")]
        public String Cep { get; set; }

        [Display(Name = "Logradouro:")]
        [Required(ErrorMessage = "Informe seu logradouro")]
        public String Logradouro { get; set; }

        [Display(Name = "Número:")]
        [Required(ErrorMessage = "Informe o número da residência")]
        public String Numero { get; set; }

        [Display(Name = "Complemento:")]
        public String Complemento { get; set; }

        [Display(Name = "Cidade:")]
        [Required(ErrorMessage = "Informe sua cidade")]
        public String Cidade { get; set; }

        [Display(Name = "Bairro:")]
        [Required(ErrorMessage = "Informe seu bairro")]
        public String Bairro { get; set; }

        [Display(Name = "Estado:")]
        [Required(ErrorMessage = "Informe seu estado")]
        public String Estado { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Informe seu email")]
        [EmailAddress(ErrorMessage = "Email incorreto")]
        public String Email { get; set; }

        [Display(Name = "Deseja embrulhar para presente?")]
        public Boolean EmbrulharPresente { get; set; }
    }
}
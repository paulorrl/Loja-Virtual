using System;
using System.ComponentModel.DataAnnotations;

namespace PauloRodrigues.LojaVirtual.Dominio.Entidades
{
    public class Administrador
    {
        // Annotayion Key, obrigaório para quando o nome do atributo representante da chave primária...
        // ... quando não estiver como "Id",
        // ... quando estiver como "Id" o Entity já entende que representa a PK
        [Key] 
        public Int32 Id { get; set; }

        [Display(Name = "Login:")]
        [Required(ErrorMessage = "Digite o login")]
        public String Login { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Digite a senha")]
        [DataType(DataType.Password)]
        public String Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}
using System;

namespace PauloRodrigues.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguration
    {
        public String Email { get; set; }

        public String Senha { get; set; }

        public String Host { get; set; }

        public Int32 Porta { get; set; }

        public String Assunto { get; set; }

        public String TelefoneSAC { get; set; }

        public String EmailSAC { get; set; }
    }
}
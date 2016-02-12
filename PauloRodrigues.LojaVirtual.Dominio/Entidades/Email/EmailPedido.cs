using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace PauloRodrigues.LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly  EmailConfiguration _emailConfig;

        public EmailPedido(EmailConfiguration emailConfiguration)
        {
            _emailConfig = emailConfiguration;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            // Realizar pagamento (Integração com algum meio de pagamento)

            String body = ProcessarCorpoEmail(carrinho, pedido);
            new Thread( () => EnviarEmail(pedido.Email, body) ).Start();
        }

        private void EnviarEmail(String destinario, String body)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Credentials = new NetworkCredential(_emailConfig.Email, _emailConfig.Senha);
                smtp.Host = _emailConfig.Host;
                smtp.Port = _emailConfig.Porta;
                smtp.EnableSsl = true;
                smtp.Send(_emailConfig.Email, destinario, _emailConfig.Assunto, body);
            }
        }

        private String ProcessarCorpoEmail(Carrinho carrinho, Pedido pedido)
        {
            StringBuilder body = new StringBuilder()
                .AppendLine("Novo Pedido")
                .Append(Environment.NewLine)

                .AppendLine("Informações do destinatário")

                .AppendFormat("Cliente: {0}", pedido.NomeCliente)
                .AppendLine(String.Empty)
                .AppendFormat("Email: {0}", pedido.Email)
                .AppendLine(String.Empty)
                .AppendFormat("Logradouro: {0}, {1}", pedido.Logradouro, pedido.Numero)
                .AppendLine(String.Empty)
                .AppendFormat("Complemento: {0}", pedido.Complemento ?? "Não informado")
                .AppendLine(String.Empty)
                .AppendFormat("Bairro: {0}", pedido.Bairro)
                .AppendLine(String.Empty)
                .AppendFormat("Cidade: {0}", pedido.Cidade)
                .AppendLine(String.Empty)
                .AppendFormat("Estado: {0}", pedido.Estado)
                .AppendLine(Environment.NewLine)

                .AppendLine("Itens:");

            foreach (var item in carrinho.ItensCarrinhos)
            {
                var subTotal = item.Produto.Preco * item.Quantidade;
                body.AppendFormat("{0} - {1} x {2:c}, subtotal: {3:c}" + Environment.NewLine,
                    item.Produto.Nome, item.Quantidade, item.Produto.Preco, subTotal);
            }

            body.Append(Environment.NewLine)
                .AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                .Append(Environment.NewLine)
                .AppendFormat("Embulhar para presente: {0}", pedido.EmbrulharPresente ? "Sim" : "Não")
                .AppendLine(Environment.NewLine)
                .AppendLine("Obrigado por escolher a Loja Virtual Benz!")
                .AppendLine("Caso precise nos contactar, abaixo os nossos contatos")
                .AppendFormat("SAC: {0} - {1}", _emailConfig.TelefoneSAC, _emailConfig.EmailSAC);

            return body.ToString();
        }
    }
}
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using PauloRodrigues.LojaVirtual.Dominio.Repositorio;
using PauloRodrigues.LojaVirtual.Web.Models.ViewModel;

namespace PauloRodrigues.LojaVirtual.Web.Controllers
{
    /*
       ATENÇÃO: Esta controller trabalha com Custom Binder
       Local:   Projeto WEB >> Infraestrutura >> CarrinhoModelBinder
       Obs:     Os Action's recebe o carrinho da Session via parâmetro
     */

    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ViewResult Index(Carrinho carrinho, string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            return PartialView(carrinho);
        }

        public RedirectToRouteResult Adicionar(Carrinho carrinho, int produtoId, int quantidade, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == produtoId);

            if (produto != null)
            {
                carrinho.AdicionarItem(produto, quantidade);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == produtoId);

            if (produto != null)
            {
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new {returnUrl});
        }
        
        public ActionResult FecharPedido(Carrinho carrinho)
        {
            if (!carrinho.ItensCarrinhos.Any())
            {
                return Redirect("~/Vitrine/ListarProdutos");
            }

            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            EmailPedido emailPedido = new EmailPedido(GetEmailConfiguration());

            if (!carrinho.ItensCarrinhos.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio!");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }

            return View(pedido);
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }

        private EmailConfiguration GetEmailConfiguration()
        {
            return new EmailConfiguration()
            {
                Email       = ConfigurationManager.AppSettings["Email"],
                Senha       = ConfigurationManager.AppSettings["Password"],
                Host        = ConfigurationManager.AppSettings["Host"],
                Porta       = Int32.Parse(ConfigurationManager.AppSettings["Port"]),
                Assunto     = ConfigurationManager.AppSettings["Subject"],
                TelefoneSAC = ConfigurationManager.AppSettings["TelephoneSAC"],
                EmailSAC    = ConfigurationManager.AppSettings["EmailSAC"],
            };
        }
    }
}
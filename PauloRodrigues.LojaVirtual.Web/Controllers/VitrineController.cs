using PauloRodrigues.LojaVirtual.Dominio.Repositorio;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using PauloRodrigues.LojaVirtual.Web.Models;
using PauloRodrigues.LojaVirtual.Web.Models.ViewModel;

namespace PauloRodrigues.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 12;

        // GET: Vitrine
        //public ViewResult ListarProdutos(String categoria, int pagina = 1)
        //{
        //    _repositorio = new ProdutosRepositorio();

        //    ProdutoViewModel model = new ProdutoViewModel
        //    {
        //        Produtos = _repositorio.Produtos
        //                                .Where(p => categoria == null || p.Categoria == categoria)
        //                                .OrderBy(p => p.Nome)
        //                                .Skip((pagina - 1) * ProdutosPorPagina)
        //                                .Take(ProdutosPorPagina)
        //        ,
        //        Paginacao = new Paginacao
        //        {
        //            PaginaAtual = pagina,
        //            ItensPorPagina = ProdutosPorPagina,
        //            ItensTotal = _repositorio.Produtos.Count()
        //        },
        //        CategoriaAtual = categoria
        //    };

        //    return View(model);
        //}

        public ViewResult ListarProdutos(String categoria)
        {
            _repositorio = new ProdutosRepositorio();

            var model = new ProdutoViewModel();
            var random = new Random();

            if (!String.IsNullOrEmpty(categoria))
            {
                model.Produtos = _repositorio.Produtos
                    .Where(x => x.Categoria == categoria)
                    .OrderBy(x => random.Next()).ToList();
            }
            else
            {
                model.Produtos = _repositorio.Produtos
                    .OrderBy(x => random.Next())
                    .Take(ProdutosPorPagina).ToList();
            }

            return View(model);
        }

        // RouteConfig.cs possuí esta rota comentada
        // (Exemplificando o uso do Attribute Routing)
        [Route("Vitrine/UrlPicture/{ProdutoID}")]
        public ActionResult UrlPicture(int ProdutoID)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == ProdutoID);

            if (produto != null)
            {
                String url = ConfigurationManager.AppSettings["Directory"] + produto.Imagem;
                return File(url, produto.ContentType);
            }

            return null;
        }
    }
}
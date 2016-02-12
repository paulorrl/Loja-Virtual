using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PauloRodrigues.LojaVirtual.Dominio.Repositorio;

namespace PauloRodrigues.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;

            _repositorio = new ProdutosRepositorio();

            IEnumerable<String> categorias = _repositorio.Produtos
                                                          .Select(c => c.Categoria)
                                                          .Distinct()
                                                          .OrderBy(c => c);

            return PartialView(categorias);
        }
    }
}
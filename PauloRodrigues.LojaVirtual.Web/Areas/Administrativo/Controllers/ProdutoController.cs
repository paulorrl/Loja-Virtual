using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using PauloRodrigues.LojaVirtual.Dominio.Repositorio;

namespace PauloRodrigues.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos;
            return View(produtos);
        }

        public ViewResult Novo()
        {
            return View("Alterar", new Produto());
        }

        public ViewResult Alterar(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoID == produtoId);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                _repositorio = new ProdutosRepositorio();

                if (image != null)
                {
                    SavePictureDirectory(produto, image);
                }
                
                Boolean save = _repositorio.Salvar(produto);

                if (save)
                {
                    TempData["mensagem"] = String.Format("{0} registrado com sucesso!", produto.Nome);
                }
                else
                {
                    TempData["mensagem"] = String.Format("{0} foi atualizado com sucesso!", produto.Nome);
                }

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        [HttpPost]
        public JsonResult Remover(int produtoId)
        {
            String mensagem = String.Empty;

            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Remover(produtoId);

            if (produto != null)
            {
                if (produto.Imagem != null)
                {
                    RemovePictureDirectory(produto);
                }

                mensagem = String.Format("{0} removido com sucesso!", produto.Nome);
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }

        private void SavePictureDirectory(Produto produto, HttpPostedFileBase image)
        {
            String directory    = CreateDirectory();
            String extension    = Path.GetExtension(image.FileName);
            String imageName    = String.Format("p_{0}{1}"
                                                    , produto.ProdutoID == 0 ? _repositorio.GetTopID() : produto.ProdutoID
                                                    , extension
                                                );

            produto.Imagem      = imageName;
            produto.ContentType = image.ContentType;

            image.SaveAs(directory + imageName);
        }

        private String CreateDirectory()
        {
            String directory = Server.MapPath(ConfigurationManager.AppSettings["Directory"]);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return directory;
        }

        private void RemovePictureDirectory(Produto produto)
        {
            String directory = CreateDirectory();
            System.IO.File.Delete(directory + produto.Imagem);
        }
    }
}
using System;
using System.Web.Mvc;
using System.Web.Security;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using PauloRodrigues.LojaVirtual.Dominio.Repositorio;

namespace PauloRodrigues.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio;

        public ActionResult Login(String returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, String returnUrl)
        {
            _repositorio = new AdministradoresRepositorio();

            if (ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdministrador(administrador);

                if (admin != null)
                {
                    if (!Equals(administrador.Senha, admin.Senha))
                    {
                        ModelState.AddModelError("", "Senha inválida");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login,  false);

                        if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }

                        return RedirectToAction("Index", "Produto", new { area = "Administrativo"});
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Administrador não localizado");
                }
            }

            return View(new Administrador());
        }
    }
}
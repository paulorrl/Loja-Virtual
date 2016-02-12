using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using PauloRodrigues.LojaVirtual.Web.App_Start;
using PauloRodrigues.LojaVirtual.Web.Infraestrutura;

namespace PauloRodrigues.LojaVirtual.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Registrando os bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Registrando o Custom Binder Carrinho
            ModelBinders.Binders.Add(typeof(Carrinho), new CarrinhoModelBinder());
        }
    }
}

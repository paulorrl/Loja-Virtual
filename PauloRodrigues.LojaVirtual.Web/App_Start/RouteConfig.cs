using System.Web.Mvc;
using System.Web.Routing;

namespace PauloRodrigues.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes(); // Iniciando rotas por atributo (Attribute Routing)

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Rotas para Produtos (Paginação e Categorias)
            // Produtos de todas as categorias
            routes.MapRoute(null, "",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos",
                    categoria = (string)null,
                    pagina = 1
                }
            );

            // Paginação de produtos de todas as categorias
            routes.MapRoute(null,
                "Page{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos",
                    categoria = (string)null
                },
                new { pagina = @"\d+" }
            );

            // Primeira página de qualquer categoria informada
            routes.MapRoute(null,
                "{categoria}",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos",
                    pagina = 1
                }
            );

            // Paginação de qualquer categoria informada
            routes.MapRoute(null,
                "{categoria}/Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListarProdutos"
                },
                new { pagina = @"\d+" }
            );
            #endregion

            //routes.MapRoute(
            //    "UrlPicture",
            //    "Vitrine/UrlPicture/{ProdutoID}",
            //    new { controller = "Vitrine", action = "UrlPicture", ProdutoID = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListarProdutos", id = UrlParameter.Optional }
            );

            

        }
    }
}
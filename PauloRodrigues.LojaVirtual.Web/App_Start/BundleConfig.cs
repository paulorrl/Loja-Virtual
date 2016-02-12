using System.Web.Optimization;

namespace PauloRodrigues.LojaVirtual.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region ScriptBundle
                bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"
                    ));

                bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"
                    ));
            #endregion

            #region StyleBundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/MyStyles/ErrorStyle.css",
                "~/Content/Site.css"));
            #endregion

            BundleTable.EnableOptimizations = true;
        }
    }
}
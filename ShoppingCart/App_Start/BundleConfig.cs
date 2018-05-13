using System.Web.Optimization;

namespace ShoppingCart {
    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/shoppingCart").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery.validate*",
                    "~/Scripts/jquery.us.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js",
                    "~/Scripts/knockut-{version}.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"
                ));
            bundles.Add(new ScriptBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"
                ));
            BundleTable.EnableOptimizations = true;

        }
    }
}

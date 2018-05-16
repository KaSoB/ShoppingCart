using System.Web.Optimization;

namespace ShoppingCart {
    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/shoppingCart").Include(
                     "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.custom.js",
                        "~/Scripts/ViewModels/CartSummaryViewModel.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"
                ));
            bundles.Add(new ScriptBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css"
                ));

        }
    }
}

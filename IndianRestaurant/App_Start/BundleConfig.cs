using System.Web;
using System.Web.Optimization;

namespace IndianRestaurant
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                       "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.nav.js",
                         "~/Scripts/jquery.mixitup.min.js",
                          "~/Scripts/jquery.fancybox.pack.js",
                           "~/Scripts/jquery.parallax-1.1.3.js",
                            "~/Scripts/jquery.appear.js",
                             "~/Scripts/jquery-countTo.js",
                            "~/Scripts/owl.carousel.min.js",
                            "~/Scripts/wow.min.js",
                          "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/animate.css",
                        "~/Content/jquery.fancybox.css",
                          "~/Content/main.css",
                            "~/Content/owl.carousel.css",
                              "~/Content/responsive.css",
                                "~/Content/bootstrap.min.css",
                                  "~/Content/font-awesome.min.css"));
        }
    }
}

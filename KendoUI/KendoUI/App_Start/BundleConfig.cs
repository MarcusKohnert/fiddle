using System.Web;
using System.Web.Optimization;

namespace KendoUI
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/kendo/css").Include(
                "~/Content/kendo/2015.1.429/kendo.common-bootstrap.min.css",
                "~/Content/kendo/2015.1.429/kendo.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
               "~/Scripts/kendo/2015.1.429/kendo.all.*",
               "~/Scripts/kendo/2015.1.429/kendo.aspnetmvc.*",
               "~/Scripts/kendo/2015.1.429/cultures/kendo.culture.de-AT.min.js",
               "~/Scripts/kendo/2015.1.429/cultures/kendo.culture.de-DE.min.js",
               "~/Scripts/kendo/2015.1.429/cultures/kendo.culture.pl-PL.min.js",
               "~/Scripts/kendo/2015.1.429/cultures/kendo.culture.en-US.min.js"));
        }
    }
}
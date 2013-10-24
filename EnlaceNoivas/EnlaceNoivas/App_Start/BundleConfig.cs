using System.Web;
using System.Web.Optimization;

namespace EnlaceNoivas
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            //Add bootstrap css and js #0ac0d5
            bundles.Add(new StyleBundle("~/bootstrap.css").Include(
                        "~/Content/bootstrap/bootstrap.css"));
            bundles.Add(new ScriptBundle("~/bootstrap.js").Include(
                        "~/Scripts/boorstrap/bootstrap.js"));
            //End boostrap

            bundles.Add(new StyleBundle("~/layout.css").Include(
                        "~/Content/Layout/layout.css"));
            bundles.Add(new ScriptBundle("~/layout.js").Include(
                        "~/Scripts/Layout/layout.js"));

            //actions css
            bundles.Add(new StyleBundle("~/Search/SearchProvider.css").Include(
                        "~/Content/Search/SearchProvider.css"));
            bundles.Add(new StyleBundle("~/Search/PageNotFold.css").Include(
                        "~/Content/Search/PageNotFold.css"));
            bundles.Add(new StyleBundle("~/User/Create.css").Include(
                        "~/Content/User/Create.css"));
            bundles.Add(new StyleBundle("~/Provider/Create.css").Include(
                        "~/Content/Provider/Create.css"));
            bundles.Add(new StyleBundle("~/Provider/Profile.css").Include(
                        "~/Content/Provider/Profile.css"));


            //end actions css
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/jqueryui.js").Include("~/Scripts/jquery-ui-1.8.20.js"));
            bundles.Add(new ScriptBundle("~/jqueryui-AC.css").Include("~/Content/themes/base/jquery.ui.autocomplete.css"));
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
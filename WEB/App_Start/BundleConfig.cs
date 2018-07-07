using System.Web;
using System.Web.Optimization;

namespace Inventario
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jscripts/sitio").Include(
                      "~/Content/scripts/jquery-3.0.0.js",
                      "~/Content/scripts/bootstrap.min.js",
                      "~/Content/scripts/jquery.metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts/jquery").Include(
                     "~/Content/scripts/jquery-3.0.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts/custom").Include(
                      "~/Content/scripts/custom-scripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts/home").Include(
                      "~/Content/scripts/home/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts/dataTables").Include(
                      "~/Content/scripts/dataTables/jquery.dataTables.min.js",
                      "~/Content/scripts/dataTables/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts/unobtrusive-ajax").Include(
                      "~/Content/scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts/morris").Include(
                     "~/Content/scripts/morris/morris.js",
                     "~/Content/scripts/morris/raphael-2.1.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscripts/plugin").Include(
                    "~/Content/scripts/plugin/bootstrap-datepicker.js",
                    "~/Content/scripts/plugin/bootstrap-timepicker.js",
                    "~/Content/scripts/plugin/jquery.inputmask.js",
                    "~/Content/scripts/plugin/jquery.inputmask.extensions.js",
                    "~/Content/scripts/plugin/daterangepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css/sitio").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/custom-styles.css"));

            bundles.Add(new StyleBundle("~/Content/css/datatbles").Include(
                      "~/Content/css/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css/morris").Include(
                      "~/Content/css/morris-0.4.3.min.css"));

            bundles.Add(new StyleBundle("~/Content/css/login").Include(
                     "~/Content/css/login.css"));


            bundles.Add(new StyleBundle("~/Content/css/plugin").Include(
                     "~/Content/css/plugin/datepicker3.css",
                     "~/Content/css/plugin/daterangepicker-bs3.css",
                     "~/Content/css/plugin/bootstrap-timepicker.min.css"));

            // toastr notification 
            bundles.Add(new ScriptBundle("~/plugins/toastr").Include(
                      "~/Content/Scripts/plugin/toastr/toastr.min.js"));

            // toastr notification styles
            bundles.Add(new StyleBundle("~/plugins/toastrStyles").Include(
                      "~/Content/css/plugin/toastr/toastr.min.css"));
        }
    }
}

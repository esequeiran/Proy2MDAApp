using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //-Scripts----------------------------------------------------------------------

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/Jquery/jquery-3.4.1.min.js",
                    "~/Scripts/Bootstrap/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/malihuScrollbar").Include(
                    "~/Scripts/MalihuScrollbar/jquery.mCustomScrollbar.concat.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                "~/Scripts/DataTables/jszip.min.js",
                "~/Scripts/DataTables/pdfmake.min.js",
                "~/Scripts/DataTables/vfs_fonts.js",
                "~/Scripts/DataTables/Buttons-1.6.1/dataTables.buttons.min.js",
                "~/Scripts/DataTables/Buttons-1.6.1/buttons.bootstrap4.min.js",
                "~/Scripts/DataTables/Buttons-1.6.1/buttons.html5.min.js",
                "~/Scripts/DataTables/Buttons-1.6.1/buttons.colVis.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                     "~/Scripts/Chartjs/Chart.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                     "~/Scripts/Base/base.js"));


            bundles.Add(new ScriptBundle("~/bundles/controlActions").Include(
                     "~/Scripts/Views/ControlActions.js"));
            

            //-Styles----------------------------------------------------------------------

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/Bootstrap/bootstrap.min.css",
                      "~/Content/FontAwesome/css/all.min.css"));

            bundles.Add(new StyleBundle("~/Content/dataTables").Include(
                      "~/Content/DataTables/dataTables.bootstrap4.min.css",
                      "~/Content/DataTables/buttons.dataTables.min.css",
                      "~/Content/DataTables/buttons.bootstrap4.min.css"));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
                      "~/Content/MalihuScrollbar/jquery.mCustomScrollbar.min.css",
                      "~/Content/Base/base.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                       "~/Content/site.css"));
        }
    }
}

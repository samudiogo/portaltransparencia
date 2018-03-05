using System.Web.Optimization;

namespace Transparencia.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/datatables/dataTables.min.js",
                "~/Scripts/datatables/swf/copy_csv_xls_pdf.swf",
                "~/Scripts/datatables/dataTables.bootstrap.js",
                "~/Scripts/datatables/dataTables.buttons.min.js",
                "~/Scripts/datatables/buttons.flash.min.js",
                "~/Scripts/datatables/buttons.html5.min.js",
                "~/Scripts/datatables/jszip.min.js",
                "~/Scripts/datatables/pdfmake.min.js",
                "~/Scripts/datatables/vfs_fonts.js"
                ));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Surrogacy
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Js").Include(
                      "~/Content/plugins/jQuery/jquery-2.2.3.min.js",
                      "~/Content/bootstrap/js/bootstrap.min.js",
                      "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                      "~/Content/plugins/fastclick/fastclick.js",
                      "~/Content/dist/js/app.min.js",
                      "~/Content/dist/js/demo.js",
                      "~/Content/plugins/iCheck/icheck.min.js",
                      "~/Content/plugins/select2/select2.full.min.js",
                      "~/Content/plugins/input-mask/jquery.inputmask.js",
                      "~/Content/plugins/input-mask/jquery.inputmask.date.extensions.js",
                      "~/Content/plugins/input-mask/jquery.inputmask.extensions.js",
                      "~/Content/plugins/daterangepicker/daterangepicker.js",
                      "~/Content/plugins/datepicker/bootstrap-datepicker.js",
                      "~/Content/plugins/colorpicker/bootstrap-colorpicker.min.js",
                      "~/Content/plugins/timepicker/bootstrap-timepicker.min.js"));

            bundles.Add(new StyleBundle("~/Css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css",
                      "~/Content/plugins/iCheck/square/blue.css",
                      "~/Content/dist/css/other/sliderMessage.css",
                      "~/Content/plugins/daterangepicker/daterangepicker.css",
                      "~/Content/plugins/datepicker/datepicker3.css",
                      "~/Content/plugins/iCheck/all.css",
                      "~/Content/plugins/colorpicker/bootstrap-colorpicker.min.css",
                      "~/Content/plugins/timepicker/bootstrap-timepicker.min.css",
                      "~/Content/plugins/select2/select2.min.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
using System.Web.Optimization;

namespace Safirex
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Scripts incluido pelo ronaldo faria
            bundles.Add(new ScriptBundle("~/Scripts/methods_pt.js"));
            bundles.Add(new ScriptBundle("~/bundles/mask").Include("~/Scripts/jquery.mask.js"));
            bundles.Add(new ScriptBundle("~/bundles/combobox").Include("~/Scripts/bootstrap-combobox.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerymin").Include("~/Scripts/jquery-ui-1.12.1.min.js"));

            // Scripts de uso padrao .NET
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js","~/Scripts/respond.js"));

            // Styles incluido pelo ronaldo faria
            bundles.Add(new StyleBundle("~/Content/cssx").Include("~/Content/bootstrap.min.css","~/Content/bootstrap-combobox.css","~/Content/autocomplete.css",
                                        "~/Content/jquery-ui.css"));

            // Styles de uso padrao .NET
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));

        }
    }
}

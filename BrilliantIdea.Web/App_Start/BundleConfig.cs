﻿using System.Web.Optimization;

namespace BrilliantIdea.Web.App_Start
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
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/wijmo/js").Include(
                "~/Scripts/jquery.wijmo-open.all.2.2.1.min.js",
                "~/Scripts/jquery.wijmo-complete.all.2.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout/js").Include("~/Scripts/knockout-2.1.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/Graph/js").Include(
                "~/Scripts/raphael-min.js",
                "~/Scripts/justgage.1.0.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/Content/js").Include(
                "~/Content/Scripts/Views/Shared/SysCor.util.js",
                "~/Content/Scripts/Views/Monitor/Monitor.js"
                ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css",
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/themes/rocket/jquery-wijmo.css"));

            bundles.Add(new StyleBundle("~/Content/dark").Include("~/Content/themes/Dark/DarkStyle.css"));

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
using System.Web;
using System.Web.Optimization;

namespace ZoipSwitch
{
    public class CssRewriteUrlTransformWrapper : IItemTransform
    {
        public string Process(string includedVirtualPath, string input)
        {
            return new CssRewriteUrlTransform().Process("~" + VirtualPathUtility.ToAbsolute(includedVirtualPath), input);
        }
    }
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // -------------  Styles ---------------------------
            bundles.Add(new StyleBundle("~/Content/helpers/helper").Include(
                      "~/Content/helpers/animate.css",
                      "~/Content/helpers/boilerplate.css",
                      "~/Content/helpers/border-radius.css",
                      "~/Content/helpers/grid.css",
                      "~/Content/helpers/page-transitions.css",
                      "~/Content/helpers/spacing.css",
                      "~/Content/helpers/typography.css",
                      "~/Content/helpers/utils.css",
                      "~/Content/helpers/colors.css"));

            bundles.Add(new StyleBundle("~/Content/material/material").Include(
                      "~/Content/material/ripple.css"));

            bundles.Add(new StyleBundle("~/Content/elements/element").Include(
                      "~/Content/elements/badges.css",
                      "~/Content/elements/buttons.css",
                      "~/Content/elements/content-box.css",
                      "~/Content/elements/dashboard-box.css",
                      "~/Content/elements/forms.css",
                      "~/Content/elements/images.css",
                      "~/Content/elements/info-box.css",
                      "~/Content/elements/invoice.css",
                      "~/Content/elements/loading-indicators.css",
                      "~/Content/elements/menus.css",
                      "~/Content/elements/panel-box.css",
                      "~/Content/elements/response-messages.css",
                      "~/Content/elements/responsive-tables.css",
                      "~/Content/elements/ribbon.css",
                      "~/Content/elements/social-box.css",
                      "~/Content/elements/tables.css",
                      "~/Content/elements/tile-box.css",
                      "~/Content/elements/timeline.css"));

            bundles.Add(new StyleBundle("~/Content/icons")
                .Include("~/Content/icons/fontawesome/fontawesome.css", new CssRewriteUrlTransform())
                .Include("~/Content/icons/linecons/linecons.css", new CssRewriteUrlTransform())
                .Include("~/Content/icons/spinnericon/spinnericon.css", new CssRewriteUrlTransform())
                .Include("~/Content/icons/elusive/elusive.css", new CssRewriteUrlTransform())
                .Include("~/Content/icons/iconic/iconic.css", new CssRewriteUrlTransform())
                .Include("~/Content/icons/meteocons/meteocons.css", new CssRewriteUrlTransform())
                .Include("~/Content/icons/typicons/typicons.css", new CssRewriteUrlTransform())
                );

            bundles.Add(new StyleBundle("~/Content/widgets")
                .Include("~/Content/widgets/accordion-ui/accordion.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/calendar/calendar.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/carousel/carousel.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/charts/justgage/justgage.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/charts/morris/morris.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/charts/piegage/piegage.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/charts/xcharts/xcharts.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/chosen/chosen.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/colorpicker/colorpicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/datatable/datatable.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/datepicker/datepicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/datepicker-ui/datepicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/daterangepicker/daterangepicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/dialog/dialog.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/dropdown/dropdown.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/dropzone/dropzone.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/file-input/fileinput.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/input-switch/inputswitch.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/input-switch/inputswitch-alt.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/ionrangeslider/ionrangeslider.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/jcrop/jcrop.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/jgrowl-notifications/jgrowl.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/loading-bar/loadingbar.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/maps/vector-maps/vectormaps.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/markdown/markdown.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/modal/modal.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/multi-select/multiselect.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/multi-upload/fileupload.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/nestable/nestable.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/noty-notifications/noty.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/popover/popover.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/pretty-photo/prettyphoto.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/progressbar/progressbar.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/range-slider/rangeslider.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/slidebars/slidebars.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/slider-ui/slider.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/summernote-wysiwyg/summernote-wysiwyg.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/tabs-ui/tabs.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/timepicker/timepicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/tocify/tocify.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/tooltip/tooltip.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/touchspin/touchspin.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/uniform/uniform.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/wizard/wizard.css", new CssRewriteUrlTransform())
                .Include("~/Content/widgets/xeditable/xeditable.css", new CssRewriteUrlTransform())
                );

            bundles.Add(new StyleBundle("~/Content/snippets/snippet").Include(
                      "~/Content/snippets/chat.css",
                      "~/Content/snippets/files-box.css",
                      "~/Content/snippets/login-box.css",
                      "~/Content/snippets/notification-box.css",
                      "~/Content/snippets/progress-box.css",
                      "~/Content/snippets/todo.css",
                      "~/Content/snippets/user-profile.css",
                      "~/Content/snippets/mobile-navigation.css"));

            bundles.Add(new StyleBundle("~/Content/applications/application").Include(
                        "~/Content/applications/mailbox.css"));

            bundles.Add(new StyleBundle("~/Content/themes")
                .Include("~/Content/themes/admin/layout.css", new CssRewriteUrlTransform())
                .Include("~/Content/themes/admin/color-schemes/default.css", new CssRewriteUrlTransform())
                );

            bundles.Add(new StyleBundle("~/Content/themes/components").Include(
                      "~/Content/themes/components/default.css",
                      "~/Content/themes/components/border-radius.css"));

            bundles.Add(new StyleBundle("~/Content/helpers/responsive").Include(
                      "~/Content/helpers/responsive-elements.css",
                      "~/Content/helpers/admin-responsive.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
            
            // Kendo - Styles 
            bundles.Add(new StyleBundle("~/Content/kendo/2017.1.118/kendo-scc").Include(
                      "~/Content/kendo/2017.1.118/kendo.common-material.min.css",
                      "~/Content/kendo/2017.1.118/kendo.mobile.all.min.css",
                      "~/Content/kendo/2017.1.118/kendo.dataviz.min.css",
                      "~/Content/kendo/2017.1.118/kendo.material.min.css",
                      "~/Content/kendo/2017.1.118/kendo.dataviz.material.min.css"
                      ));




            // ----------  Scripts  --------------------------------------

            bundles.Add(new ScriptBundle("~/bundles/js-core").Include(
                     "~/Scripts/js-core/jquery-core.js",
                     "~/Scripts/js-core/jquery-ui-core.js",
                     "~/Scripts/js-core/jquery-ui-widget.js",
                     "~/Scripts/js-core/jquery-ui-mouse.js",
                     "~/Scripts/js-core/jquery-ui-position.js",
                     "~/Scripts/js-core/transition.js",
                     "~/Scripts/js-core/modernizr.js",
                     "~/Scripts/js-core/jquery-cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/widgets-js").Include(
                     "~/Content/widgets/dropdown/dropdown.js",
                     "~/Content/widgets/tooltip/tooltip.js",
                     "~/Content/widgets/popover/popover.js",
                     "~/Content/widgets/progressbar/progressbar.js",
                     "~/Content/widgets/button/button.js",
                     "~/Content/widgets/collapse/collapse.js",
                     "~/Content/widgets/superclick/superclick.js",
                     "~/Content/widgets/input-switch/inputswitch-alt.js",
                     "~/Content/widgets/slimscroll/slimscroll.js",
                     "~/Content/widgets/slidebars/slidebars.js",
                     "~/Content/widgets/slidebars/slidebars-demo.js",
                     "~/Content/widgets/charts/piegage/piegage.js",
                     "~/Content/widgets/charts/piegage/piegage-demo.js",
                     "~/Content/widgets/screenfull/screenfull.js",
                     "~/Content/widgets/content-box/contentbox.js",
                     "~/Content/widgets/material/material.js",
                     "~/Content/widgets/material/ripples.js",
                     "~/Content/widgets/overlay/overlay.js"));

            bundles.Add(new ScriptBundle("~/bundles/js-init").Include(
                     "~/Scripts/js-init/widgets-init.js"));

            bundles.Add(new ScriptBundle("~/bundles/themes-js").Include(
                     "~/Content/themes/admin/layout.js"));

            bundles.Add(new ScriptBundle("~/bundles/skycons").Include(
                     "~/Content/widgets/skycons/skycons.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                        "~/Content/widgets/datatable/datatable.js",
                        "~/Content/widgets/datatable/datatable-bootstrap.js",
                        "~/Content/widgets/datatable/datatable-tabletools.js",
                        "~/Content/widgets/datatable/datatable-reorder.js"));

            bundles.Add(new ScriptBundle("~/bundles/charts/chart-js").Include(
                        "~/Content/widgets/charts/chart-js/chart-core.js",
                        "~/Content/widgets/charts/chart-js/chart-doughnut.js",
                        "~/Content/widgets/charts/chart-js/chart-demo-1.js"));

            bundles.Add(new ScriptBundle("~/bundles/charts/flot").Include(
                        "~/Content/widgets/charts/flot/flot.js",
                        "~/Content/widgets/charts/flot/flot-resize.js",
                        "~/Content/widgets/charts/flot/flot-stack.js",
                        "~/Content/widgets/charts/flot/flot-pie.js",
                        "~/Content/widgets/charts/flot/flot-tooltip.js",
                        "~/Content/widgets/charts/flot/flot-demo-1.js"));

            bundles.Add(new ScriptBundle("~/bundles/charts/sparklines").Include(
                        "~/Content/widgets/charts/sparklines/sparklines.js",
                        "~/Content/widgets/charts/sparklines/sparklines-demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlcarousel").Include(
                        "~/Content/widgets/owlcarousel/owlcarousel.js",
                        "~/Content/widgets/owlcarousel/owlcarousel-demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo-js").Include(
                        "~/Scripts/kendo/2017.1.118/jquery.min.js",
                        "~/Scripts/kendo/2017.1.118/jszip.min.js",
                        "~/Scripts/kendo/2017.1.118/kendo.all.min.js",
                        "~/Scripts/kendo/2017.1.118/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo.modernizr.custom.js"
                        ));





            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                      "~/Scripts/respond.js"));

        }
    }
}

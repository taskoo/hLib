using System.Web;
using System.Web.Optimization;

namespace hLib
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            /*------------------------------------------SCRIPTs------------------------------------------*/
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

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTablesBootstrap").Include(
                       "~/Scripts/DataTables/jquery.dataTables.min.js",
                       "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                       "~/Scripts/DataTables/dataTables.responsive.min.js",
                       "~/Scripts/DataTables/responsive.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/appScripts/site.js"));

            //BOOK PAGES--------------------------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/indexBookPage").Include(
                        "~/Scripts/appScripts/book/indexBookPage.js"));                      
           
            bundles.Add(new ScriptBundle("~/bundles/bookCreateAndEditPages").Include(
                       "~/Scripts/appScripts/book/bookCreateAndEditPages.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalBook").Include(
                       "~/Scripts/appScripts/book/modalBook.js"));
            //BOOK PAGES--------------------------------------------------------------------------------



            //AUTHOR PAGES------------------------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/indexAuthorPage").Include(
                       "~/Scripts/appScripts/author/indexAuthorPage.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalAuthor").Include(
                       "~/Scripts/appScripts/author/modalAuthor.js"));

            bundles.Add(new ScriptBundle("~/bundles/authorCreateAndEditPages").Include(
                      "~/Scripts/appScripts/author/authorCreateAndEditPages.js"));

            //AUTHOR PAGES------------------------------------------------------------------------------



            //NNATIONALITY PAGE-------------------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/indexNationalityPage").Include(
                      "~/Scripts/appScripts/nationality/indexNationalityPage.js"));
            //NNATIONALITY PAGE-------------------------------------------------------------------------



            //GENRE PAGE--------------------------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/indexGenrePage").Include(
                      "~/Scripts/appScripts/genre/indexGenrePage.js"));
            //GENRE PAGE--------------------------------------------------------------------------------



            //LANGUANGE PAGE----------------------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/bundles/indexLanguagePage").Include(
                      "~/Scripts/appScripts/language/indexLanguagePage.js"));
            //LANGUANGE PAGE----------------------------------------------------------------------------



            /*------------------------------------------STYLEs------------------------------------------*/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //sidebar css properties for index book and index author pages
            bundles.Add(new StyleBundle("~/Content/simple-sidebar").Include(
                      "~/Content/simple-sidebar.css"));


        }
    }
}

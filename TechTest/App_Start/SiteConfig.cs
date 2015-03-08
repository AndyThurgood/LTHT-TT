using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof(TechTest.App_Start.SiteConfig), "PreStart")]

namespace TechTest.App_Start
{
    public static class SiteConfig
    {
        public static void PreStart()
        {
            // Add your start logic here
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
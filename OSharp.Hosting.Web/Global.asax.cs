using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UIShell.iOpenWorks.Bootstrapper;
using UIShell.OSGi.MvcWebExtension;

namespace MvcWebFramework
{
    public class MvcApplication : BundleRuntimeMvcApplication
    {
        /// <summary>
        /// 是否启用自动更新。
        /// </summary>
        private static bool AutoUpdateCoreFiles
        {
            get
            {
                string autoUpdateCoreFiles = System.Web.Configuration.WebConfigurationManager.AppSettings["AutoUpdateCoreFiles"];
                if (!string.IsNullOrEmpty(autoUpdateCoreFiles))
                {
                    try
                    {
                        return bool.Parse(autoUpdateCoreFiles);
                    }
                    catch { }
                }

                return false;
            }
        }

        protected override void Application_Start(object sender, EventArgs e)
        {
            if (AutoUpdateCoreFiles)
            {
                new CoreFileUpdater().UpdateCoreFiles(CoreFileUpdateCheckType.Daily);
            }
            // Create a repository folder to store the downloaded plugins.
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repository");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            base.Application_Start(sender, e);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public override void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            
        }

        public override void RegisterRoutes(RouteCollection routes)
        {
            
        }
    }
}

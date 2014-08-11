using System;
using System.Collections.Generic;
using System.Linq;
using UIShell.OSGi;
using UIShell.PageFlowService;
using UIShell.PermissionService;

namespace ContactsPlugin
{
    public class BundleActivator : IBundleActivator
    {
        public static IBundle Bundle { get; private set; }
        public static ServiceTracker<IPageFlowService> PageFlowServiceTracker { get; private set; }
        public static ServiceTracker<IPermissionService> PermissionServiceTracker { get; private set; }
        public static PageNode LayoutPageNode
        {
            get
            {
                return PageFlowServiceTracker.DefaultOrFirstService.GetPageNode("LayoutPage");
            }
        }

        public void Start(IBundleContext context)
        {
            Bundle = context.Bundle;
            PermissionServiceTracker = new ServiceTracker<IPermissionService>(context);
            PageFlowServiceTracker = new ServiceTracker<IPageFlowService>(context);
        }

        public void Stop(IBundleContext context)
        {
            PermissionServiceTracker.Dispose();
            PageFlowServiceTracker.Dispose();
        }
    }
}
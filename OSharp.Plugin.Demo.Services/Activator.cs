using System;
using System.Collections.Generic;
using System.Text;
using UIShell.OSGi;

namespace OSharp.Plugin.Demo.Services
{
    public class Activator : IBundleActivator
    {
        public void Start(IBundleContext context)
        {
            //context.AddService<DemoService>(new CustomService());
        }

        public void Stop(IBundleContext context)
        {
            //todo:
        }
    }
}

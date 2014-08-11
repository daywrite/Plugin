using System;
using System.Collections.Generic;
using System.Text;

using OSharp.Core.Data.Entity;

using UIShell.OSGi;
using System.Reflection;

namespace OSharp.Plugin.Demo.Services
{
    public class Activator : IBundleActivator
    {
        public void Start(IBundleContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            DatabaseInitializer.AddMapperAssembly(assembly);
            //context.AddService<DemoService>(new CustomService());
        }

        public void Stop(IBundleContext context)
        {
            //todo:
        }
    }
}

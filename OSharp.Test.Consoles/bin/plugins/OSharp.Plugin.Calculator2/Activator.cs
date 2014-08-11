using OSharp.Plugin.Calculator;
using System;
using System.Collections.Generic;
using System.Text;
using UIShell.OSGi;

namespace OSharp.Plugin.Calculator2
{
    public class Activator : IBundleActivator
    {
        public void Start(IBundleContext context)
        {
            context.AddService<ICalculate>(new OSharp.Plugin.Calculator2.Impl.Calculator());
            //todo:
        }

        public void Stop(IBundleContext context)
        {
            //todo:
        }
    }
}

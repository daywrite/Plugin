using System;
using System.Collections.Generic;
using System.Text;
using UIShell.OSGi;

namespace OSharp.Test.AudioPlayerShell
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BundleRuntime bundleRuntime = new BundleRuntime())
            {
                bundleRuntime.Start();

                //TODO

                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
        }
    }
}

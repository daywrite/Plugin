using System;
using System.Collections.Generic;
using System.Text;
using UIShell.OSGi;
using CD=OSharp.Plugin.Calculator;
namespace OSharp.Test.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BundleRuntime bundleRuntime = new BundleRuntime())
            {
                bundleRuntime.Start();

                //TODO
                Console.WriteLine("Input the expression to be calculated:");
                string expression = Console.ReadLine();

                //CD.ICalculate calculator = new CD.Calculator();
                List<CD.ICalculate> list = bundleRuntime.GetService<CD.ICalculate>();
                foreach (CD.ICalculate calculator in list)
                {
                    Console.WriteLine(string.Format("Calling ICalculate instance named {0} .",
                        calculator.GetType().FullName));
                    Console.WriteLine(string.Format("Calculate result of {0} is {1}.",
                        expression,
                        calculator.Calculate(expression)));
                }
                //Console.WriteLine(string.Format("Calculate result of {0} is {1}.",
                //    expression,
                //    calculator.Calculate(expression)));

                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
        }
    }
}

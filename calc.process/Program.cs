using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace calc.process
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Try typing your favorite polynomial function (i.e. 3x^2+4x^3):");
            String s = Console.ReadLine();

            Console.WriteLine("\nWe will be integrating from 0 to x. Please choose a reasonable upper limit:");
            String x = Console.ReadLine();

            Console.WriteLine("\nPlease choose a dx. Recommended value is .00005, anything smaller than that will take more time to process:");
            String dx = Console.ReadLine();

            MathProcess math = new MathProcess(Double.Parse(dx));
            FunctionProcess function = new FunctionProcess();

            //Parse input, construct the polynomial, and save it in function
            InputParser input = new InputParser(s);
            input.getMonomialsFromQuery(function);

            //Get integral and print
            Stopwatch sW = new Stopwatch();
            sW.Start();

            double testTotal = math.getDefiniteIntegralThreaded(function, Double.Parse(x));
            double testDeriv = math.getDerivative(function, Double.Parse(x));

            sW.Stop();
            

            Console.WriteLine("\n\nDefinite integral from 0 to " + x + " is approx. equal to: " + Math.Round(testTotal, 5));
            Console.WriteLine("Derivative at " + x + " is approx. equal to: " + Math.Round(testDeriv, 5));
            Console.WriteLine("Time used for calculation: {0}ms, using {1} threads.", sW.ElapsedMilliseconds, math.numThreads);
             
            Console.ReadKey();
        }
    }


}

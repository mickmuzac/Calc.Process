using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            Console.WriteLine("\nPlease choose a dx. Recommended value is .00005, anything smaller than that will take a long time to process:");
            String dx = Console.ReadLine();

            MathProcess math = new MathProcess(Double.Parse(dx));
            FunctionProcess function = new FunctionProcess();
            List<MonomialProcess> test = new List<MonomialProcess>(5);

            //Parse input and construct the polynomial in the function
            InputParser input = new InputParser(s);
            input.getMonomialsFromQuery(function);


            //Get integral and print
            double testTotal = math.getDefiniteIntegral(function, Double.Parse(x));

            Console.WriteLine("\n" +Math.Round(testTotal, 2));
            Console.ReadKey();
        }
    }


}

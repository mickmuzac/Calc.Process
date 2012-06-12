using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace calc.process
{
    class MathProcess
    {
        public double dx;
        public double time = 0;

        public MathProcess(double dx)
        {
            this.dx = dx;
        }
         
        public double getDefiniteIntegral(FunctionProcess f, double end)
        {

            double total = 0;
            double x = 0;


            for (x = 0; x <= end; x += dx)
            {
                total += f.getValue(x) * dx;
            }

            return total;
        }

        public double getDerivative(FunctionProcess f, double x)
        {

            return (f.getValue(x + dx)-f.getValue(x)) / dx;
        }
    }
}

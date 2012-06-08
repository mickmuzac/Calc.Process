using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class MathProcess
    {
        public double dx;

        public MathProcess(double dx)
        {
            this.dx = dx;
        }

        public double getDefiniteIntegral(FunctionProcess f, double end)
        {

            double total = 0;

            double x = 0;

            for (x = 0; x < end; x += dx)
            {
                total += f.getValue(x) * dx;
            }

            return total;
        }

        public double getDerivative(double coeff, int exponent, double end)
        {

            double total = 0.0f;

            double x = 0;
            double tempX = 0;

            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class FunctionProcess
    {

        List<TermProcess> function;

        //This specifies which derivative level is wanted
        int setDerivative = 0;
        double dx = 0;

        public FunctionProcess()
        {
        }

        public void setDerivativeLevel(double dX, int deriv)
        {
            this.dx = dX;
            setDerivative = deriv;
        }

        //Created a Function using a list of correlating coefficients and exponents
        public void constructFunction(List<double> coeff, List<int> exponent)
        {

            function = new List<TermProcess>(10);
            int numTerms = coeff.Count;

            for (int i = 0; i < numTerms; i++)
            {
                function.Add(new TermProcess(coeff[i], exponent[i]));
                
                //Feature in progress
               // function[i].addGeneric(Math.Cos, 1);
                //function[i].addGeneric(Math.Sin, 1);
            }

            return;
        }

        //Construct a Function using a list of Terms
        public void constructFunction(List<TermProcess> m)
        {
            function = m;
        }

        public double getValue(double x, int deriv = -1)
        {
            double y = 0;
            double temp = 0;

            int length = function.Count;

            for (int i = 0; i < length; i++)
            {
                temp = x;

                if (function[i].exponent == 0)
                    temp = 1;

                //Using the power function is less efficient than the following for loop
                //temp = Math.Pow(x, polynomialTerms[i].exponent);
                for (int g = 1; g < function[i].exponent; g++)
                {

                        temp *= x;
                }

                y += temp * function[i].coeff * function[i].getGenericValue(x);
            }


           // if(deriv == -1) y = (getValue(x + dx, 1) - 2 * y + getValue(x - dx, 1)) / (dx);
            

            return y;
        }

    }
}

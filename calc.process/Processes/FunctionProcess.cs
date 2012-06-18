using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class FunctionProcess
    {

        List<TermProcess> function;

        public FunctionProcess()
        {
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
                function[i].addGeneric(Math.Sin, 1);
            }

            return;
        }

        //Construct a Function using a list of Terms
        public void constructFunction(List<TermProcess> m)
        {
            function = m;
        }

        //Get the value of this Function
        public double getValue(double x)
        {
            double y = 0;
            double temp = 0;

            int length = function.Count;
             
            int g = 1;
            int i = 0;


            for (i = 0; i < length; i++)
            {
                temp = x;

                if (function[i].exponent == 0)
                    temp = 1;

                //Using the power function is less efficient than the following for loop
                //temp = Math.Pow(x, polynomialTerms[i].exponent);
                for (g = 1; g < function[i].exponent; g++)
                {

                        temp *= x;
                }

                y += temp * function[i].coeff * function[i].getGenericValue(x);
            }

            return y;
        }
    }
}

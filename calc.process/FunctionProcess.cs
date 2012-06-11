using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class FunctionProcess
    {

        List<MonomialProcess> polynomialTerms;

        public FunctionProcess()
        {
        }

        public void constructPolynomial(List<double> coeff, List<int> exponent)
        {

            polynomialTerms = new List<MonomialProcess>(10);
            int numTerms = coeff.Count;

            for (int i = 0; i < numTerms; i++)
            {
                polynomialTerms.Add(new MonomialProcess(coeff[i], exponent[i]));
                
                //Feature in progress
                //polynomialTerms[i].setGeneric(Math.Sin, 2);
            }
        }

        public void constructPolynomial(List<MonomialProcess> m)
        {
            polynomialTerms = m;
        }

        public double getValue( double x )
        {

            return getValuePolynomial(x);
        }

        private double getValuePolynomial(double x)
        {
            double y1 = 0;

            double temp = 0;
            double temp2 = 0;
            double placeholder2 = 0;

            int length = polynomialTerms.Count;
            int greaterExponent = 0;
             
            int g = 1;
            int i = 0;

            for (i = 0; i < length; i++)
            {
                temp = x;
                temp2 = polynomialTerms[i].generic(x);
                placeholder2 = temp2;

                //We'll loop to the greater exponent..
                greaterExponent = Math.Max(polynomialTerms[i].exponent, polynomialTerms[i].genericExponent);

                for (g = 1; g < greaterExponent; g++)
                {

                    if (greaterExponent <= polynomialTerms[i].exponent)
                        temp *= x;

                    if (greaterExponent <= polynomialTerms[i].genericExponent)
                        temp2 *= placeholder2;
                }

                y1 = y1 + temp * polynomialTerms[i].coeff * temp2;
            }
            

            return y1;
        }
    }
}

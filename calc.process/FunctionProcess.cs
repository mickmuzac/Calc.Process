using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class FunctionProcess
    {

        List<MonomialProcess> polynomialTerms;
        Func<double, double> generic;

        bool usingPolynomial = false;
        bool usingGeneric = false;

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
            }
        }

        public void constructPolynomial(List<MonomialProcess> m)
        {
            polynomialTerms = m;
            usingPolynomial = true;
        }

        public void constructGeneric(Func<double, double> f)
        {

            generic = f;
            usingGeneric = true;
        }

        public double getValue( double x )
        {
            if (usingGeneric)
                return getValueGeneric(x);

            else if (usingPolynomial)
                return getValuePolynomial(x);

            return 0;
        }

        private double getValueGeneric(double x)
        {
            double i = generic(x);
            return i;
        }

        private double getValuePolynomial(  double x)
        {
            double y = 0;
            double temp = 0;
            int length = polynomialTerms.Count;

            int g = 1;
            int i = 0;

            for (i = 0; i < length; i++)
            {
                if (polynomialTerms[i].exponent == 0)
                    y += 1;

                else
                {
                    temp = x;

                    for (g = 1; g < polynomialTerms[i].exponent; g++)
                        temp *= x;

                    y += temp * polynomialTerms[i].coeff;

                }
            }

            return y;
        }
    }
}

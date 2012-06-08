using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class MonomialProcess
    {

        public double coeff = 0;
        public int exponent = 0;

        public MonomialProcess(double c, int e)
        {

            coeff = c;
            exponent = e;
        }

        public double getCoeff(double x)
        {
            return coeff;
        }
    }
}

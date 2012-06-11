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
        public int genericExponent = 1;
        public Func<double, double> generic;

        public MonomialProcess(double c, int e)
        {

            coeff = c;
            exponent = e;
            generic = initGeneric;
        }

        public void setGeneric(Func<double,double> f, int gExponent)
        {

            generic = f;
            genericExponent = gExponent;
        }

        //This function is used to initialize the default generic function and have it simply return 1.
        private double initGeneric(double x){

            return 1;
        }
    }
}

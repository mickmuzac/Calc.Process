using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class TermProcess
    {
         
        public double coeff = 0;

        public int exponent = 0;
        public List<int> genericExponent {get; private set;} 
        private List<Func<double, double>> generic;

        public TermProcess(double c, int e)
        {

            coeff = c;
            exponent = e;
            generic = new List<Func<double, double>>(5);
            genericExponent = new List<int>(5);
        }

        //Adds a generic function and exponent to their respective lists
        public void addGeneric(Func<double,double> f, int gExponent)
        {
            
            generic.Add(f);
            genericExponent.Add(gExponent);
        }

        /*This handles the case when there are no generic elements. 
         Returns a 1 instead of a 0 (since it needs to be multiplied)*/
        public double getGenericValue(double x)
        {

            if (generic.Count == 0)
                return 1;

            else return getTrueGenericValue(x);
        }

        //True generic value. Use when multiplication is not needed
        public double getTrueGenericValue(double x)
        {
            double y = 0;
            double temp = 1;
            double powerTemp = 1;

            for (int i = 0; i < generic.Count; i++)
            {

                if (genericExponent[i] == 0)
                    temp = 1;

                else
                {
                    powerTemp = generic[i](x);
                    temp = powerTemp;

                    for (int j = 1; j < genericExponent[i]; j++)
                        temp *= powerTemp;
                }


                if (i != 0)
                    y *= temp;
                else
                    y = temp;
            }

            return y;
        }
    }
}
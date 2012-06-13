using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class IntegrationThreadParameter
    {

        public FunctionProcess function;
        public double start;
        public double end;

        public IntegrationThreadParameter(FunctionProcess f, double x, double y)
        {
            start = x;
            end = y;
            function = f;
        }

    }
}

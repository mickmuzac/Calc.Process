using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace calc.process
{
    class MathProcess
    {
        public double dx;
        public double time = 0;

        List<IntegrationThreadParameter> integrationValues;
        List<Thread> threads;
        public int numThreads = 1;
        List<double> finalValues;

        private readonly object listLock = new object();

        public MathProcess(double dx)
        {
            this.dx = dx;

            //Snippet found to get the number of decimal places in dx
            String str = String.Format("{0:0.#######}",dx); 
            //End snippet

            numThreads = 2 * (str.Length - 2);
            integrationValues = new List<IntegrationThreadParameter>(numThreads);
            threads = new List<Thread>(numThreads);
            finalValues = new List<double>(numThreads); 
        }

        public MathProcess(double dx, int multithreadingLevel)
        {
            this.dx = dx;
            numThreads = multithreadingLevel;

            integrationValues = new List<IntegrationThreadParameter>(numThreads);
            threads = new List<Thread>(numThreads);
            finalValues = new List<double>(numThreads);
        }
        
        public double getDefiniteIntegralThreaded(FunctionProcess f, double end){

            double total = 0;
            double increment = end / numThreads;

            for (int i = 0; i < numThreads; i++)
            {
                integrationValues.Add(new IntegrationThreadParameter(f, i * increment, (i + 1) * increment));
                threads.Add(new Thread(new ParameterizedThreadStart(getDefiniteIntegral)));
                threads[i].Start(integrationValues[i]);
            }

            while (finalValues.Count < numThreads)
            {

                Thread.Yield();
            }

            for (int i = 0; i < finalValues.Count; i++)
            {

                total += finalValues[i];
            }

            return total;
        }

        public void getDefiniteIntegral(Object parameter)
        {

            double total = 0;
            double x = 0;
            IntegrationThreadParameter values = (IntegrationThreadParameter)parameter;

            for (x = values.start; x <= values.end; x += dx)
            {
                total += values.function.getValue(x) * dx;
            }

            lock (listLock)
            {

                finalValues.Add(total);
            }

        }

        public double getDerivative(FunctionProcess f, double x)
        {

            return (f.getValue(x + dx)-f.getValue(x)) / dx;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace calc.process
{
    class MathProcess
    {
        private double dx;
        public double deltaX 
        {
            get
            {
                return dx;
            }
            set 
            {
                dx = value; 

                //Snippet found to get the number of decimal places in dx
                String str = String.Format("{0:0.#######################}", dx);
                //End snippet

                numThreads = (int)(2.8 * (str.Length - 2));
                integrationValues = new List<IntegrationThreadParameter>(numThreads);
                threads = new List<Thread>(numThreads);
                finalValues = new List<double>(numThreads); 
            } 
        }

        public double time = 0;

        List<IntegrationThreadParameter> integrationValues;
        List<Thread> threads;

        public int numThreads = 1;
        List<double> finalValues;

        private readonly object listLock = new object();
        private readonly object imageLock = new object();

        public Bitmap visual;
        private double saveEnd = 0;

        double negDx;

        public MathProcess()
        {
            visual = new Bitmap(@"image.jpg");
        }

        public MathProcess(double dx)
        {

            deltaX = dx;
            visual = new Bitmap(@"image.jpg");
        }

        public MathProcess(double dx, int multithreadingLevel)
        {

            this.dx = dx;
            numThreads = multithreadingLevel;

            integrationValues = new List<IntegrationThreadParameter>(numThreads);
            threads = new List<Thread>(numThreads);
            finalValues = new List<double>(numThreads);
            visual = new Bitmap(@"image.jpg");
        }
        
        public double getDefiniteIntegralThreaded(FunctionProcess f, double end){

            double total = 0;
            double increment = end / numThreads;
            saveEnd = end;
            negDx = (end > 0) ? dx : -1 * dx;

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
            IntegrationThreadParameter values = (IntegrationThreadParameter)parameter;
            double total = 0;

            if(negDx > 0)
                for (double x = values.start; x <= values.end; x += negDx)   
                    total += values.function.getValue(x) * dx;

            else
                for (double x = values.start; x >= values.end; x += negDx)
                    total += values.function.getValue(x) * dx;

            lock (listLock)
                finalValues.Add(total);

        }

        public Bitmap getVisualization(FunctionProcess f, PictureBox p, double xScale, double yScale)
        {
            double temp = 0;

            Graphics g = Graphics.FromImage(visual);
            g.Clear(Color.White);

            int centerX = p.Width / 2;
            int centerY = p.Height / 2;
            
            /* TODO: Get visualiztion working correctly.. We'll see how this turns out.. */

            Pen pen = new Pen(Color.Red, 2);
            Pen axes = new Pen(Color.Black, 1);

            Pen solid = new Pen(Color.LightGray, 1);

            double scaleInv = xScale * .0005;

            List<PointF> points = new List<PointF>(200);

            for (double x = - 25; x < 25; x += scaleInv)
            {
                temp = f.getValue(x);
                temp = temp * (-yScale) + centerY;

                points.Add(new PointF((float)(x * xScale) + centerX, (float)temp));

                if ((x < saveEnd && x > 0) || (x > saveEnd && x < 0))
                    g.DrawLine(solid, (float)(x * xScale + centerX), (float)(temp), (float)(x * xScale + centerX), centerY);

            }

            g.DrawLine(axes, (float)(saveEnd * xScale + centerX), (float)(-f.getValue(saveEnd) * yScale + centerY), (float)(saveEnd * xScale + centerX), centerY);
            
            //This draw curve call is where the magic happens
            g.DrawCurve(pen, points.ToArray());

            g.DrawLine(axes, 0, centerY, p.Width, centerY);
            g.DrawLine(axes, centerX, 0, centerX, p.Height);

            return visual;
        }

        public double getSimpsonIntegral(FunctionProcess f, double end)
        {

            return end/6  * (f.getValue(0) + 4 * f.getValue(end/2) + f.getValue(end));
        }

        public double getDerivative(FunctionProcess f, double x)
        {

            return (f.getValue(x + dx)-f.getValue(x)) / dx;
        }
    }
}

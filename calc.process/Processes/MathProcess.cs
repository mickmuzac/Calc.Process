using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace calc.process
{
    class MathProcess
    {

        double negDx;
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

        List<IntegrationThreadParameter> integrationValues;
        List<Thread> threads;

        public int numThreads = 1;
        List<double> finalValues;

        private readonly object listLock = new object();

        private double saveEnd = 0;
        private double derivative = 0;

        public Bitmap visual;
        private int imageWidth = 815;
        private int imageHeight = 267;
        public bool transparent = false;

        public MathProcess()
        {
            visual = new Bitmap(imageWidth, imageHeight);
        }

        public MathProcess(double dx)
        {
            deltaX = dx;
            visual = new Bitmap(imageWidth, imageHeight);
        }

        public MathProcess(double dx, int multithreadingLevel)
        {
            this.dx = dx;
            numThreads = multithreadingLevel;

            integrationValues = new List<IntegrationThreadParameter>(numThreads);
            threads = new List<Thread>(numThreads);
            finalValues = new List<double>(numThreads);

            visual = new Bitmap(imageWidth, imageHeight);
        }
        
        public double getDefiniteIntegralThreaded(FunctionProcess f, double end)
        {
            double total = 0;
            double increment = end / numThreads;
            saveEnd = end;

            /*negDx is necessary because the integration can either go 
            left to right or right to left with respect to the origin.*/
            negDx = (end > 0) ? dx : -1 * dx;

            for (int i = 0; i < numThreads; i++)
            {
                integrationValues.Add(new IntegrationThreadParameter(f, i * increment, (i + 1) * increment));
                threads.Add(new Thread(new ParameterizedThreadStart(getDefiniteIntegral)));
                threads[i].Start(integrationValues[i]);
            }

            while (finalValues.Count < numThreads)
                Thread.Yield();

            for (int i = 0; i < finalValues.Count; i++)
                total += finalValues[i];

            threads.Clear();
            integrationValues.Clear();
            finalValues.Clear();

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

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = (int)(p.Width * 0.5f);
            int centerY = (int)(p.Height * 0.5f);
            
            //Pens for drawing
            Pen pen = new Pen(Color.Red, 1);
            Pen axes = new Pen(Color.Black, 1);
            Pen solid = new Pen(Color.FromArgb(255,Color.LightGoldenrodYellow), 1);
            Pen deriv = new Pen(Color.FromArgb(100, Color.Green), 1);
            Pen endLine = new Pen(Color.FromArgb(100, Color.Orange), 1);

            double scaleInv = xScale * .0005;

            List<PointF> points = new List<PointF>(20000);

            double yInter = f.getValue(saveEnd) - derivative * saveEnd;

            for (double x = - 20; x < 20; x += scaleInv)
            {
                temp = f.getValue(x);
                temp = temp * (-yScale) + centerY;

                points.Add(new PointF((float)(x * xScale) + centerX, (float)temp));

                if ((x < saveEnd && x > 0) || (x > saveEnd && x < 0))
                {
                    g.DrawLine(solid, (float)(x * xScale + centerX), (float)(temp), (float)(x * xScale + centerX), centerY);
                    //g.DrawLine(solid, (float)(x), (float)(temp), (float)endPoint, (float)endPoint);
                }
            }

            g.DrawLine(endLine, (float)(saveEnd * xScale + centerX), (float)(-f.getValue(saveEnd) * yScale + centerY), (float)(saveEnd * xScale + centerX), centerY);
            
            //This draw curve call is where the magic happens
            g.DrawCurve(pen, points.ToArray());

            g.DrawLine(axes, 0, centerY, p.Width, centerY);
            g.DrawLine(axes, centerX, 0, centerX, p.Height);

            //Draw the derivative line
            g.DrawLine(deriv, (float)(-200 * xScale + centerX), (float)(((derivative * -200) + yInter) * (-yScale) + centerY),
                        (float)(200 * xScale + centerX), (float)(((derivative * 200) + yInter) * (-yScale) + centerY));

            solid.Dispose();
            deriv.Dispose();
            pen.Dispose();
            axes.Dispose();

            if (transparent)
                visual.MakeTransparent(Color.White);

            return visual;
        }

        public double getSimpsonIntegral(FunctionProcess f, double end)
        {
            return end/6  * (f.getValue(0) + 4 * f.getValue(end/2) + f.getValue(end));
        }

        public double getDerivative(FunctionProcess f, double x)
        {
            derivative = (f.getValue(x + dx)-f.getValue(x)) / dx;
            return derivative;
        }
    }
}

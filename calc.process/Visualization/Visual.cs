using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;

namespace calc.process
{
    public partial class Visual : Form
    {

        MathProcess math;
        FunctionProcess function;
        InputParser input;
        Stopwatch sW;

        public Visual()
        {
            InitializeComponent();
        }

        private void Visual_Load(object sender, EventArgs e)
        {
            math = new MathProcess();
            function = new FunctionProcess();
            input = new InputParser();
            sW = new Stopwatch();

           math.deltaX = Math.Pow(10, trackBar1.Value);
           //function.setDerivativeLevel(.00001, 2);
            
            doAllDefaultActions();       
        }

        private void doAllDefaultActions()
        {
            double x = (Double)endIntegral.Value;
            //math.deltaX = Math.Pow(10, trackBar1.Value);

            //Parse input, construct the polynomial, and save it in function
            input.generateFunctionFromQuery(function, functionBox.Text);

            //Set the stop watch for performance evaluation
            sW.Start();

            double testTotal = math.getDefiniteIntegralThreaded(function, x);
            double testDeriv = math.getDerivative(function, x);

            sW.Stop();

            Console.WriteLine("\n\nDefinite integral from 0 to " + x + " is approx. equal to: " + Math.Round(testTotal, 5));
            Console.WriteLine("Derivative at " + x + " is approx. equal to: " + Math.Round(testDeriv, 5));
            Console.WriteLine("Time used for calculation: {0}ms, using {1} threads and dx value of {2}", sW.ElapsedMilliseconds, math.numThreads, math.deltaX.ToString("#.#######"));

            sW.Reset();

            pictureBox1.Image = math.getVisualization(function, pictureBox1, Math.Pow(2, xScale.Value), Math.Pow(2, yScale.Value));
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            doAllDefaultActions();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dxLabel.Text = "dx Value: " + (Math.Pow(10, trackBar1.Value)).ToString("#.#########");
            math.deltaX = Math.Pow(10, trackBar1.Value);
        }

        private void dxLabel_Click(object sender, EventArgs e)
        {
        }

        private void functionBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void functionBox_Click(object sender, EventArgs e)
        {
            functionBox.Text = "";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            endValueLabel.Text = "End Point: " + endIntegral.Value.ToString("####");
            pictureBox1.Image = math.getVisualization(function, pictureBox1, Math.Pow(2, xScale.Value), Math.Pow(2, yScale.Value));
        }

        private void yScale_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = math.getVisualization(function, pictureBox1, Math.Pow(2, xScale.Value), Math.Pow(2, yScale.Value));
        }

        private void xScale_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = math.getVisualization(function, pictureBox1, Math.Pow(2, xScale.Value), Math.Pow(2, yScale.Value));
        }

        private void endValueLabel_Click(object sender, EventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/png");
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            // Save the bitmap as a PNG file with quality level 100.
            myEncoderParameters.Param[0] = new EncoderParameter(myEncoder, 100L);

            math.visual.Save(saveFileDialog1.FileName, myImageCodecInfo, myEncoderParameters);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "png Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
        }


        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();

            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }

            return null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            math.transparent = checkBox1.Checked;
            pictureBox1.Image = math.getVisualization(function, pictureBox1, Math.Pow(2, xScale.Value), Math.Pow(2, yScale.Value));
        }

    }
}

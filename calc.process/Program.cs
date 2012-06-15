using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace calc.process
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {

            VisualizationStartThread v = new VisualizationStartThread();
        }

    }


}

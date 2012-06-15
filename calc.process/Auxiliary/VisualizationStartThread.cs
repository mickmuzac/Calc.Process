using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace calc.process
{
    class VisualizationStartThread
    {
        Thread t;

        public VisualizationStartThread()
        {

            //Application.Run(new Visual());
            t = new Thread(new ThreadStart(startVisualization));
            t.Start();
        }

        public void startVisualization()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Visual());
        }
    }
}

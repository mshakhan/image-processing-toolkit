using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using ImageProcessor.Plugins;
using ImageProcessor.Processing;

namespace Noiser
{
    public class Noiser : IPlugin
    {
        #region IPlugin Members

        public void Process(IHost host)
        {
            host.WindowManager.PrepareForm(new PluginControl(PluginControlValueType.Double, "Power", 10));			
            host.WindowManager.ShowForm();
			
			object power = host.WindowManager["Power"];
			
			if (power != null)
			{
				AddNoise((double)power, host.Processor);
			}
			else
			{
				host.WindowManager.ShowMessage("Power value is not presented");
			}
        }

        public string Name
        {
            get { return "Noiser"; }
        }

        #endregion

        private void AddNoise(double power, Processor processor)
        {
            Complex[,] noise = new Complex[processor.Dim, processor.Dim];
            Random rnd = new Random();

            for (int j = 0; j < processor.Dim; ++j)
            {
                for (int i = 0; i < processor.Dim; ++i)
                {
                    double ns = 0;
                    for (int n = 0; n < 20; ++n)
                    {
                        ns += rnd.NextDouble();
                    }
                    noise[i, j].Re = ns; 
                }
            }

            double sigE = ImageProcessor.Processing.MathUtils.GetPictureEnergy(processor.Picture, processor.Dim);
            double noiseE = ImageProcessor.Processing.MathUtils.GetPictureEnergy(noise, processor.Dim);

            double norm = Math.Sqrt(sigE / noiseE) * (power / 100.0);

            for (int j = 0; j < processor.Dim; ++j)
            {
                for (int i = 0; i < processor.Dim; ++i)
                {
                    processor.Picture[i, j].Re += noise[i, j].Re * norm;
                }
            }
        }
    }
}

using System;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace ImageProcessor.Processing
{
    public class Processor
    {
        private Complex[,] pic = null;
		
		private Complex[,] picFFT = null;
		
		private double energy = -1;

        private int dim = 0;

        public const int DEFAULT_DIM = 256;

        public int Dim { get { return dim; } }

        public Complex[,] Picture
        {
            get { return pic; }
            set 
			{ 
				pic = value;
				energy = -1;
				picFFT = null;
			}
        }
		
		public Complex[,] PictureFFT
		{
			get
			{
				if (null == picFFT)
				{
                    Complex[,] tmp = MathUtils.CloneArray(pic, dim);
					picFFT = MathUtils.GetPictureFFT(tmp, dim, FFTDirection.Forward);
					
				}
				return picFFT;
			}
		}

        public Processor()
        {
            dim = DEFAULT_DIM;
            pic = new Complex[dim, dim];

            for (int j = 0; j < dim; ++j)
            {
                for (int i = 0; i < dim; ++i)
                {
                    pic[i, j] = new Complex(1, 0);
                }
            }
        }

        public Processor(Image img)
        {
            pic = MathUtils.BmpToArray((Bitmap)img, out dim);
        }
		
        public Processor(int dim, params Gaussian[] gaussians)
        {
            this.dim = dim;
            pic = new Complex[dim, dim];

            for (int j = 0; j < dim; ++j)
            {
                for (int i = 0; i < dim; ++i)
                {
                    pic[i, j] = new Complex(0, 0);
                    foreach (Gaussian gaussian in gaussians)
                    {
                        pic[i, j].Re += gaussian.Amplitude *
                            Math.Exp(
                            -(MathUtils.Sqr(i - gaussian.Center.X) / gaussian.SigmaX)
                            -(MathUtils.Sqr(j - gaussian.Center.Y) / gaussian.SigmaY));
                    }
                }
            }
        }

		public double GetEnergy()
		{
			if (-1 == energy)
			{
				energy = MathUtils.GetPictureEnergy(pic, dim);
			}
			return energy;
		}

    }
}

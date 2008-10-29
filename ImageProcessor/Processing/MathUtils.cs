using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessor.Processing
{
    public static class MathUtils
    {
        public const int MAX_BRIGHTNESS = 255;

        #region Array/Bitmap related
        public static Complex[,] CloneArray(Complex[,] array, int dim)
        {
            Complex[,] tmp = new Complex[dim, dim];

            for (int j = 0; j < dim; ++j)
            {
                for (int i = 0; i < dim; ++i)
                {
                    tmp[i, j] = new Complex(array[i, j].Re, array[i, j].Im);
                }
            }
            return tmp;
        }

        public static Bitmap ArrayToBmp(Complex[,] array, int dim)
        {
            return ArrayToBmp(array, dim, false);
        }

        public static Bitmap ArrayToBmp(Complex[,] array, int dim, bool log)
        {
            Bitmap bmp = new Bitmap(dim, dim);
            double maxBrightness = double.MinValue;
            Complex first = new Complex(array[0, 0].Re, array[0, 0].Im);
            array[0, 0].Im = 0;
            array[0, 0].Re = 0;
            for (int j = 0; j < dim; ++j)
            {
                for (int i = 0; i < dim; ++i)
                {
                    if (array[i, j].Re > maxBrightness)
                    {
                        maxBrightness = log ? array[i, j].AbsLog : array[i, j].Abs;
                    }
                }
            }

            array[0, 0].Re = first.Re;
            array[0, 0].Im = first.Im;

            double scale = (1 / maxBrightness) * MAX_BRIGHTNESS;
            for (int j = 0; j < dim; ++j)
            {
                for (int i = 0; i < dim; ++i)
                {
                    int pixelColor = (int)(log ? array[i, j].AbsLog : array[i, j].Abs * scale);
                    if (pixelColor > 255)
                    {
                        pixelColor = 255;
                    }
                    bmp.SetPixel(i, j, Color.FromArgb(pixelColor, pixelColor, pixelColor));
                }
            }
            return bmp;
        }

        public static Complex[,] BmpToArray(Bitmap bmp, out int dim)
        {
            dim = (bmp.Width > bmp.Height) ? bmp.Width : bmp.Height;

            int[] res = new int[] { 256, 512, 1024, 2048 };

            for (int i = 0; i < res.Length - 1; ++i)
            {
                if (dim > res[i] && dim < res[i + 1])
                {
                    dim = res[i];
                    break;
                }
                dim = res[0];
            }

            Complex[,] array = new Complex[dim, dim];

            for (int j = 0; j < dim; ++j)
            {
                for (int i = 0; i < dim; ++i)
                {
                    double re = 0;

                    if (i < bmp.Width && j < bmp.Height)
                    {
                        Color col = bmp.GetPixel(i, j);
                        re = (double)(0.299 * col.R + 0.587 * col.G + 0.114 * col.B);
                    }

                    array[i, j] = new Complex(re, 0);
                }
            }

            return array;
        }

        /*public static Complex[,] Stretch(Complex[,] array, Size size, int dim)
        {
            Complex[,] stretched = new Complex[dim, dim];

            double dx = (double)size.Width / dim;
            double dy = (double)size.Height / dim;

            double y = 0.0;
            for (int j = 0; j < dim; ++j)
            {
                double x = 0.0;
                y += dy;
                for (int i = 0; i < dim; ++i)
                {
                    x += dx;

                }
            }

            return stretched;
        }

        static private Complex[] StretchLine(Complex[] line, int dim)
        {

        }*/
        #endregion

        #region Math methods

        public static int Sqr(int value)
        {
            return value * value;
        }

        public static double Sqr(double value)
        {
            return value * value;
        }

        public static Gaussian[] GenerateGaussians(int amount, int dim)
        {
            List<Gaussian> gaussians = new List<Gaussian>(amount);
            Random rand = new Random();

            for (int i = 0; i < amount; ++i)
            {
                gaussians.Add(new Gaussian(
                    rand.NextDouble(),
                    new Point(rand.Next(dim), rand.Next(dim)),
                    /*MathUtils.Sqr(pictureSize.Height)*/5000 * rand.NextDouble(),
                    /*MathUtils.Sqr(pictureSize.Height)*/5000 * rand.NextDouble()
                    )
               );
            }

            return gaussians.ToArray();
        }
		
		public static double GetPictureEnergy(Complex[,] pic, int dim)
		{
            double e = 0;

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    e += pic[i, j].Re;
                }
            }

			return e / Sqr(dim);
		}
		
		public static Complex[,] GetPictureFFT(Complex[,] image, int dim, FFTDirection direction)
		{
			Complex[] data = new Complex[dim];
            
			for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    data[j] = image[j, i];
                }
                FFT(ref data, direction);
                for (int j = 0; j < dim; j++)
                {
                     image[j, i] = data[j];
                }
            }
			data = new Complex[dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    data[j] = image[i, j];
                }
                FFT(ref data, direction);
                for (int j = 0; j < dim; j++)
                {
                    image[i, j] = data[j];
                }
            }

			Complex[,] spectrum = new Complex[dim, dim];
			
	        for (int i = 0; i < dim / 2; i++)
            {
                for (int j = 0; j < dim/2; j++)
                {
                    spectrum[i, j] = image[i + dim / 2, j + dim / 2];
                    spectrum[i + dim / 2, j + dim / 2] = image[i, j];
                    spectrum[i + dim / 2, j] = image[i, j + dim / 2];
                    spectrum[i, j + dim / 2] = image[i + dim / 2, j];
                }
            }
			
			return spectrum;
		}
		
		static void FFT(ref Complex[] data, FFTDirection direction)
		{
			int n = data.Length;
			int i, j, istep;
			int m, mmax;
			double r, r1, theta, w_r, w_i, temp_r, temp_i;

			r = Math.PI;
			
			if(FFTDirection.Forward == direction) { r = -r; }
			j = 0;
			for(i = 0; i < n; i++)
			{
				if(i < j)
				{
				     temp_r = data[j].Re;
				     temp_i = data[j].Im;
				     data[j].Re = data[i].Re;
				     data[j].Im = data[i].Im;
				     data[i].Re = temp_r;
				     data[i].Im = temp_i;
				}
				m = n >> 1;
				while(j >= m) 
				{ 
					j -= m; 
					m = (m + 1) / 2; 
				}
				j += m;
			}
			mmax = 1;
			while(mmax < n)
			{
			    istep = mmax << 1;
			    r1 = r / (double)mmax;
			    for(m = 0; m < mmax; m++)
			    {
					theta = r1 * m;
					w_r = Math.Cos(theta);
					w_i = Math.Sin(theta);
					for(i = m; i < n; i += istep)
					{
						j = i + mmax;
						temp_r = w_r * data[j].Re - w_i * data[j].Im;
						temp_i = w_r * data[j].Im + w_i * data[j].Re;
						data[j].Re = data[i].Re - temp_r;
						data[j].Im = data[i].Im - temp_i;
						data[i].Re += temp_r;
						data[i].Im += temp_i;
					}
			    }
			    mmax = istep;
			}
			if(FFTDirection.Reverse == direction)
			for(i = 0; i < n; i++)
			{
				data[i].Re /= (double)n;
				data[i].Im /= (double)n;
			}
        }
        #endregion
    }
	
    #region Misc classes
	
	public enum FFTDirection
	{
		Forward,
		Reverse
	}
	
	public struct Complex
	{
		public double Im;
		public double Re;
		
		public Complex(double r, double i)
		{
			Im = i;
			Re = r;
		}
		
		public double Abs { get { return Math.Sqrt(MathUtils.Sqr(Im) + MathUtils.Sqr(Re)); } }

        public double AbsLog { get { return Abs; } }
	}

    public struct Gaussian
    {
        public Gaussian(double amplitude, Point center, double sigmax, double sigmay)
        {
            Amplitude = amplitude;
            Center = center;
            SigmaX = sigmax;
            SigmaY = sigmay;
        }

        public double Amplitude;
        public Point Center;
        public double SigmaX;
        public double SigmaY;
    }
	
    #endregion
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

using ImageProcessor.Processing;
using ImageProcessor.Plugins;

namespace ImageProcessor
{
    partial class frmMain : Form
    {
        Processor processor = new Processor();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitPlugins();
        }

        private void InitPlugins()
        {
            PluginManager.LoadPlugins(Environment.CurrentDirectory, 
                pluginsToolStripMenuItem,
                new EventHandler(pluginMenuItem_Click));
        }

        private void LoadImage(Image img)
        {
            pb.Image = img;
            Size size = new Size(img.Width, img.Height);
            pb.Width = size.Width;
            pb.Height = size.Height;
            ClientSize = size;
            MinimumSize = size;
        }

        private void pluginMenuItem_Click(object sender, EventArgs e)
        {
            string pluginName = ((ToolStripMenuItem)sender).Tag.ToString();
			PluginManager.CallPlugin(pluginName, processor);
			LoadImage(MathUtils.ArrayToBmp(processor.Picture, processor.Dim));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                processor = new Processor(Image.FromFile(dlgOpen.FileName));
                LoadImage(MathUtils.ArrayToBmp(processor.Picture, processor.Dim));
                rbImage.Checked = true;
            }
        }
		
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
				//processor.Bitmap.Save(dlgSave.FileName, ImageFormat.Jpeg);
            }
        }		

        private void newGaussiansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gaussian[] gaussians = MathUtils.GenerateGaussians(3, Processor.DEFAULT_DIM);

            processor = new Processor(256, gaussians);
            LoadImage(MathUtils.ArrayToBmp(processor.Picture, processor.Dim));
            rbImage.Checked = true;
        }

        private void rbImage_CheckedChanged(object sender, EventArgs e)
        {
            LoadImage(MathUtils.ArrayToBmp(processor.Picture, processor.Dim));
        }

        private void rbSpectrum_CheckedChanged(object sender, EventArgs e)
        {
            LoadImage(MathUtils.ArrayToBmp(processor.PictureFFT, processor.Dim, true));
        }
    }
}
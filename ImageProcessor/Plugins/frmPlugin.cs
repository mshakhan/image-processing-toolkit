using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessor.Plugins
{
    partial class frmPlugin : Form
    {
        public frmPlugin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
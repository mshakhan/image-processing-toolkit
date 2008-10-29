namespace ImageProcessor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb = new System.Windows.Forms.PictureBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGaussiansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.grView = new System.Windows.Forms.GroupBox();
            this.rbSpectrum = new System.Windows.Forms.RadioButton();
            this.rbImage = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.mnuMain.SuspendLayout();
            this.grView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 24);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(292, 249);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(292, 24);
            this.mnuMain.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGaussiansToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGaussiansToolStripMenuItem
            // 
            this.newGaussiansToolStripMenuItem.Name = "newGaussiansToolStripMenuItem";
            this.newGaussiansToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.newGaussiansToolStripMenuItem.Text = "New gaussians";
            this.newGaussiansToolStripMenuItem.Click += new System.EventHandler(this.newGaussiansToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // grView
            // 
            this.grView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grView.Controls.Add(this.rbSpectrum);
            this.grView.Controls.Add(this.rbImage);
            this.grView.Location = new System.Drawing.Point(211, 24);
            this.grView.Name = "grView";
            this.grView.Size = new System.Drawing.Size(81, 45);
            this.grView.TabIndex = 2;
            this.grView.TabStop = false;
            // 
            // rbSpectrum
            // 
            this.rbSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSpectrum.AutoSize = true;
            this.rbSpectrum.Location = new System.Drawing.Point(8, 22);
            this.rbSpectrum.Name = "rbSpectrum";
            this.rbSpectrum.Size = new System.Drawing.Size(70, 17);
            this.rbSpectrum.TabIndex = 1;
            this.rbSpectrum.TabStop = true;
            this.rbSpectrum.Text = "Spectrum";
            this.rbSpectrum.UseVisualStyleBackColor = true;
            this.rbSpectrum.CheckedChanged += new System.EventHandler(this.rbSpectrum_CheckedChanged);
            // 
            // rbImage
            // 
            this.rbImage.AutoSize = true;
            this.rbImage.Location = new System.Drawing.Point(8, 7);
            this.rbImage.Name = "rbImage";
            this.rbImage.Size = new System.Drawing.Size(54, 17);
            this.rbImage.TabIndex = 0;
            this.rbImage.TabStop = true;
            this.rbImage.Text = "Image";
            this.rbImage.UseVisualStyleBackColor = true;
            this.rbImage.CheckedChanged += new System.EventHandler(this.rbImage_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.grView);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Image Processor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.grView.ResumeLayout(false);
            this.grView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGaussiansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.GroupBox grView;
        private System.Windows.Forms.RadioButton rbSpectrum;
        private System.Windows.Forms.RadioButton rbImage;
    }
}


namespace BitmapPixelsDemo
{
    partial class MainForm
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OriginalImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BitmapPixelsGrayscaleImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SetPixelsGrayscaleImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BitmapPixelsConvertTimeLabel = new System.Windows.Forms.Label();
            this.SetPixelConvertTimeLabel = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitmapPixelsGrayscaleImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPixelsGrayscaleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(638, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOpenMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileMenuItem.Text = "&File";
            // 
            // FileOpenMenuItem
            // 
            this.FileOpenMenuItem.Name = "FileOpenMenuItem";
            this.FileOpenMenuItem.Size = new System.Drawing.Size(139, 22);
            this.FileOpenMenuItem.Text = "&Open Image";
            this.FileOpenMenuItem.Click += new System.EventHandler(this.FileOpenMenuItem_Click);
            // 
            // OriginalImage
            // 
            this.OriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalImage.Location = new System.Drawing.Point(12, 48);
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.Size = new System.Drawing.Size(200, 200);
            this.OriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalImage.TabIndex = 1;
            this.OriginalImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Image";
            // 
            // BitmapPixelsGrayscaleImage
            // 
            this.BitmapPixelsGrayscaleImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BitmapPixelsGrayscaleImage.Location = new System.Drawing.Point(218, 48);
            this.BitmapPixelsGrayscaleImage.Name = "BitmapPixelsGrayscaleImage";
            this.BitmapPixelsGrayscaleImage.Size = new System.Drawing.Size(200, 200);
            this.BitmapPixelsGrayscaleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BitmapPixelsGrayscaleImage.TabIndex = 1;
            this.BitmapPixelsGrayscaleImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grayscale (BitmapPixels)";
            // 
            // SetPixelsGrayscaleImage
            // 
            this.SetPixelsGrayscaleImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetPixelsGrayscaleImage.Location = new System.Drawing.Point(424, 48);
            this.SetPixelsGrayscaleImage.Name = "SetPixelsGrayscaleImage";
            this.SetPixelsGrayscaleImage.Size = new System.Drawing.Size(200, 200);
            this.SetPixelsGrayscaleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SetPixelsGrayscaleImage.TabIndex = 1;
            this.SetPixelsGrayscaleImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grayscale (SetPixel)";
            // 
            // OpenImageDialog
            // 
            this.OpenImageDialog.Filter = "All Images|*.BMP;*.JPG;*.JPEG;*.JPE;*.GIF;*.PNG|All Files|*.*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Convert Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Convert Time:";
            // 
            // BitmapPixelsConvertTimeLabel
            // 
            this.BitmapPixelsConvertTimeLabel.AutoSize = true;
            this.BitmapPixelsConvertTimeLabel.Location = new System.Drawing.Point(297, 252);
            this.BitmapPixelsConvertTimeLabel.Name = "BitmapPixelsConvertTimeLabel";
            this.BitmapPixelsConvertTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.BitmapPixelsConvertTimeLabel.TabIndex = 5;
            // 
            // SetPixelConvertTimeLabel
            // 
            this.SetPixelConvertTimeLabel.AutoSize = true;
            this.SetPixelConvertTimeLabel.Location = new System.Drawing.Point(503, 252);
            this.SetPixelConvertTimeLabel.Name = "SetPixelConvertTimeLabel";
            this.SetPixelConvertTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.SetPixelConvertTimeLabel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 274);
            this.Controls.Add(this.SetPixelConvertTimeLabel);
            this.Controls.Add(this.BitmapPixelsConvertTimeLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SetPixelsGrayscaleImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BitmapPixelsGrayscaleImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OriginalImage);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Convert to Grayscal";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitmapPixelsGrayscaleImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPixelsGrayscaleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileOpenMenuItem;
        private System.Windows.Forms.PictureBox OriginalImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox BitmapPixelsGrayscaleImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox SetPixelsGrayscaleImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog OpenImageDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label BitmapPixelsConvertTimeLabel;
        private System.Windows.Forms.Label SetPixelConvertTimeLabel;
    }
}


namespace S3AWS_Sample
{
    partial class frmS3Access
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblSourceFileName = new System.Windows.Forms.Label();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.chkImagePReview = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(127, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "&Browse && Upload ... ";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // picPreview
            // 
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(12, 39);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(255, 238);
            this.picPreview.TabIndex = 2;
            this.picPreview.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(394, 283);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "&Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblSourceFileName
            // 
            this.lblSourceFileName.AutoSize = true;
            this.lblSourceFileName.Location = new System.Drawing.Point(145, 15);
            this.lblSourceFileName.Name = "lblSourceFileName";
            this.lblSourceFileName.Size = new System.Drawing.Size(16, 13);
            this.lblSourceFileName.TabIndex = 6;
            this.lblSourceFileName.Text = "---";
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(273, 39);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(196, 238);
            this.lstFiles.TabIndex = 7;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // btnListFiles
            // 
            this.btnListFiles.Location = new System.Drawing.Point(273, 283);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(75, 23);
            this.btnListFiles.TabIndex = 8;
            this.btnListFiles.Text = "&List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // chkImagePReview
            // 
            this.chkImagePReview.AutoSize = true;
            this.chkImagePReview.Checked = true;
            this.chkImagePReview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImagePReview.Location = new System.Drawing.Point(12, 288);
            this.chkImagePReview.Name = "chkImagePReview";
            this.chkImagePReview.Size = new System.Drawing.Size(96, 17);
            this.chkImagePReview.TabIndex = 9;
            this.chkImagePReview.Text = "Image Preview";
            this.chkImagePReview.UseVisualStyleBackColor = true;
            // 
            // frmS3Access
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 313);
            this.Controls.Add(this.chkImagePReview);
            this.Controls.Add(this.btnListFiles);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lblSourceFileName);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnBrowse);
            this.Name = "frmS3Access";
            this.Text = "AWS S3 Files Repository Sample";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblSourceFileName;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.CheckBox chkImagePReview;
    }
}


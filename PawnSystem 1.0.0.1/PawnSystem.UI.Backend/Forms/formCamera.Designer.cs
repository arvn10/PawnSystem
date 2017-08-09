namespace PawnSystem.UI.Backend.Forms
{
    partial class formCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCamera));
            this.pictureCamera = new System.Windows.Forms.PictureBox();
            this.buttonCapture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCamera
            // 
            this.pictureCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureCamera.Location = new System.Drawing.Point(0, 0);
            this.pictureCamera.Name = "pictureCamera";
            this.pictureCamera.Size = new System.Drawing.Size(426, 344);
            this.pictureCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCamera.TabIndex = 14;
            this.pictureCamera.TabStop = false;
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(0, 350);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(426, 41);
            this.buttonCapture.TabIndex = 15;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // formCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 397);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.pictureCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Photo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formCamera_FormClosing);
            this.Load += new System.EventHandler(this.formCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureCamera;
        private System.Windows.Forms.Button buttonCapture;
    }
}
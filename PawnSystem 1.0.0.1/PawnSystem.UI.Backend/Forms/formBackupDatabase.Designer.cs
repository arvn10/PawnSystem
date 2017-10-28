namespace PawnSystem.UI.Backend.Forms
{
    partial class formBackupDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBackupDatabase));
            this.buttonBackup = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelPercent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBackup
            // 
            this.buttonBackup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackup.Location = new System.Drawing.Point(354, 35);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(67, 23);
            this.buttonBackup.TabIndex = 3;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(58, 35);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(290, 23);
            this.progressBar.TabIndex = 4;
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPercent.Location = new System.Drawing.Point(5, 39);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(26, 15);
            this.labelPercent.TabIndex = 5;
            this.labelPercent.Text = "0 %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status :";
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelStatus.Location = new System.Drawing.Point(58, 64);
            this.labelStatus.Multiline = true;
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(363, 27);
            this.labelStatus.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Backup File will be save on C:\\PawnSystem Database Backup";
            // 
            // formBackupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 98);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formBackupDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Database";
            this.Load += new System.EventHandler(this.formBackupDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox labelStatus;
        private System.Windows.Forms.Label label1;
    }
}
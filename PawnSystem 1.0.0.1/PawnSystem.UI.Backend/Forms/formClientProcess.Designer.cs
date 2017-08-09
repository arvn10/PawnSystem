namespace PawnSystem.UI.Backend.Forms
{
    partial class formClientProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formClientProcess));
            this.groupClientInfo = new System.Windows.Forms.GroupBox();
            this.textContactNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textLastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textFirstname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupClientPhoto = new System.Windows.Forms.GroupBox();
            this.buttonTakePhoto = new System.Windows.Forms.Button();
            this.pictureClient = new System.Windows.Forms.PictureBox();
            this.groupClientInfo.SuspendLayout();
            this.groupClientPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClient)).BeginInit();
            this.SuspendLayout();
            // 
            // groupClientInfo
            // 
            this.groupClientInfo.Controls.Add(this.textContactNumber);
            this.groupClientInfo.Controls.Add(this.label4);
            this.groupClientInfo.Controls.Add(this.textAddress);
            this.groupClientInfo.Controls.Add(this.label3);
            this.groupClientInfo.Controls.Add(this.textLastname);
            this.groupClientInfo.Controls.Add(this.label2);
            this.groupClientInfo.Controls.Add(this.textFirstname);
            this.groupClientInfo.Controls.Add(this.label1);
            this.groupClientInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupClientInfo.Location = new System.Drawing.Point(12, 12);
            this.groupClientInfo.Name = "groupClientInfo";
            this.groupClientInfo.Size = new System.Drawing.Size(345, 286);
            this.groupClientInfo.TabIndex = 16;
            this.groupClientInfo.TabStop = false;
            this.groupClientInfo.Text = "Client Information";
            // 
            // textContactNumber
            // 
            this.textContactNumber.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContactNumber.Location = new System.Drawing.Point(10, 249);
            this.textContactNumber.Name = "textContactNumber";
            this.textContactNumber.Size = new System.Drawing.Size(329, 26);
            this.textContactNumber.TabIndex = 7;
            this.textContactNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContactNumber_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contact Number :";
            // 
            // textAddress
            // 
            this.textAddress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAddress.Location = new System.Drawing.Point(10, 158);
            this.textAddress.Multiline = true;
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(329, 64);
            this.textAddress.TabIndex = 5;
            this.textAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAddress_KeyPress);
            this.textAddress.Leave += new System.EventHandler(this.textAddress_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address :";
            // 
            // textLastname
            // 
            this.textLastname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLastname.Location = new System.Drawing.Point(10, 105);
            this.textLastname.Name = "textLastname";
            this.textLastname.Size = new System.Drawing.Size(329, 26);
            this.textLastname.TabIndex = 3;
            this.textLastname.Leave += new System.EventHandler(this.textLastname_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lastname :";
            // 
            // textFirstname
            // 
            this.textFirstname.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFirstname.Location = new System.Drawing.Point(10, 52);
            this.textFirstname.Name = "textFirstname";
            this.textFirstname.Size = new System.Drawing.Size(329, 26);
            this.textFirstname.TabIndex = 1;
            this.textFirstname.Leave += new System.EventHandler(this.textFirstname_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firstname :";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(480, 264);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(92, 28);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupClientPhoto
            // 
            this.groupClientPhoto.Controls.Add(this.buttonTakePhoto);
            this.groupClientPhoto.Controls.Add(this.pictureClient);
            this.groupClientPhoto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupClientPhoto.Location = new System.Drawing.Point(363, 14);
            this.groupClientPhoto.Name = "groupClientPhoto";
            this.groupClientPhoto.Size = new System.Drawing.Size(209, 244);
            this.groupClientPhoto.TabIndex = 18;
            this.groupClientPhoto.TabStop = false;
            this.groupClientPhoto.Text = "Client Photo";
            // 
            // buttonTakePhoto
            // 
            this.buttonTakePhoto.Enabled = false;
            this.buttonTakePhoto.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTakePhoto.Location = new System.Drawing.Point(6, 207);
            this.buttonTakePhoto.Name = "buttonTakePhoto";
            this.buttonTakePhoto.Size = new System.Drawing.Size(197, 28);
            this.buttonTakePhoto.TabIndex = 18;
            this.buttonTakePhoto.Text = "Take Photo";
            this.buttonTakePhoto.UseVisualStyleBackColor = true;
            this.buttonTakePhoto.Click += new System.EventHandler(this.buttonTakePhoto_Click);
            // 
            // pictureClient
            // 
            this.pictureClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureClient.Location = new System.Drawing.Point(6, 31);
            this.pictureClient.Name = "pictureClient";
            this.pictureClient.Size = new System.Drawing.Size(197, 170);
            this.pictureClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureClient.TabIndex = 0;
            this.pictureClient.TabStop = false;
            this.pictureClient.Tag = "Default";
            // 
            // formClientProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 314);
            this.Controls.Add(this.groupClientPhoto);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupClientInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formClientProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.formClientProcess_Load);
            this.groupClientInfo.ResumeLayout(false);
            this.groupClientInfo.PerformLayout();
            this.groupClientPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupClientInfo;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textContactNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textLastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textFirstname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupClientPhoto;
        private System.Windows.Forms.Button buttonTakePhoto;
        public System.Windows.Forms.PictureBox pictureClient;
    }
}
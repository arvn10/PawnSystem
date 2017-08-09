namespace PawnSystem.UI.Backend.Forms
{
    partial class formServiceCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formServiceCharge));
            this.label1 = new System.Windows.Forms.Label();
            this.textToCheckAmount = new System.Windows.Forms.TextBox();
            this.textHigherAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textLowerAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount :";
            // 
            // textToCheckAmount
            // 
            this.textToCheckAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textToCheckAmount.Location = new System.Drawing.Point(16, 33);
            this.textToCheckAmount.Name = "textToCheckAmount";
            this.textToCheckAmount.Size = new System.Drawing.Size(300, 26);
            this.textToCheckAmount.TabIndex = 1;
            this.textToCheckAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textToCheckAmount_KeyPress);
            // 
            // textHigherAmount
            // 
            this.textHigherAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textHigherAmount.Location = new System.Drawing.Point(16, 86);
            this.textHigherAmount.Name = "textHigherAmount";
            this.textHigherAmount.Size = new System.Drawing.Size(300, 26);
            this.textHigherAmount.TabIndex = 3;
            this.textHigherAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHigherAmount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "If Principal >= Amount :";
            // 
            // textLowerAmount
            // 
            this.textLowerAmount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLowerAmount.Location = new System.Drawing.Point(16, 139);
            this.textLowerAmount.Name = "textLowerAmount";
            this.textLowerAmount.Size = new System.Drawing.Size(300, 26);
            this.textLowerAmount.TabIndex = 5;
            this.textLowerAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLowerAmount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "If Principal < Amount (Percentage) :";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(223, 171);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(93, 32);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // formServiceCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 209);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textLowerAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textHigherAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textToCheckAmount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formServiceCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Charge";
            this.Load += new System.EventHandler(this.formServiceCharge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textToCheckAmount;
        private System.Windows.Forms.TextBox textHigherAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLowerAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSave;
    }
}
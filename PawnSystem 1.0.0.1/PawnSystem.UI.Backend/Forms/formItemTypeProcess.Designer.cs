namespace PawnSystem.UI.Backend.Forms
{
    partial class formItemTypeProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formItemTypeProcess));
            this.textDaysToMature = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboWithSC = new System.Windows.Forms.ComboBox();
            this.textDaysToExpire = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textPenalty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textInterest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textDaysToPenalty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textAppraiseValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textDaysToMature
            // 
            this.textDaysToMature.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDaysToMature.Location = new System.Drawing.Point(16, 298);
            this.textDaysToMature.Name = "textDaysToMature";
            this.textDaysToMature.Size = new System.Drawing.Size(338, 26);
            this.textDaysToMature.TabIndex = 12;
            this.textDaysToMature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDaysToMature_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Number of Day(s) to Mature :";
            // 
            // comboWithSC
            // 
            this.comboWithSC.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboWithSC.FormattingEnabled = true;
            this.comboWithSC.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboWithSC.Location = new System.Drawing.Point(16, 245);
            this.comboWithSC.Name = "comboWithSC";
            this.comboWithSC.Size = new System.Drawing.Size(338, 26);
            this.comboWithSC.TabIndex = 10;
            this.comboWithSC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboWithSC_KeyPress);
            // 
            // textDaysToExpire
            // 
            this.textDaysToExpire.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDaysToExpire.Location = new System.Drawing.Point(16, 351);
            this.textDaysToExpire.Name = "textDaysToExpire";
            this.textDaysToExpire.Size = new System.Drawing.Size(338, 26);
            this.textDaysToExpire.TabIndex = 9;
            this.textDaysToExpire.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDaysToExpire_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of Day(s) to Expire :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "With Service Charge? :";
            // 
            // textPenalty
            // 
            this.textPenalty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPenalty.Location = new System.Drawing.Point(16, 139);
            this.textPenalty.Name = "textPenalty";
            this.textPenalty.Size = new System.Drawing.Size(338, 26);
            this.textPenalty.TabIndex = 5;
            this.textPenalty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPenalty_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Penalty :";
            // 
            // textInterest
            // 
            this.textInterest.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textInterest.Location = new System.Drawing.Point(16, 86);
            this.textInterest.Name = "textInterest";
            this.textInterest.Size = new System.Drawing.Size(338, 26);
            this.textInterest.TabIndex = 3;
            this.textInterest.TextChanged += new System.EventHandler(this.textInterest_TextChanged);
            this.textInterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInterest_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interest :";
            // 
            // textItemName
            // 
            this.textItemName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textItemName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textItemName.Location = new System.Drawing.Point(16, 33);
            this.textItemName.Name = "textItemName";
            this.textItemName.Size = new System.Drawing.Size(338, 26);
            this.textItemName.TabIndex = 1;
            this.textItemName.Leave += new System.EventHandler(this.textItemName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name :";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(258, 436);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 30);
            this.buttonSave.TabIndex = 28;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textDaysToPenalty
            // 
            this.textDaysToPenalty.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDaysToPenalty.Location = new System.Drawing.Point(16, 404);
            this.textDaysToPenalty.Name = "textDaysToPenalty";
            this.textDaysToPenalty.Size = new System.Drawing.Size(338, 26);
            this.textDaysToPenalty.TabIndex = 30;
            this.textDaysToPenalty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDaysToPenalty_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 21);
            this.label7.TabIndex = 29;
            this.label7.Text = "Number of Day(s) to Penalty :";
            // 
            // textAppraiseValue
            // 
            this.textAppraiseValue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAppraiseValue.Location = new System.Drawing.Point(16, 192);
            this.textAppraiseValue.Name = "textAppraiseValue";
            this.textAppraiseValue.Size = new System.Drawing.Size(338, 26);
            this.textAppraiseValue.TabIndex = 32;
            this.textAppraiseValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAppraiseValue_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 31;
            this.label8.Text = "Appraise Value :";
            // 
            // formItemTypeProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 481);
            this.Controls.Add(this.textAppraiseValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textDaysToPenalty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textDaysToMature);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboWithSC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textDaysToExpire);
            this.Controls.Add(this.textItemName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textInterest);
            this.Controls.Add(this.textPenalty);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formItemTypeProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Type";
            this.Load += new System.EventHandler(this.formItemTypeProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPenalty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textInterest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDaysToExpire;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboWithSC;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textDaysToMature;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDaysToPenalty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textAppraiseValue;
        private System.Windows.Forms.Label label8;
    }
}
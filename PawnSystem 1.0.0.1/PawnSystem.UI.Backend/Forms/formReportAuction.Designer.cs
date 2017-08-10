namespace PawnSystem.UI.Backend.Forms
{
    partial class formReportAuction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formReportAuction));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboAuctionDate = new System.Windows.Forms.ComboBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.auctionReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.auctionReport = new PawnSystem.UI.Backend.Reports.Report.auctionReport();
            this.comboTicketType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.comboTicketType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboAuctionDate);
            this.groupBox1.Controls.Add(this.buttonGenerate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 633);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // comboAuctionDate
            // 
            this.comboAuctionDate.FormattingEnabled = true;
            this.comboAuctionDate.Location = new System.Drawing.Point(9, 44);
            this.comboAuctionDate.Name = "comboAuctionDate";
            this.comboAuctionDate.Size = new System.Drawing.Size(210, 26);
            this.comboAuctionDate.TabIndex = 6;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(9, 126);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(210, 32);
            this.buttonGenerate.TabIndex = 5;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auction Date :";
            // 
            // auctionReportViewer
            // 
            this.auctionReportViewer.ActiveViewIndex = -1;
            this.auctionReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auctionReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.auctionReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.auctionReportViewer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auctionReportViewer.Location = new System.Drawing.Point(243, 12);
            this.auctionReportViewer.Name = "auctionReportViewer";
            this.auctionReportViewer.Size = new System.Drawing.Size(826, 633);
            this.auctionReportViewer.TabIndex = 2;
            this.auctionReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // auctionReport
            // 
            this.auctionReport.InitReport += new System.EventHandler(this.auctionReport1_InitReport);
            // 
            // comboTicketType
            // 
            this.comboTicketType.FormattingEnabled = true;
            this.comboTicketType.Location = new System.Drawing.Point(9, 94);
            this.comboTicketType.Name = "comboTicketType";
            this.comboTicketType.Size = new System.Drawing.Size(210, 26);
            this.comboTicketType.TabIndex = 8;
            this.comboTicketType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboTicketType_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ticket Type :";
            // 
            // formReportAuction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1081, 657);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.auctionReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formReportAuction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auction Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formReportAuction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer auctionReportViewer;
        private System.Windows.Forms.ComboBox comboAuctionDate;
        private Reports.Report.auctionReport auctionReport;
        private System.Windows.Forms.ComboBox comboTicketType;
        private System.Windows.Forms.Label label2;
    }
}
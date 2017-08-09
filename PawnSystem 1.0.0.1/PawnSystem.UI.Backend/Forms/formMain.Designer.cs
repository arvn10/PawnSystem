namespace PawnSystem.UI.Backend.Forms
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelUsername = new System.Windows.Forms.ToolStripLabel();
            this.toolStripClient = new System.Windows.Forms.ToolStripButton();
            this.toolStripReport = new System.Windows.Forms.ToolStripDropDownButton();
            this.inLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auctionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penaltyNoticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStraipConfiguration = new System.Windows.Forms.ToolStripDropDownButton();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auctionDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceChargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.letterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envelopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonLogout,
            this.toolStripSeparator1,
            this.labelUsername,
            this.toolStripClient,
            this.toolStripReport,
            this.toolStraipConfiguration});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1275, 28);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonLogout.Image = global::PawnSystem.UI.Backend.Properties.Resources.Button_Turn_Off_01;
            this.buttonLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(82, 25);
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // labelUsername
            // 
            this.labelUsername.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelUsername.Image = global::PawnSystem.UI.Backend.Properties.Resources.Administrator;
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(150, 25);
            this.labelUsername.Text = "Logged on User : ";
            this.labelUsername.Visible = false;
            // 
            // toolStripClient
            // 
            this.toolStripClient.Image = global::PawnSystem.UI.Backend.Properties.Resources.Client_2;
            this.toolStripClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClient.Name = "toolStripClient";
            this.toolStripClient.Size = new System.Drawing.Size(123, 25);
            this.toolStripClient.Text = "Client Profile";
            this.toolStripClient.ToolTipText = "Client";
            this.toolStripClient.Click += new System.EventHandler(this.toolStripClient_Click);
            // 
            // toolStripReport
            // 
            this.toolStripReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inLedgerToolStripMenuItem,
            this.outLedgerToolStripMenuItem,
            this.auctionReportToolStripMenuItem,
            this.transactionToolStripMenuItem1,
            this.penaltyNoticeToolStripMenuItem});
            this.toolStripReport.Image = global::PawnSystem.UI.Backend.Properties.Resources.Document_Chart_01;
            this.toolStripReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReport.Name = "toolStripReport";
            this.toolStripReport.Size = new System.Drawing.Size(91, 25);
            this.toolStripReport.Text = "Report";
            // 
            // inLedgerToolStripMenuItem
            // 
            this.inLedgerToolStripMenuItem.Name = "inLedgerToolStripMenuItem";
            this.inLedgerToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.inLedgerToolStripMenuItem.Text = "In Ledger";
            this.inLedgerToolStripMenuItem.Click += new System.EventHandler(this.inLedgerToolStripMenuItem_Click);
            // 
            // outLedgerToolStripMenuItem
            // 
            this.outLedgerToolStripMenuItem.Name = "outLedgerToolStripMenuItem";
            this.outLedgerToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.outLedgerToolStripMenuItem.Text = "Out Ledger";
            this.outLedgerToolStripMenuItem.Click += new System.EventHandler(this.outLedgerToolStripMenuItem_Click);
            // 
            // auctionReportToolStripMenuItem
            // 
            this.auctionReportToolStripMenuItem.Name = "auctionReportToolStripMenuItem";
            this.auctionReportToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.auctionReportToolStripMenuItem.Text = "Auction Report";
            this.auctionReportToolStripMenuItem.Click += new System.EventHandler(this.auctionReportToolStripMenuItem_Click);
            // 
            // penaltyNoticeToolStripMenuItem
            // 
            this.penaltyNoticeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.letterToolStripMenuItem,
            this.envelopeToolStripMenuItem});
            this.penaltyNoticeToolStripMenuItem.Name = "penaltyNoticeToolStripMenuItem";
            this.penaltyNoticeToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.penaltyNoticeToolStripMenuItem.Text = "Penalty Notice";
            // 
            // transactionToolStripMenuItem1
            // 
            this.transactionToolStripMenuItem1.Name = "transactionToolStripMenuItem1";
            this.transactionToolStripMenuItem1.Size = new System.Drawing.Size(190, 26);
            this.transactionToolStripMenuItem1.Text = "Transaction";
            this.transactionToolStripMenuItem1.Click += new System.EventHandler(this.transactionToolStripMenuItem1_Click);
            // 
            // toolStraipConfiguration
            // 
            this.toolStraipConfiguration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.transactionToolStripMenuItem});
            this.toolStraipConfiguration.Image = global::PawnSystem.UI.Backend.Properties.Resources.Gear_01;
            this.toolStraipConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStraipConfiguration.Name = "toolStraipConfiguration";
            this.toolStraipConfiguration.Size = new System.Drawing.Size(138, 25);
            this.toolStraipConfiguration.Text = "Configuration";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Image = global::PawnSystem.UI.Backend.Properties.Resources.Administrator;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemTypeToolStripMenuItem,
            this.auctionDateToolStripMenuItem,
            this.ticketTypeToolStripMenuItem,
            this.iDTypeToolStripMenuItem1,
            this.serviceChargeToolStripMenuItem});
            this.transactionToolStripMenuItem.Image = global::PawnSystem.UI.Backend.Properties.Resources.Coinstack1;
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.transactionToolStripMenuItem.Text = "Transaction";
            // 
            // itemTypeToolStripMenuItem
            // 
            this.itemTypeToolStripMenuItem.Name = "itemTypeToolStripMenuItem";
            this.itemTypeToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.itemTypeToolStripMenuItem.Text = "Item Type";
            this.itemTypeToolStripMenuItem.Click += new System.EventHandler(this.itemTypeToolStripMenuItem_Click);
            // 
            // auctionDateToolStripMenuItem
            // 
            this.auctionDateToolStripMenuItem.Name = "auctionDateToolStripMenuItem";
            this.auctionDateToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.auctionDateToolStripMenuItem.Text = "Auction Date";
            this.auctionDateToolStripMenuItem.Click += new System.EventHandler(this.auctionDateToolStripMenuItem_Click);
            // 
            // ticketTypeToolStripMenuItem
            // 
            this.ticketTypeToolStripMenuItem.Name = "ticketTypeToolStripMenuItem";
            this.ticketTypeToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.ticketTypeToolStripMenuItem.Text = "Ticket Type";
            this.ticketTypeToolStripMenuItem.Click += new System.EventHandler(this.ticketTypeToolStripMenuItem_Click);
            // 
            // iDTypeToolStripMenuItem1
            // 
            this.iDTypeToolStripMenuItem1.Name = "iDTypeToolStripMenuItem1";
            this.iDTypeToolStripMenuItem1.Size = new System.Drawing.Size(187, 26);
            this.iDTypeToolStripMenuItem1.Text = "Id Type";
            this.iDTypeToolStripMenuItem1.Click += new System.EventHandler(this.iDTypeToolStripMenuItem1_Click);
            // 
            // serviceChargeToolStripMenuItem
            // 
            this.serviceChargeToolStripMenuItem.Name = "serviceChargeToolStripMenuItem";
            this.serviceChargeToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.serviceChargeToolStripMenuItem.Text = "Service Charge";
            this.serviceChargeToolStripMenuItem.Click += new System.EventHandler(this.serviceChargeToolStripMenuItem_Click);
            // 
            // letterToolStripMenuItem
            // 
            this.letterToolStripMenuItem.Name = "letterToolStripMenuItem";
            this.letterToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.letterToolStripMenuItem.Text = "Letter";
            // 
            // envelopeToolStripMenuItem
            // 
            this.envelopeToolStripMenuItem.Name = "envelopeToolStripMenuItem";
            this.envelopeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.envelopeToolStripMenuItem.Text = "Envelope";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1275, 797);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OCB Pawnshop Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripReport;
        private System.Windows.Forms.ToolStripButton toolStripClient;
        private System.Windows.Forms.ToolStripDropDownButton toolStraipConfiguration;
        public System.Windows.Forms.ToolStripLabel labelUsername;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auctionDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDTypeToolStripMenuItem1;
        public System.Windows.Forms.ToolStripButton buttonLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ticketTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outLedgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auctionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penaltyNoticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceChargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem letterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envelopeToolStripMenuItem;
    }
}




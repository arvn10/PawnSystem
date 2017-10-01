namespace PawnSystem.UI.Backend.Forms
{
    partial class formReportNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formReportNotice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateToSend = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonPrintLetter = new System.Windows.Forms.Button();
            this.buttonPrintEnvelope = new System.Windows.Forms.Button();
            this.comboTicketType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.noticeEnvelope1 = new PawnSystem.UI.Backend.Reports.Report.noticeEnvelope();
            this.noticeLetter1 = new PawnSystem.UI.Backend.Reports.Report.noticeLetter();
            this.backgroundWorkerEnvelope = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerMail = new System.ComponentModel.BackgroundWorker();
            this.groupLoading = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.noticeReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.noticeReport1 = new PawnSystem.UI.Backend.Reports.Report.noticeReport();
            this.groupBox1.SuspendLayout();
            this.groupLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dateToSend);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonPrintLetter);
            this.groupBox1.Controls.Add(this.buttonPrintEnvelope);
            this.groupBox1.Controls.Add(this.comboTicketType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 581);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dateToSend
            // 
            this.dateToSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateToSend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateToSend.Location = new System.Drawing.Point(3, 468);
            this.dateToSend.Name = "dateToSend";
            this.dateToSend.Size = new System.Drawing.Size(211, 26);
            this.dateToSend.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "To Send Date :";
            // 
            // buttonPrintLetter
            // 
            this.buttonPrintLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrintLetter.Location = new System.Drawing.Point(3, 538);
            this.buttonPrintLetter.Name = "buttonPrintLetter";
            this.buttonPrintLetter.Size = new System.Drawing.Size(211, 32);
            this.buttonPrintLetter.TabIndex = 12;
            this.buttonPrintLetter.Text = "Print Letter";
            this.buttonPrintLetter.UseVisualStyleBackColor = true;
            this.buttonPrintLetter.Click += new System.EventHandler(this.buttonPrintLetter_Click);
            // 
            // buttonPrintEnvelope
            // 
            this.buttonPrintEnvelope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrintEnvelope.Location = new System.Drawing.Point(3, 500);
            this.buttonPrintEnvelope.Name = "buttonPrintEnvelope";
            this.buttonPrintEnvelope.Size = new System.Drawing.Size(211, 32);
            this.buttonPrintEnvelope.TabIndex = 11;
            this.buttonPrintEnvelope.Text = "Print Envelope";
            this.buttonPrintEnvelope.UseVisualStyleBackColor = true;
            this.buttonPrintEnvelope.Click += new System.EventHandler(this.buttonPrintEnvelope_Click);
            // 
            // comboTicketType
            // 
            this.comboTicketType.FormattingEnabled = true;
            this.comboTicketType.Location = new System.Drawing.Point(6, 143);
            this.comboTicketType.Name = "comboTicketType";
            this.comboTicketType.Size = new System.Drawing.Size(211, 26);
            this.comboTicketType.TabIndex = 10;
            this.comboTicketType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboTicketType_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ticket Type :";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(6, 175);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(211, 32);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(6, 93);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(211, 26);
            this.dateTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date Penalty To :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date Penalty From :";
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(6, 43);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(211, 26);
            this.dateFrom.TabIndex = 0;
            // 
            // backgroundWorkerEnvelope
            // 
            this.backgroundWorkerEnvelope.WorkerReportsProgress = true;
            this.backgroundWorkerEnvelope.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerEnvelope_DoWork);
            this.backgroundWorkerEnvelope.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerEnvelope_ProgressChanged);
            this.backgroundWorkerEnvelope.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerEnvelope_RunWorkerCompleted);
            // 
            // backgroundWorkerMail
            // 
            this.backgroundWorkerMail.WorkerReportsProgress = true;
            this.backgroundWorkerMail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMail_DoWork);
            this.backgroundWorkerMail.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerMail_ProgressChanged);
            this.backgroundWorkerMail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMail_RunWorkerCompleted);
            // 
            // groupLoading
            // 
            this.groupLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupLoading.Controls.Add(this.progressBar);
            this.groupLoading.Controls.Add(this.labelProgress);
            this.groupLoading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupLoading.Location = new System.Drawing.Point(282, 237);
            this.groupLoading.Name = "groupLoading";
            this.groupLoading.Size = new System.Drawing.Size(517, 79);
            this.groupLoading.TabIndex = 6;
            this.groupLoading.TabStop = false;
            this.groupLoading.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(6, 39);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(505, 23);
            this.progressBar.TabIndex = 1;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(3, 18);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(46, 18);
            this.labelProgress.TabIndex = 0;
            this.labelProgress.Text = "label4";
            // 
            // noticeReportViewer
            // 
            this.noticeReportViewer.ActiveViewIndex = -1;
            this.noticeReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noticeReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noticeReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.noticeReportViewer.Location = new System.Drawing.Point(241, 12);
            this.noticeReportViewer.Name = "noticeReportViewer";
            this.noticeReportViewer.Size = new System.Drawing.Size(826, 581);
            this.noticeReportViewer.TabIndex = 7;
            this.noticeReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // formReportNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 605);
            this.Controls.Add(this.groupLoading);
            this.Controls.Add(this.noticeReportViewer);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formReportNotice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Penalty Notice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formReportNoticeEnvelope_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupLoading.ResumeLayout(false);
            this.groupLoading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboTicketType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private Reports.Report.noticeEnvelope noticeEnvelope1;
        private System.Windows.Forms.Button buttonPrintEnvelope;
        private System.Windows.Forms.Button buttonPrintLetter;
        private Reports.Report.noticeLetter noticeLetter1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerEnvelope;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMail;
        private System.Windows.Forms.GroupBox groupLoading;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.DateTimePicker dateToSend;
        private System.Windows.Forms.Label label4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer noticeReportViewer;
        private Reports.Report.noticeReport noticeReport1;
    }
}
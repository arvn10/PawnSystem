using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawnSystem.BLL.Model;
using PawnSystem.BLL.Service;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using System.Globalization;

namespace PawnSystem.UI.Backend.Forms
{
    public partial class formReportNotice : Form
    {
        private ReportService rptService;
        private TicketTypeService ticketTypeService;
        private List<NoticeModel> source;
        public formReportNotice()
        {
            InitializeComponent();
            rptService = new ReportService();
            ticketTypeService = new TicketTypeService();
            source = new List<NoticeModel>();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (comboTicketType.Text.Contains("Select"))
            {
                MessageBox.Show("Select Ticket Type", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                source = rptService.GenerateNoticeMail(Convert.ToInt32(comboTicketType.SelectedValue), dateFrom.Value, dateTo.Value);
                if (source.Count > 0)
                {
                    List<NoticeReportModel> reportSource = new List<NoticeReportModel>();
                    foreach (NoticeModel notice in source)
                    {
                        NoticeReportModel data = new NoticeReportModel();
                        data.ClientName = notice.ClientName;
                        data.ClientAddress = notice.ClientAddress;
                        data.PawnTicketNumber = notice.PawnTicketNumber;
                        data.Principal = notice.Principal;
                        data.dateLoan = notice.dateLoanReport;
                        data.dateExpiry = notice.dateExpiryReport;
                        data.dateAuction = notice.dateAuctionReport;
                        reportSource.Add(data);
                    }
                    noticeReport1.SetDataSource(reportSource);
                    noticeReportViewer.ReportSource = noticeReport1;
                }
                else
                {
                    MessageBox.Show("No Record(s) Found", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void noticeLetter1_InitReport(object sender, EventArgs e)
        {

        }

        private void formReportNoticeEnvelope_Load(object sender, EventArgs e)
        {
            List<TicketTypeModel> ticketTypes = ticketTypeService.Get().ToList();

            ticketTypes.Insert(0, new TicketTypeModel()
            {
                ID = 0,
                Type = "All"
            });

            comboTicketType.DisplayMember = "Type";
            comboTicketType.ValueMember = "ID";
            comboTicketType.DataSource = ticketTypes;
            comboTicketType.Text = "Select Ticket Type";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void buttonPrintEnvelope_Click(object sender, EventArgs e)
        {
            if(source.Count > 0)
            {
                progressBar.Maximum = source.Count;
                dateFrom.Enabled = false;
                dateTo.Enabled = false;
                comboTicketType.Enabled = false;
                buttonSearch.Enabled = false;
                buttonPrintEnvelope.Enabled = false;
                buttonPrintLetter.Enabled = false;
                groupLoading.Visible = true;
                backgroundWorkerEnvelope.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("No Record(s) Found", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonPrintLetter_Click(object sender, EventArgs e)
        {
            if (source.Count > 0)
            {
                progressBar.Maximum = source.Count;
                dateFrom.Enabled = false;
                dateTo.Enabled = false;
                comboTicketType.Enabled = false;
                buttonSearch.Enabled = false;
                buttonPrintEnvelope.Enabled = false;
                buttonPrintLetter.Enabled = false;
                groupLoading.Visible = true;
                backgroundWorkerMail.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("No Record(s) Found", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboTicketType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void backgroundWorkerEnvelope_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 1;
            foreach (NoticeModel notice in source)
            {
                backgroundWorkerEnvelope.ReportProgress(count);
                PrinterSettings printerSetting = new PrinterSettings();
                noticeEnvelope1.SetParameterValue("clientName", notice.ClientName);
                noticeEnvelope1.SetParameterValue("clientAddress", notice.ClientAddress);
                noticeEnvelope1.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                noticeEnvelope1.PrintOptions.PrinterName = printerSetting.PrinterName;
                noticeEnvelope1.PrintToPrinter(1, false, 0, 0);
                count++;
            }
        }

        private void backgroundWorkerEnvelope_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgress.Text = "Printing " + e.ProgressPercentage.ToString() + " out of " + source.Count.ToString() + " item(s).";
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerEnvelope_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Printing complete", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dateFrom.Enabled = true;
            dateTo.Enabled = true;
            comboTicketType.Enabled = true;
            buttonSearch.Enabled = true;
            buttonPrintEnvelope.Enabled = true;
            buttonPrintLetter.Enabled = true;
            groupLoading.Visible = false;
            backgroundWorkerEnvelope.Dispose();
        }

        private void backgroundWorkerMail_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 1;
            backgroundWorkerMail.ReportProgress(count);
            foreach (NoticeModel notice in source)
            {
                PrinterSettings printerSetting = new PrinterSettings();
                noticeLetter1.SetParameterValue("monthDay", string.Format("{0:m}", dateToSend.Value));
                noticeLetter1.SetParameterValue("year", string.Format("{0:yy}", dateToSend.Value));
                noticeLetter1.SetParameterValue("clientName", notice.ClientName);
                noticeLetter1.SetParameterValue("clientAddress", notice.ClientAddress);
                noticeLetter1.SetParameterValue("pawnTicketNumber", notice.PawnTicketNumber);
                noticeLetter1.SetParameterValue("principal", notice.Principal);
                noticeLetter1.SetParameterValue("principalWords", notice.PrincipalText);
                noticeLetter1.SetParameterValue("auctionDate", notice.dateAuctionWord);
                noticeLetter1.SetParameterValue("expiryDate", notice.dateExpiry);
                noticeLetter1.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                noticeLetter1.PrintOptions.PrinterName = printerSetting.PrinterName;
                noticeLetter1.PrintToPrinter(1, false, 0, 0);
                count++;
            }
        }

        private void backgroundWorkerMail_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgress.Text = "Printing " + e.ProgressPercentage.ToString() + " out of " + source.Count.ToString() + " item(s).";
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerMail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Printing complete", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dateFrom.Enabled = true;
            dateTo.Enabled = true;
            comboTicketType.Enabled = true;
            buttonSearch.Enabled = true;
            buttonPrintEnvelope.Enabled = true;
            buttonPrintLetter.Enabled = true;
            groupLoading.Visible = false;
            backgroundWorkerMail.Dispose();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            if (source.Count > 0)
            {
                progressBar.Maximum = source.Count;
                dateFrom.Enabled = false;
                dateTo.Enabled = false;
                comboTicketType.Enabled = false;
                buttonSearch.Enabled = false;
                buttonPrintEnvelope.Enabled = false;
                buttonPrintLetter.Enabled = false;
                groupLoading.Visible = true;
                backgroundWorkerEnvelope.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("No Record(s) Found", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

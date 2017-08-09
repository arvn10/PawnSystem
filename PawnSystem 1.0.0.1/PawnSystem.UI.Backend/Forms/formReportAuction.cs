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

namespace PawnSystem.UI.Backend.Forms
{
    public partial class formReportAuction : Form
    {
        private AuctionDateService auctionDateService;
        private ReportService reportService;
        public formReportAuction()
        {
            InitializeComponent();
        }

        private void formReportAuction_Load(object sender, EventArgs e)
        {
            auctionDateService = new AuctionDateService();
            List<AuctionDateModel> auctionDates = auctionDateService.Get().OrderByDescending(x=>x.Date).ToList();
            comboAuctionDate.DisplayMember = "Date";
            comboAuctionDate.ValueMember = "ID";
            comboAuctionDate.DataSource = auctionDates;
            comboAuctionDate.Text = "--Select Auction Date--";
            
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            reportService = new ReportService();
            int auctionDateID = Convert.ToInt32(comboAuctionDate.SelectedValue);
            AuctionDateModel auctionDate = auctionDateService.Get().Where(x => x.ID == auctionDateID).FirstOrDefault();
            List<AuctionModel> source = reportService.GenerateAuctionReport(auctionDate);

            if(source.Count > 0)
            {

                auctionReport.SetDataSource(source);
                auctionReport.SetParameterValue("auctionDate", "Auction Report [" + comboAuctionDate.Text + "]");
                auctionReportViewer.ReportSource = auctionReport;
                auctionReportViewer.Refresh();
            }
            else
            {
                MessageBox.Show("No Records Found", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void auctionReport1_InitReport(object sender, EventArgs e)
        {

        }
    }
}

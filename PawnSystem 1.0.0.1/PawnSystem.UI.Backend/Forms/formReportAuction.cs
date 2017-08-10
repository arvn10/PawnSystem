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
        private TicketTypeService ticketTypeService;
        private ReportService reportService;
        public formReportAuction()
        {
            InitializeComponent();
            auctionDateService = new AuctionDateService();
            reportService = new ReportService();
            ticketTypeService = new TicketTypeService();
        }

        private void formReportAuction_Load(object sender, EventArgs e)
        {

            List<AuctionDateModel> auctionDates = auctionDateService.Get().OrderByDescending(x => x.Date).ToList();
            comboAuctionDate.DisplayMember = "Date";
            comboAuctionDate.ValueMember = "ID";
            comboAuctionDate.DataSource = auctionDates;
            comboAuctionDate.Text = "--Select Auction Date--";

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

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

            int auctionDateID = Convert.ToInt32(comboAuctionDate.SelectedValue);
            AuctionDateModel auctionDate = auctionDateService.Get().Where(x => x.ID == auctionDateID).FirstOrDefault();
            List<AuctionModel> source = reportService.GenerateAuctionReport(Convert.ToInt32(comboTicketType.SelectedValue), auctionDate);

            if (source.Count > 0)
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

        private void comboTicketType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

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
    public partial class formReportOutLedger : Form
    {
        private ReportService reportService;
        private TicketTypeService ticketTypeService;
        public formReportOutLedger()
        {
            reportService = new ReportService();
            ticketTypeService = new TicketTypeService();
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (comboTicketType.Text.Contains("Select"))
            {
                MessageBox.Show("Select Item Type First", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<OutLedgerModel> source = reportService.GenerateOutLedger(Convert.ToInt32(comboTicketType.SelectedValue), dateFrom.Value, dateTo.Value);
                if (source.Count > 0)
                {
                    outLedgerReport.SetDataSource(source);
                    outLedgerReportViewer.ReportSource = outLedgerReport;
                    outLedgerReportViewer.Refresh();
                }
                else
                {
                    MessageBox.Show("No Records Found", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void formReportOutLedger_Load(object sender, EventArgs e)
        {
            dateFrom.Value = dateTo.Value.AddDays(-1);
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

        private void comboTicketType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

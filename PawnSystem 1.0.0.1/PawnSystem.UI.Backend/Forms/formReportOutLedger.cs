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

        public formReportOutLedger()
        {
            reportService = new ReportService();
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            List<OutLedgerModel> source = reportService.GenerateOutLedger(dateFrom.Value, dateTo.Value);
            if(source.Count > 0)
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

        private void formReportOutLedger_Load(object sender, EventArgs e)
        {
            dateFrom.Value = dateTo.Value.AddDays(-1);
        }
    }
}

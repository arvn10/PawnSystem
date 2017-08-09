using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawnSystem.BLL.Service;
using PawnSystem.BLL.Model;
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formReportTransaction : Form
    {
        private TicketTypeService sticketType;

        public formReportTransaction()
        {
            InitializeComponent();
            sticketType = new TicketTypeService();
        }

        private void comboTicketType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void formReportTransaction_Load(object sender, EventArgs e)
        {
            List<TicketTypeModel> ticketTypes = sticketType.Get().ToList();
            ticketTypes.Insert(0, new TicketTypeModel { ID = 0, Type = "All" });
            comboTicketType.DisplayMember = "Type";
            comboTicketType.ValueMember = "ID";
            comboTicketType.DataSource = ticketTypes;
            comboTicketType.Text = "-Select Ticket Type-";

            dateFrom.Value = dateFrom.Value.AddDays(-1);
            dateTo.Value = dateFrom.Value.AddDays(1);
        }

        private void comboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

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
    public partial class formTicketType : Form
    {
        private TicketTypeService service;
        public UserModel activeUser;

        public formTicketType()
        {
            InitializeComponent();
            service = new TicketTypeService();
        }

        public void loadData(string searchValue = null)
        {
            service = new TicketTypeService();
            List<TicketTypeModel> data = new List<TicketTypeModel>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                data = service.Get().ToList();
            }
            else
            {
                data = service.Get().Where(x => x.Type.Contains(searchValue)).ToList();
            }

            bs.DataSource = data;

            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = bs;

            dataGrid.Columns[0].DataPropertyName = "ID";
            dataGrid.Columns[1].DataPropertyName = "Type";

            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void formTicketType_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text == string.Empty)
            {
                loadData();
            }
            else
            {
                loadData(textSearch.Text);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formTicketTypeProcess form = new formTicketTypeProcess();
            form.activeUser = activeUser;
            form.processType = "New";
            form.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(dataGrid.Rows.Count> 0)
            {
                formTicketTypeProcess form = new formTicketTypeProcess();
                form.activeUser = activeUser;
                form.ticketTypeID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.processType = "Edit";
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Item(s) to Edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class formAuctionDate : Form
    {
        private AuctionDateService service;
        public UserModel activeUser;

        public formAuctionDate()
        {
            InitializeComponent();
        }

        public void loadData(DateTime? searchValue)
        {
            service = new AuctionDateService();
            List<AuctionDateModel> data = new List<AuctionDateModel>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                data = service.Get().ToList<AuctionDateModel>();
            }
            else
            {
                data = service.Get().AsQueryable<AuctionDateModel>()
                                    .Where(x => x.Date == searchValue ||
                                                x.ItemFrom == searchValue ||
                                                x.ItemTo == searchValue).ToList<AuctionDateModel>();
            }

            bs.DataSource = data;

            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = bs;

            dataGrid.Columns[0].DataPropertyName = "ID";
            dataGrid.Columns[1].DataPropertyName = "Date";
            dataGrid.Columns[2].DataPropertyName = "ItemFrom";
            dataGrid.Columns[3].DataPropertyName = "ItemTo";

            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formAuctionDateProcess form = new formAuctionDateProcess();
            form.processType = "New";
            form.activeUser = activeUser;
            form.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                formAuctionDateProcess form = new formAuctionDateProcess();
                form.processType = "Edit";
                form.activeUser = activeUser;
                form.auctionDateID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Item(s) to Edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void formAuctionDate_Load(object sender, EventArgs e)
        {
            loadData(null);
        }

        private void dateTimeSearch_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimeSearch.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                loadData(null);
            }
            else
            {
                loadData(Convert.ToDateTime(dateTimeSearch.Text));
            }

        }
    }
}

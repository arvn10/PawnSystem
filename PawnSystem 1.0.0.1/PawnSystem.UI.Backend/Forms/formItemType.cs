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
    public partial class formItemType : Form
    {
        private ItemTypeService service;
        public UserModel activeUser;

        public formItemType()
        {
            InitializeComponent();
        }

        public void loadData(string searchValue = null)
        {
            service = new ItemTypeService();
            List<ItemTypeModel> data = new List<ItemTypeModel>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                
                data = service.Get().ToList<ItemTypeModel>();
            }
            else
            {
                data = service.Get().Where(x => x.Description.Contains(searchValue)).ToList<ItemTypeModel>();
            }

            bs.DataSource = data;

            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = bs;
            
            dataGrid.Columns[0].DataPropertyName = "ID";
            dataGrid.Columns[1].DataPropertyName = "Description";
            dataGrid.Columns[2].DataPropertyName = "Interest";
            dataGrid.Columns[3].DataPropertyName = "Penalty";
            dataGrid.Columns[4].DataPropertyName = "AppraiseValue";
            dataGrid.Columns[5].DataPropertyName = "WithServiceCharge";
            dataGrid.Columns[6].DataPropertyName = "DaysToMature";
            dataGrid.Columns[7].DataPropertyName = "DaysToExpire";
            dataGrid.Columns[8].DataPropertyName = "DaysToPenalty";

            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if(textSearch.Text == string.Empty)
            {
                loadData();
            }
            else
            {
                loadData(textSearch.Text);
            }
        }

        private void formItemType_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formItemTypeProcess form = new formItemTypeProcess();
            form.activeUser = activeUser;
            form.processType = "New";
            form.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                formItemTypeProcess form = new formItemTypeProcess();
                form.activeUser = activeUser;
                form.processType = "Edit";
                form.itemTypeID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Item(s) to Edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

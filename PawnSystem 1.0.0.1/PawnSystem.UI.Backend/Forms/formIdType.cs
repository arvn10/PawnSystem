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
    public partial class formIdType : Form
    {

        private IdTypeService service;
        public UserModel activeUser;

        public formIdType()
        {
            InitializeComponent();
        }

        public void loadData(string searchValue = null)
        {
            service = new IdTypeService();
            List<IdTypeModel> data = new List<IdTypeModel>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                data = service.Get().ToList<IdTypeModel>();
            }
            else
            {
                data = service.Get().Where(x => x.Type.Contains(searchValue)).ToList<IdTypeModel>();
            }

            bs.DataSource = data;

            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = bs;

            dataGrid.Columns[0].DataPropertyName = "ID";
            dataGrid.Columns[1].DataPropertyName = "Type";

            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void buttonNew_Click(object sender, EventArgs e)
        {
            formIdTypeProcess form = new formIdTypeProcess();
            form.processType = "New";
            form.activeUser = activeUser;
            form.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                formIdTypeProcess form = new formIdTypeProcess();
                form.processType = "Edit";
                form.idTypeID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.activeUser = activeUser;
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

        private void formIdType_Load(object sender, EventArgs e)
        {
            loadData();
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
    }
}

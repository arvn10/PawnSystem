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
    public partial class formUserType : Form
    {
        private UserTypeModel model;
        private UserTypeService service;

        public UserModel activeUser;
        public formUserType()
        {
            InitializeComponent();
        }

        public void loadData(string searchValue = null)
        {
            service = new UserTypeService();
            List<UserTypeModel> data = new List<UserTypeModel>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                data = service.Get().ToList<UserTypeModel>();
            }
            else
            {
                data = service.Get().AsQueryable<UserTypeModel>()
                                    .Where(x => x.Type.Contains(searchValue)).ToList<UserTypeModel>();
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
            formUserTypeProcess form = new formUserTypeProcess();
            form.Text = "New";
            form.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                model = new UserTypeModel();
                model.ID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                model.Type = Convert.ToString(dataGrid.CurrentRow.Cells[1].Value);
                if (model != null)
                {
                    formUserTypeProcess form = new formUserTypeProcess();
                    form.Text = "Edit";
                    form.model = model;
                    form.activeUser = activeUser;
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Select User Type First", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Item(s) to edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void formUserType_Load(object sender, EventArgs e)
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

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Text = string.Empty;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

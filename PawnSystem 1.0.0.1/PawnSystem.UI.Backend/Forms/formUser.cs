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
    public partial class formUser : Form
    {
        private UserService service;    
        public UserModel activeUser;

        public formUser()
        {
            InitializeComponent();
        }

        public void loadData(string searchValue = null)
        {
            service = new UserService();
            List<UserModel> data = new List<UserModel>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                data = service.Get().ToList<UserModel>();
            }
            else
            {
                data = service.Get().AsQueryable<UserModel>()
                                    .Where(x => x.UserName.Contains(searchValue) ||
                                                x.FirstName.Contains(searchValue) ||
                                                x.LastName.Contains(searchValue)).ToList<UserModel>();
            }

            bs.DataSource = data;

            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = bs;

            dataGrid.Columns[0].DataPropertyName = "ID";
            dataGrid.Columns[1].DataPropertyName = "FirstName";
            dataGrid.Columns[2].DataPropertyName = "LastName";
            dataGrid.Columns[3].DataPropertyName = "UserName";
            dataGrid.Columns[4].DataPropertyName = "UserType";
            dataGrid.Columns[5].DataPropertyName = "Status";

            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formUserProcess form = new formUserProcess();
            form.activeUser = activeUser;
            form.processType = "New";
            form.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                formUserProcess form = new formUserProcess();
                form.processType = "Edit";
                form.userID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.activeUser = activeUser;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Item(s) to edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

        private void formIcon_Click(object sender, EventArgs e)
        {

        }
    }
}

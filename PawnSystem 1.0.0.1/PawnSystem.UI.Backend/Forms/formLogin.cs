using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

using PawnSystem.BLL.Service;
using PawnSystem.BLL.Model;

namespace PawnSystem.UI.Backend.Forms
{
    public partial class formLogin : Form
    {
        private UserService service;
        private UserModel model;
        private bool successConnection = false;
        private void connectDB()
        {

        }

        public formMain formMain { get; set; }
        public formLogin()
        {
            InitializeComponent();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            formSettings form = new formSettings();
            form.ShowDialog();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            model = new UserModel();
            service = new UserService();
            model = service.Login(textUsername.Text, textPassword.Text);
            if(model != null)
            {
                if(model.Status == "Not Active")
                {
                    MessageBox.Show("Account is not Active", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (model.UserType == "Administrator")
                    {
                        this.Close();
                        formMain form = (formMain)Application.OpenForms["formMain"];
                        form.activeUser = model;

                        form.toolStrip.Enabled = true;
                        form.labelUsername.Visible = true;
                        form.buttonLogout.Visible = true;
                        form.labelUsername.Text = "Logged on User : " + model.FirstName + " " + model.LastName;
                    }
                    else
                    {
                        MessageBox.Show("Administrator level are only allowed to access this tool", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Username or Password is Incorrect", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void formLogin_Activated(object sender, EventArgs e)
        {
            buttonLogin.Text = "Checking Database Connection";
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PawnSystem.Connection"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    e.Result = true;
                }
            }
            catch
            {
                e.Result = false;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == true)
            {
                TransactionService tService = new TransactionService();
                tService.UpdateTransactionStatus();
                buttonLogin.Text = "Login";
                buttonLogin.Enabled = true;
                this.AcceptButton = buttonLogin;
            }
            else
            {
                MessageBox.Show("Connection to database failed. Kindly check your database connection", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonLogin.Enabled = false;
                formSettings form = new formSettings();
                form.ShowDialog();
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PawnSystem.Connection"].ConnectionString;
            string[] parts = connectionString.Split(';');
            foreach (string part in parts)
            {
                if (part != string.Empty)
                {
                    string[] str = part.Split('=');
                    if (str[0] == "Data Source")
                    {
                        textServer.Text = str[1];
                    }
                    else if (str[0] == "Initial Catalog")
                    {
                        textDatabase.Text = str[1];
                    }
                    else if (str[0] == "User ID")
                    {
                        textUsername.Text = str[1];
                    }
                    else if (str[0] == "Password")
                    {
                        textPassword.Text = str[1];
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool invalidInputs = false;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        invalidInputs = true;
                    }
                }
            }

            if (!invalidInputs)
            {
                try
                {
                    string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString();
                    if (messageBox == "Yes")
                    {
                        string connectionString = string.Empty;

                        connectionString = "Data Source=" + textServer.Text + ";Initial Catalog=" + textDatabase.Text + ";User ID=" + textUsername.Text + ";Password=" + textPassword.Text + ";";

                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                        var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                        connectionStringsSection.ConnectionStrings["PawnSystem.Connection"].ConnectionString = connectionString;

                        config.Save();

                        ConfigurationManager.RefreshSection("connectionStrings");

                        MessageBox.Show("Database Settings Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Dispose();
                        formLogin form = (formLogin)Application.OpenForms["formLogin"];
                        form.buttonLogin.Enabled = false;
                        form.backgroundWorker.RunWorkerAsync();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fillup required field(s)", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            string connectionString = string.Empty;
            connectionString = "Data Source=" + textServer.Text + ";Initial Catalog=" + textDatabase.Text + ";User ID=" + textUsername.Text + ";Password=" + textPassword.Text + ";";
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Test Connection Succeed", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}

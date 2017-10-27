using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace PawnSystem.UI.Backend.Forms
{
    public partial class formBackupDatabase : Form
    {
        public formBackupDatabase()
        {
            InitializeComponent();
        }

        private void buttonOpenSaveLocation_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textPath.Text = folderBrowserDialog.SelectedPath + @"\PawnSystem " + DateTime.Now.ToString("yyyy-MM-dd hh.mm.ss") + ".bak";
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            try
            {
                string dataSource = string.Empty;
                string database = string.Empty;
                string username = string.Empty;
                string password = string.Empty;

                string connectionString = ConfigurationManager.ConnectionStrings["PawnSystem.Connection"].ConnectionString;
                string[] parts = connectionString.Split(';');
                foreach (string part in parts)
                {
                    if (part != string.Empty)
                    {
                        string[] str = part.Split('=');
                        if (str[0] == "Data Source")
                        {
                            dataSource = str[1];
                        }
                        else if (str[0] == "Initial Catalog")
                        {
                            database = str[1];
                        }
                        else if (str[0] == "User ID")
                        {
                            username = str[1];
                        }
                        else if (str[0] == "Password")
                        {
                            password = str[1];
                        }
                    }
                }
                MessageBox.Show(dataSource);
                Server databaseServer = new Server(new ServerConnection(dataSource, username, password));
                Backup databaseBackup = new Backup() { Action = BackupActionType.Database, Database = database };
                databaseBackup.Devices.AddDevice(textPath.Text, DeviceType.File);
                databaseBackup.Initialize = true;
                databaseBackup.PercentComplete += DatabaseBackup_PercentComplete;
                databaseBackup.Complete += DatabaseBackup_Complete;
                databaseBackup.SqlBackupAsync(databaseServer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatabaseBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                labelStatus.Invoke((MethodInvoker)delegate
                {
                    labelStatus.Text = e.Error.Message;
                });
            }
        }

        private void DatabaseBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar.Invoke((MethodInvoker)delegate
            {
                progressBar.Value = e.Percent;
                progressBar.Update();
            });
            labelPercent.Invoke((MethodInvoker)delegate
            {
                labelPercent.Text = $"{e.Percent}%";
            });
        }

        private void formBackupDatabase_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}

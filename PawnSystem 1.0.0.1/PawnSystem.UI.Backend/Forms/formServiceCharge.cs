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
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formServiceCharge : Form
    {
        public formServiceCharge()
        {
            InitializeComponent();
        }

        private void formServiceCharge_Load(object sender, EventArgs e)
        {
            textToCheckAmount.Text = ConfigurationManager.AppSettings["ServiceChargeHigh"].ToString();
            textHigherAmount.Text = ConfigurationManager.AppSettings["ServiceChargeHighAmount"].ToString();
            textLowerAmount.Text = ConfigurationManager.AppSettings["ServiceChargeLowAmount"].ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ServiceChargeHigh"].Value = textToCheckAmount.Text;
                config.AppSettings.Settings["ServiceChargeHighAmount"].Value = textHigherAmount.Text;
                config.AppSettings.Settings["ServiceChargeLowAmount"].Value = textLowerAmount.Text;
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Service Charge Setting Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void textToCheckAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textHigherAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textLowerAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

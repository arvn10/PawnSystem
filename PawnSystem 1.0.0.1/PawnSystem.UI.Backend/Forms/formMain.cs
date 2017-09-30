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
    public partial class formMain : Form
    {
        public UserModel activeUser = new UserModel();
        private void CloseAllForms(Form ParForm)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            toolStrip.Enabled = false;

            formLogin form = new formLogin();
            form.formMain = this;
            form.MdiParent = this;
            form.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formUser form = new formUser();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void userTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formUserType form = new formUserType();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void auctionDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formAuctionDate form = new formAuctionDate();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            string messagebox = MessageBox.Show("Logout your Account?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if(messagebox == "Yes")
            {
                CloseAllForms(this);
                toolStrip.Enabled = false;
                labelUsername.Visible = false;
                buttonLogout.Visible = false;
                formLogin form = new formLogin();
                form.MdiParent = this;
                form.Show();
            }

        }

        private void iDTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formIdType form = new formIdType();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void toolStripClient_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formClient form = new formClient();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void itemTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formItemType form = new formItemType();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void ticketTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formTicketType form = new formTicketType();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void toolStripMenuUser_Click(object sender, EventArgs e)
        {

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formUser form = new formUser();
            form.MdiParent = this;
            form.activeUser = activeUser;
            form.Show();
        }

        private void auctionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formReportAuction form = new formReportAuction();
            form.MdiParent = this;
            form.Show();
        }

        private void serviceChargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formServiceCharge form = new formServiceCharge();
            form.MdiParent = this;
            form.Show();
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Exit Application?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;   
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void outLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formReportOutLedger form = new formReportOutLedger();
            form.MdiParent = this;
            form.Show();
        }

        private void inLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formReportInLedger form = new formReportInLedger();
            form.MdiParent = this;
            form.Show();
        }

        private void envelopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formReportNotice form = new formReportNotice();
            form.MdiParent = this;
            form.Show();
        }

        private void penaltyNoticeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseAllForms(this);
            formReportNotice form = new formReportNotice();
            form.MdiParent = this;
            form.Show();
        }
    }
}

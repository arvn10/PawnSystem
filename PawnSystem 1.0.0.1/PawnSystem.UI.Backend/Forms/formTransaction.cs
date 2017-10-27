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
    public partial class formTransaction : Form
    {
        public formTransaction()
        {
            InitializeComponent();
        }

        public int clientID;
        public UserModel activeUser;

        private TransactionService transactionService;
        private ClientService clientService;
        private ClientModel clientModel;


        public void loadData(string searchValue = null)
        {
            transactionService = new TransactionService();
            List<TransactionView> data = new List<TransactionView>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                data = transactionService.Get().Where(x => x.ClientID == clientID).AsQueryable()
                                                              .OrderByDescending(x => x.DateLoan)
                                                              .ToList();
            }
            else
            {
                data = transactionService.Get().Where(x => x.ClientID == clientID &&
                                                                          x.PawnTicketNumber.Contains(searchValue))
                                                              .OrderByDescending(x => x.DateLoan)
                                                              .ToList();
            }

            bs.DataSource = data;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = bs;

            dataGrid.Columns[0].DataPropertyName = "ID";
            dataGrid.Columns[1].DataPropertyName = "Status";
            dataGrid.Columns[2].DataPropertyName = "PawnTicketNumber";
            dataGrid.Columns[3].DataPropertyName = "TransactionType";
            dataGrid.Columns[4].DataPropertyName = "Principal";
            dataGrid.Columns[5].DataPropertyName = "NetProceed";
            dataGrid.Columns[6].DataPropertyName = "DateLoan";
            dataGrid.Columns[7].DataPropertyName = "DateMaturity";
            dataGrid.Columns[8].DataPropertyName = "DateExpiry";
            dataGrid.Columns[9].DataPropertyName = "AuctionDate";
            dataGrid.Columns[10].DataPropertyName = "ProcessBy";
            dataGrid.Columns[11].DataPropertyName = "ProcessDate";

            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formTransaction_Load(object sender, EventArgs e)
        {

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            clientService = new ClientService();
            clientModel = new ClientModel();
            clientModel = clientService.Get().Where(x => x.ID == clientID).FirstOrDefault();
            this.Text = "Transaction(s) - " + clientModel.FirstName + " " + clientModel.LastName;
            loadData();
            textSearch.Focus();
        }

        private void buttonPawn_Click(object sender, EventArgs e)
        {
            formTransactionProcess form = new formTransactionProcess();
            form.activeUser = activeUser;
            form.processType = "Pawn";
            form.clientID = clientID;
            form.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                if (dataGrid.CurrentRow.Cells[1].Value.ToString() != "Closed")
                {
                    formTransactionProcess form = new formTransactionProcess();
                    form.activeUser = activeUser;
                    form.processType = "Edit";
                    form.clientID = clientID;
                    form.transactionID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Cannot Edit Closed Transaction", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Transaction(s) to Edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void buttonRedeem_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                if (dataGrid.CurrentRow.Cells[1].Value.ToString() != "Closed")
                {
                    formTransactionProcess form = new formTransactionProcess();
                    form.activeUser = activeUser;
                    form.processType = "Redeem";
                    form.clientID = clientID;
                    form.transactionID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Cannot Redeem Closed Transaction", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No Transaction(s) to Redeem", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRenew_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                if (dataGrid.CurrentRow.Cells[1].Value.ToString() != "Closed")
                {
                    formTransactionProcess form = new formTransactionProcess();
                    form.activeUser = activeUser;
                    form.processType = "Renew";
                    form.clientID = clientID;
                    form.transactionID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Cannot Renew Closed Transaction", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Transaction(s) to Renew", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            loadData(textSearch.Text);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D1))
            {
                buttonPawn.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D2))
            {
                buttonRenew.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D3))
            {
                buttonRedeem.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D4))
            {
                buttonEdit.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D5))
            {
                buttonView.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                textSearch.Focus();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                this.Dispose();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                formTransactionProcess form = new formTransactionProcess();
                form.formTransaction = this;
                form.activeUser = activeUser;
                form.processType = "View";
                form.clientID = clientID;
                form.transactionID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Transaction(s) to View", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

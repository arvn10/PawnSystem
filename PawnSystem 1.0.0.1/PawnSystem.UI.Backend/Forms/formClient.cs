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
    public partial class formClient : Form
    {
        private ClientService service;
        private TransactionService stransaction;
        private TransactionItemService stransactionItem;
        public UserModel activeUser;
        public string type ;
        public Int32 transactionID;
        public string pawnTicketNumber;
        public formClient()
        {
            InitializeComponent();
            service = new ClientService();
            stransaction = new TransactionService();
            stransactionItem = new TransactionItemService();
        }

        public void loadData(string searchValue = null)
        {
            
            List<ClientModel> data = new List<ClientModel>();
            BindingSource bs = new BindingSource();

            if (searchValue == null)
            {
                data = service.Get().AsQueryable()
                                    .OrderBy(x => x.LastName)
                                    .Take(100)
                                    .ToList();
            }
            else
            {
                data = service.Get().AsQueryable()
                                    .Where(x => x.LastName.Contains(searchValue) ||
                                                              x.FirstName.Contains(searchValue) ||
                                                              x.Address.Contains(searchValue))
                                    .OrderBy(x => x.LastName)
                                    .Take(100)
                                    .ToList();
            }
            bs.DataSource = data;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = bs;

            dataGrid.Columns[0].DataPropertyName = "ID";
            dataGrid.Columns[1].DataPropertyName = "LastName";
            dataGrid.Columns[2].DataPropertyName = "FirstName";
            dataGrid.Columns[3].DataPropertyName = "Address";
            dataGrid.Columns[4].DataPropertyName = "ContactNumber";

            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formClient_Load(object sender, EventArgs e)
        {
            if (type == "transfer")
            {
                toolStripButtonSelect.Visible = true;
            }
            else
            {
                buttonNew.Visible = true;
                buttonEdit.Visible = true;
                buttonDelete.Visible = true;
                toolStripButtonTransactionProfile.Visible = true;
            }
            textSearch.Focus();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formClientProcess form = new formClientProcess();
            form.processType = "New";
            form.activeUser = activeUser;
            form.ShowDialog();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if(textSearch.Text == string.Empty)
            {
                dataGrid.DataSource = null;
            }
            else
            {

                loadData(textSearch.Text);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                formClientProcess form = new formClientProcess();
                form.processType = "Edit";
                form.activeUser = activeUser;
                form.clientID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Client Profile to Edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButtonTransactionProfile_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                formTransaction form = new formTransaction();
                form.MdiParent = this.MdiParent;
                form.activeUser = activeUser;
                form.clientID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                form.Show();
            }
            else
            {
                MessageBox.Show("No Transaction Profile to Edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to Delete " + dataGrid.CurrentRow.Cells[2].Value.ToString() + " " + dataGrid.CurrentRow.Cells[1].Value.ToString() + "'s Profile and All of its Transaction(s)?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int clientID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value);
                    ClientModel client = service.Get().Where(x => x.ID == clientID).FirstOrDefault();

                    List<TransactionView> transactions = stransaction.Get().Where(x => x.ClientID == clientID).ToList();
                    if (transactions.Count > 0)
                    {
                        foreach (TransactionView transaction in transactions)
                        {
                            List<TransactionItemModel> items = stransactionItem.Get().Where(x => x.TransactionID == transaction.ID).ToList();
                            foreach (TransactionItemModel item in items)
                            {
                                stransactionItem.Delete(item);
                            }
                            stransaction.Delete(transaction.ID);
                        }
                    }
                    if (service.Delete(client))
                    {
                        MessageBox.Show("Client Profile Deleted", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData(textSearch.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Client Profile to Delete", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D1))
            {
                buttonNew.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D2))
            {
                buttonEdit.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D3))
            {
                buttonDelete.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D4))
            {
                toolStripButtonTransactionProfile.PerformClick();
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

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to transfer Pawn Ticket Number " + pawnTicketNumber + " to " + dataGrid.CurrentRow.Cells[1].Value + " " + dataGrid.CurrentRow.Cells[2].Value + "?","Pawnshop Management System",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes) {
                    TransactionView data = stransaction.Get().Where(x => x.ID == transactionID).FirstOrDefault();
                    if(stransaction.Update(new TransactionCreateEdit()
                    {
                        ID = transactionID,
                        ClientID = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value),
                        ItemTypeID = data.ItemTypeID,
                        AuctionDateID = data.AuctionDateID,
                        TicketTypeID = data.TicketTypeID,
                        IdTypeID = data.IdTypeID,
                        OldTransactionID = data.OldID,
                        PawnTicketNumber = data.PawnTicketNumber,
                        TransactionType = data.TransactionType,
                        DateLoan = data.DateLoan,
                        DateMaturity = data.DateMaturity,
                        DateExpiry = data.DateExpiry,
                        DatePenalty = data.DatePenalty,
                        Principal = data.Principal,
                        Interest = data.Interest,
                        ServiceCharge = data.ServiceCharge,
                        Penalty = data.Penalty,
                        AppraiseValue = data.AppraiseValue,
                        NetProceed = data.NetProceed,
                        Status = data.Status,
                        DateClosed = data.DateClosed,
                        ModifiedBy = activeUser.FirstName + " " + activeUser.LastName
                    }) != null)
                    {
                        
                        MessageBox.Show("Transaction Transferrred", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        formMain formMain = new formMain();
                        formMain.CloseAllForms(formMain);
                        this.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Client Profile to Select", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

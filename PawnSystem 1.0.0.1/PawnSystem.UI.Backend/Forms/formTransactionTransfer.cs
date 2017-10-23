using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PawnSystem.BLL.Service;
using PawnSystem.BLL.Model;
using System.Globalization;
using System.Drawing.Printing;
using CrystalDecisions.Shared;
using PawnSystem.Helper;

namespace PawnSystem.UI.Backend.Forms
{
    public partial class formTransactionTransfer : Form
    {
        private TransactionService transactionService;
        
        public int transactionID; 
        public formTransactionTransfer()
        {
            InitializeComponent();
            transactionService = new TransactionService();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            formClient form = new formClient();
            form.type = "transfer";
            form.ShowDialog();
        }

        private void formTransactionTransfer_Load(object sender, EventArgs e)
        {
            TransactionView transactionView = transactionService.Get().Where(x => x.ID == transactionID).FirstOrDefault();
            this.Text = "Transfer Pawn Ticket Number " + transactionView.PawnTicketNumber;
        }
    }
}

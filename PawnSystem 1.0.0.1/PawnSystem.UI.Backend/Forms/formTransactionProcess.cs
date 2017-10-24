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

using PawnSystem.BLL.Service;
using PawnSystem.BLL.Model;
using System.Globalization;
using System.Drawing.Printing;
using CrystalDecisions.Shared;
using PawnSystem.Helper;
namespace PawnSystem.UI.Backend.Forms
{
    public partial class formTransactionProcess : Form
    {
        public int clientID;
        public string pawnTicketNumber;
        public int transactionID;
        public UserModel activeUser;
        public string processType;


        private ItemTypeService itemTypeService;
        private IdTypeService idTypeService;
        private AuctionDateService auctionDateService;
        private TicketTypeService ticketTypeService;
        private TransactionService transactionService;
        private TransactionItemService transactionItemService;

        private ItemTypeModel itemTypeModel;
        private IdTypeModel idTypeModel;
        private AuctionDateModel auctionDateModel;
        private TicketTypeModel ticketTypeModel;
        private TransactionCreateEdit transactionCreateEdit;
        private TransactionView transactionView;
        private TransactionItemModel transactionItemModel;
        private Methods.ComputationHelper computationHelper;

        private string transactionItemProcess = "New";
        public formTransactionProcess()
        {
            InitializeComponent();

            itemTypeService = new ItemTypeService();
            idTypeService = new IdTypeService();
            auctionDateService = new AuctionDateService();
            ticketTypeService = new TicketTypeService();
            transactionService = new TransactionService();


            itemTypeModel = new ItemTypeModel();
            idTypeModel = new IdTypeModel();
            auctionDateModel = new AuctionDateModel();
            ticketTypeModel = new TicketTypeModel();
            transactionCreateEdit = new TransactionCreateEdit();
            transactionView = new TransactionView();
            computationHelper = new Methods.ComputationHelper();
        }

        private void PrintPawnTicket()
        {
            TransactionView transactionView = transactionService.Get().Where(x => x.ID == transactionID).FirstOrDefault();
            string oldPawnTicket = string.Empty;
            if (transactionView.OldID != 0)
            {
                TransactionView transactionViewOld = transactionService.Get().Where(x => x.ID == transactionView.OldID).FirstOrDefault();
                oldPawnTicket = transactionViewOld.PawnTicketNumber;
            }

            transactionItemService = new TransactionItemService();
            List<TransactionItemModel> transactionItems = transactionItemService.Get().Where(x => x.TransactionID == transactionID).ToList();
            string transactionItem = string.Empty;
            foreach (TransactionItemModel item in transactionItems)
            {
                if (transactionItem == string.Empty)
                {
                    transactionItem = item.Description;
                }
                else
                {
                    transactionItem = transactionItem + ", " + item.Description;
                }
            }

            PrinterSettings printerSetting = new PrinterSettings();
            pawnTicket1.SetParameterValue("dateLoan", transactionView.DateLoan.ToString("MMM dd, yyyy"));
            pawnTicket1.SetParameterValue("dateMature", transactionView.DateMaturity.ToString("MMM dd, yyyy"));
            pawnTicket1.SetParameterValue("dateExpiry", transactionView.DateExpiry.ToString("MMM dd, yyyy"));
            pawnTicket1.SetParameterValue("auctionDate", "SUBASTA ON " + transactionView.AuctionDate.ToString("MMM dd, yyyy"));
            pawnTicket1.SetParameterValue("clientName", transactionView.ClientFirstName + " " + transactionView.ClientLastName + " " + oldPawnTicket);
            pawnTicket1.SetParameterValue("clientAddress", transactionView.ClientAddress);
            pawnTicket1.SetParameterValue("principalWord", HelperClass.NumWordsWrapper(transactionView.Principal) + " Pesos");
            pawnTicket1.SetParameterValue("principal", transactionView.Principal.ToString("F", CultureInfo.InvariantCulture));
            pawnTicket1.SetParameterValue("appraisedValueWord", HelperClass.NumWordsWrapper(transactionView.AppraiseValue) + " Pesos");
            pawnTicket1.SetParameterValue("appraisedValue", transactionView.AppraiseValue.ToString("F", CultureInfo.InvariantCulture));
            pawnTicket1.SetParameterValue("interest", transactionView.Interest.ToString("F", CultureInfo.InvariantCulture));
            pawnTicket1.SetParameterValue("interestPercent", transactionView.ItemTypeInterest);
            pawnTicket1.SetParameterValue("interestPercentWord", HelperClass.NumWordsWrapper(transactionView.ItemTypeInterest) + " Pesos");
            pawnTicket1.SetParameterValue("serviceCharge", transactionView.ServiceCharge.ToString("F", CultureInfo.InvariantCulture));
            pawnTicket1.SetParameterValue("netProceeds", transactionView.NetProceed.ToString("F", CultureInfo.InvariantCulture));
            pawnTicket1.SetParameterValue("idPresented", transactionView.IdType);
            pawnTicket1.SetParameterValue("clientContactNumber", transactionView.ClientContactNumber);
            pawnTicket1.SetParameterValue("daysToPenalty", transactionView.ItemTypeDaysToMature.ToString());
            pawnTicket1.SetParameterValue("itemDescription", transactionItem);
            pawnTicket1.SetParameterValue("processBy", transactionView.ProcessBy);
            pawnTicket1.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
            pawnTicket1.PrintOptions.PrinterName = printerSetting.PrinterName;
            pawnTicket1.PrintToPrinter(1, false, 0, 0);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formTransactionProcess_Load(object sender, EventArgs e)
        {

            #region ItemTypeList
            List<ItemTypeModel> itemTypeList = new List<ItemTypeModel>();
            itemTypeList = itemTypeService.Get().ToList();
            itemTypeList.Insert(0, new ItemTypeModel
            {
                ID = 0,
                Description = "-Select Item Type-"
            });
            comboItemType.ValueMember = "ID";
            comboItemType.DisplayMember = "Description";
            comboItemType.DataSource = itemTypeList;
            #endregion

            #region TicketTypeList
            List<TicketTypeModel> ticketTypeList = new List<TicketTypeModel>();
            ticketTypeList = ticketTypeService.Get().ToList();
            ticketTypeList.Insert(0, new TicketTypeModel
            {
                ID = 0,
                Type = "-Select Ticket Type-"
            });
            comboTicketType.ValueMember = "ID";
            comboTicketType.DisplayMember = "Type";
            comboTicketType.DataSource = ticketTypeList;
            #endregion

            #region IdTypeList
            List<IdTypeModel> idTypeList = new List<IdTypeModel>();
            idTypeList = idTypeService.Get().ToList();
            idTypeList.Insert(0, new IdTypeModel
            {
                ID = 0,
                Type = "-Select Id Type-"
            });
            comboIdType.DisplayMember = "Type";
            comboIdType.ValueMember = "ID";

            comboIdType.DataSource = idTypeList;
            #endregion

            #region AuctionDateList
            List<AuctionDateModel> auctionDateList = new List<AuctionDateModel>();
            auctionDateList = auctionDateService.Get().OrderByDescending(x => x.Date).ToList();
            comboAuctionDate.ValueMember = "ID";
            comboAuctionDate.DisplayMember = "Date";
            comboAuctionDate.DataSource = auctionDateList;
            comboAuctionDate.Text = "-Select Auction Date-";
            #endregion

            if (processType != "Pawn")
            {

                transactionView = transactionService.Get().Where(x => x.ID == transactionID).FirstOrDefault();
                comboItemType.SelectedValue = transactionView.ItemTypeID;
                comboTicketType.SelectedValue = transactionView.TicketTypeID;
                comboIdType.SelectedValue = transactionView.IdTypeID;
                textPrincipal.Text = transactionView.Principal.ToString();


                if (processType == "Redeem" || processType == "Edit" || processType == "View")
                {
                    textPawnTicketNumber.Text = transactionView.PawnTicketNumber;
                    comboAuctionDate.Text = transactionView.AuctionDate.ToShortDateString();
                    datePickerLoan.Value = transactionView.DateLoan;
                    datePickerMaturity.Value = transactionView.DateMaturity;
                    datePickerExpiry.Value = transactionView.DateExpiry;
                    toolStripSeparator2.Visible = true;
                    buttonPrintPawnTicket.Visible = true;

                    if (processType == "View")
                    {
                        labelPrincipal.Text = transactionView.Principal.ToString("F", CultureInfo.InvariantCulture);
                        labelInterest.Text = transactionView.Interest.ToString("F", CultureInfo.InvariantCulture);
                        labelPenalty.Text = transactionView.Penalty.ToString("F", CultureInfo.InvariantCulture);
                        labelServiceCharge.Text = transactionView.ServiceCharge.ToString("F", CultureInfo.InvariantCulture);
                        labelAppraisedValue.Text = transactionView.AppraiseValue.ToString("F", CultureInfo.InvariantCulture);
                        labelNetProceeds.Text = transactionView.NetProceed.ToString("F", CultureInfo.InvariantCulture);
                        buttonTransfer.Visible = true;
                        toolStripSeparator1.Visible = true;

                        buttonSave.Enabled = false;
                        buttonEdit.Enabled = false;
                        buttonNew.Enabled = false;
                    }
                    else if (processType == "Redeem")
                    {
                        labelDateClosed.Visible = true;
                        datePickerClosed.Visible = true;
                        labelDateLoan.Visible = false;
                        datePickerLoan.Visible = false;
                        labelDatePenalty.Visible = false;
                        datePickerPenalty.Visible = false;
                        labelDateMature.Visible = false;
                        datePickerMaturity.Visible = false;
                        labelDateExpire.Visible = false;
                        datePickerExpiry.Visible = false;
                    }
                }

                TransactionItemService transactionItemService = new TransactionItemService();
                List<TransactionItemModel> transactionItemList = new List<TransactionItemModel>();
                BindingSource bs = new BindingSource();
                transactionItemList = transactionItemService.Get().Where(x => x.TransactionID == transactionView.ID).ToList();
                bs.DataSource = transactionItemList;
                dataGrid.AutoGenerateColumns = false;
                dataGrid.DataSource = bs;

                dataGrid.Columns[0].DataPropertyName = "ID";
                dataGrid.Columns[1].DataPropertyName = "Description";

                if (processType != "Edit" && processType != "Pawn" && processType != "View")
                {
                    comboItemType.Enabled = false;
                    comboIdType.Enabled = false;
                    comboTicketType.Enabled = false;
                    textPrincipal.ReadOnly = true;
                    groupBox4.Enabled = false;
                }
                string dateClosed = transactionView.DateClosed != null ? " | Date Closed :" + Convert.ToDateTime(transactionView.DateClosed).ToShortDateString() : "";
                this.Text = "[" + processType + "] Pawn Ticket Number: " + transactionView.PawnTicketNumber + " | Status: " + transactionView.Status + dateClosed;
            }
            else
            {
                labelInterest.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                labelPenalty.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                labelServiceCharge.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                labelAppraisedValue.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                labelNetProceeds.Text = 0.ToString("F", CultureInfo.InvariantCulture);
            }
        }

        private void comboItemType_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboAuctionDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 38 || e.KeyChar == 40 ? false : true;
        }

        private void comboItemType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboItemType.SelectedIndex > 0)
            {
                itemTypeModel = new ItemTypeModel();
                int itemTypeID = Convert.ToInt32(comboItemType.SelectedValue);
                itemTypeModel = itemTypeService.Get().Where(x => x.ID == itemTypeID).FirstOrDefault();
                datePickerPenalty.Value = datePickerLoan.Value.AddDays(itemTypeModel.DaysToPenalty);
                datePickerMaturity.Value = datePickerLoan.Value.AddDays(itemTypeModel.DaysToMature);
                datePickerExpiry.Value = datePickerMaturity.Value.AddDays(itemTypeModel.DaysToExpire);

                if (textPrincipal.Text != string.Empty)
                {
                    var principal = Convert.ToDouble(textPrincipal.Text);

                    ComputationModel compute = new ComputationModel();
                    compute = transactionService.Compute(principal, itemTypeModel.ID);

                    //var interest = computationHelper.getInterest(principal, itemTypeModel.Interest, 1);
                    var interest = compute.Interest;
                    var penalty = 0.00;
                    var netProceed = 0.00;
                    var serviceCharge = compute.ServiceCharge;
                    var appraisedValue = compute.AppraiseValue;

                    if (processType == "Renew")
                    {
                        if (datePickerLoan.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerLoan.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                        }
                    }
                    else if (processType == "Redeem")
                    {
                        if (datePickerClosed.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerClosed.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                            //penalty = computationHelper.getPenalty(principal, itemTypeModel.Penalty, multiplier);
                        }
                    }

                    netProceed = principal - (interest + penalty + serviceCharge);
                    labelServiceCharge.Text = serviceCharge.ToString("F", CultureInfo.InvariantCulture);
                    labelInterest.Text = interest.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = penalty.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = appraisedValue.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = netProceed.ToString("F", CultureInfo.InvariantCulture);
                }
                else
                {
                    labelInterest.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelServiceCharge.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                }
            }
        }

        private void textPrincipal_TextChanged(object sender, EventArgs e)
        {
            if (comboItemType.SelectedIndex == 0)
            {
                MessageBox.Show("Select Item Type First", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboItemType.Focus();
            }
            else
            {
                if (textPrincipal.Text != string.Empty)
                {
                    var principal = Convert.ToDouble(textPrincipal.Text);

                    ComputationModel compute = new ComputationModel();
                    compute = transactionService.Compute(principal, itemTypeModel.ID);

                    //var interest = computationHelper.getInterest(principal, itemTypeModel.Interest, 1);
                    var interest = compute.Interest;
                    var penalty = 0.00;
                    var netProceed = 0.00;
                    var serviceCharge = compute.ServiceCharge;
                    var appraisedValue = compute.AppraiseValue;


                    if (processType == "Renew")
                    {
                        if (datePickerLoan.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerLoan.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                        }
                    }
                    else if (processType == "Redeem")
                    {
                        if (datePickerClosed.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerClosed.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                            //penalty = computationHelper.getPenalty(principal, itemTypeModel.Penalty, multiplier);
                        }
                    }


                    netProceed = principal - (interest + penalty + serviceCharge);
                    labelPrincipal.Text = Convert.ToDouble(textPrincipal.Text).ToString("F", CultureInfo.InvariantCulture);
                    labelServiceCharge.Text = serviceCharge.ToString("F", CultureInfo.InvariantCulture);
                    labelInterest.Text = interest.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = penalty.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = appraisedValue.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = netProceed.ToString("F", CultureInfo.InvariantCulture);
                }
                else
                {
                    labelInterest.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelServiceCharge.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                }
            }
        }

        private void buttonSaveItem_Click(object sender, EventArgs e)
        {
            if (textTransactionItem.Text != string.Empty)
            {
                if (transactionItemProcess == "New")
                {
                    MessageBox.Show("Item Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGrid.Rows.Add(dataGrid.Rows.Count + 1, textTransactionItem.Text);
                    textTransactionItem.Text = string.Empty;
                    transactionItemProcess = "";
                    textTransactionItem.Enabled = false;
                    buttonSaveItem.Enabled = false;

                }
                else
                {
                    string messageBox = MessageBox.Show("Save Changes?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                    if (messageBox == "Yes")
                    {
                        MessageBox.Show("Item Saved", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGrid.CurrentRow.Cells[1].Value = textTransactionItem.Text;
                        transactionItemProcess = "";
                        textTransactionItem.Text = string.Empty;
                        textTransactionItem.Enabled = false;
                        buttonSaveItem.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Item Description", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                transactionItemProcess = "Edit";
                textTransactionItem.Text = Convert.ToString(dataGrid.CurrentRow.Cells[1].Value);
                textTransactionItem.Enabled = true;
                buttonSaveItem.Enabled = true;
                textTransactionItem.Focus();
            }
            else
            {
                MessageBox.Show("No Item(s) to Edit", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count < 3)
            {
                transactionItemProcess = "New";
                textTransactionItem.Text = string.Empty;
                textTransactionItem.Enabled = true;
                buttonSaveItem.Enabled = true;
                textTransactionItem.Focus();
            }
            else
            {
                MessageBox.Show("Max Items Reached", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is ComboBox)
                {
                    if (control.Text.Contains("-Select"))
                    {
                        isValid = false;
                    }
                }
                else if (control is TextBox)
                {
                    if (control.Text == string.Empty)
                    {
                        isValid = false;
                    }
                }
            }

            if (dataGrid.Rows.Count == 0)
            {
                isValid = false;
            }

            if (isValid)
            {
                TransactionCreateEdit toSavetransactionCreateEdit = new TransactionCreateEdit();
                transactionCreateEdit.ID = transactionID;
                transactionCreateEdit.ClientID = clientID;
                transactionCreateEdit.AuctionDateID = Convert.ToInt32(comboAuctionDate.SelectedValue);
                transactionCreateEdit.IdTypeID = Convert.ToInt32(comboIdType.SelectedValue);
                transactionCreateEdit.ItemTypeID = Convert.ToInt32(comboItemType.SelectedValue);
                transactionCreateEdit.TicketTypeID = Convert.ToInt32(comboTicketType.SelectedValue);
                transactionCreateEdit.Principal = Double.Parse(textPrincipal.Text);
                transactionCreateEdit.Interest = Double.Parse(labelInterest.Text) + Double.Parse(labelPenalty.Text);
                transactionCreateEdit.ServiceCharge = Double.Parse(labelServiceCharge.Text);
                transactionCreateEdit.NetProceed = Double.Parse(labelNetProceeds.Text);
                transactionCreateEdit.Penalty = Double.Parse(labelPenalty.Text);
                transactionCreateEdit.AppraiseValue = double.Parse(labelAppraisedValue.Text);
                transactionCreateEdit.PawnTicketNumber = textPawnTicketNumber.Text;
                transactionCreateEdit.DateLoan = datePickerLoan.Value;
                transactionCreateEdit.DateMaturity = datePickerMaturity.Value;
                transactionCreateEdit.DateExpiry = datePickerExpiry.Value;
                transactionCreateEdit.DatePenalty = datePickerPenalty.Value;

                int savedItems = 0;
                if (processType == "Pawn")
                {
                    transactionCreateEdit.TransactionType = processType;
                    DateTime now = DateTime.Now;
                    if (now >= datePickerMaturity.Value)
                    {
                        if (now >= datePickerExpiry.Value)
                        {
                            transactionCreateEdit.Status = "Expired";
                        }
                        else
                        {
                            transactionCreateEdit.Status = "Matured";
                        }
                    }
                    else
                    {
                        transactionCreateEdit.Status = "Open";
                    }
                    transactionCreateEdit.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;
                    transactionID = transactionService.Create(transactionCreateEdit).ID;
                }
                else if (processType == "Renew" || processType == "Redeem")
                {
                    TransactionCreateEdit toUpdateTransaction = new TransactionCreateEdit();
                    toUpdateTransaction = transactionService.Get().Select(x => new TransactionCreateEdit()
                    {
                        ClientID = x.ClientID,
                        ItemTypeID = x.ItemTypeID,
                        AuctionDateID = x.AuctionDateID,
                        TicketTypeID = x.TicketTypeID,
                        IdTypeID = x.IdTypeID,
                        ID = x.ID,
                        OldTransactionID = x.OldID,
                        PawnTicketNumber = x.PawnTicketNumber,
                        TransactionType = x.TransactionType,
                        DateLoan = x.DateLoan,
                        DateMaturity = x.DateMaturity,
                        DateExpiry = x.DateExpiry,
                        DatePenalty = x.DatePenalty,
                        Principal = x.Principal,
                        Interest = x.Interest,
                        ServiceCharge = x.ServiceCharge,
                        Penalty = x.Penalty,
                        AppraiseValue = x.AppraiseValue,
                        NetProceed = x.NetProceed,
                        Status = x.Status,
                        DateClosed = x.DateClosed,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedDate = x.ModifiedDate
                    }).Where(x => x.ID == transactionID).FirstOrDefault();

                    toUpdateTransaction.DateClosed = processType == "Redeem" ? datePickerClosed.Value : datePickerLoan.Value;
                    toUpdateTransaction.Status = "Closed";
                    toUpdateTransaction.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;

                    if (transactionService.Update(toUpdateTransaction) != null)
                    {
                        transactionCreateEdit.OldTransactionID = transactionID;
                        transactionCreateEdit.TransactionType = processType;
                        transactionCreateEdit.Status = processType == "Renew" ? "Open" : "Closed";
                        if (processType == "Redeem")
                        {
                            transactionCreateEdit.DateClosed = datePickerClosed.Value;
                        }
                        transactionCreateEdit.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;
                        transactionID = transactionService.Create(transactionCreateEdit).ID;
                    }
                }
                else if (processType == "Edit")
                {
                    transactionCreateEdit.OldTransactionID = transactionView.ID;
                    transactionCreateEdit.Status = transactionView.Status;
                    transactionCreateEdit.TransactionType = transactionView.TransactionType;
                    transactionCreateEdit.CreatedBy = transactionView.ProcessBy;
                    transactionCreateEdit.CreatedDate = transactionView.CreatedDate;
                    transactionCreateEdit.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;
                    transactionID = transactionService.Update(transactionCreateEdit).ID;
                }

                if (transactionID > 0)
                {
                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        transactionItemModel = new TransactionItemModel();
                        transactionItemService = new TransactionItemService();
                        transactionItemModel.TransactionID = transactionID;
                        transactionItemModel.Description = row.Cells[1].Value.ToString();

                        if (processType != "Edit")
                        {
                            transactionItemModel.CreatedBy = activeUser.FirstName + " " + activeUser.LastName;
                            transactionItemService.Create(transactionItemModel);
                        }
                        else
                        {
                            transactionItemModel.ID = Convert.ToInt32(row.Cells[0].Value);
                            transactionItemModel.ModifiedBy = activeUser.FirstName + " " + activeUser.LastName;
                            transactionItemService.Update(transactionItemModel);
                        }

                        if (transactionCreateEdit.ID != 0)
                        {
                            savedItems++;
                        }
                    }

                    if (savedItems > 0)
                    {
                        var msgConfirm = MessageBox.Show("Transaction Saved, Do you want to print Pawn Ticket?", "Pawnshop Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgConfirm == DialogResult.Yes)
                        {
                            PrintPawnTicket();
                        }
                        this.Dispose();
                        formTransaction form = (formTransaction)Application.OpenForms["formTransaction"];
                        form.loadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill up All Required Fields", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void datePicketLoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 38 || e.KeyChar == 40 ? false : true;
        }

        private void comboIdType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 38 || e.KeyChar == 40 ? false : true;
        }

        private void comboTicketType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 38 || e.KeyChar == 40 ? false : true;
        }

        private void textPawnTicketNumber_Leave(object sender, EventArgs e)
        {
            if (!this.Text.Contains("Edit") && !this.Text.Contains("Redeem"))
            {
                if (transactionService.Get().Where(x => x.PawnTicketNumber == textPawnTicketNumber.Text).FirstOrDefault() != null)
                {
                    MessageBox.Show("Pawn Ticket Number Exist", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textPawnTicketNumber.Clear();
                    textPawnTicketNumber.Focus();
                }
            }
        }

        private void datePicketLoan_ValueChanged(object sender, EventArgs e)
        {
            if (!comboItemType.Text.Contains("-Select"))
            {
                datePickerMaturity.Value = datePickerLoan.Value.AddDays(itemTypeModel.DaysToMature);
                datePickerPenalty.Value = datePickerLoan.Value.AddDays(itemTypeModel.DaysToPenalty);
                datePickerExpiry.Value = datePickerMaturity.Value.AddDays(itemTypeModel.DaysToExpire);

                if (textPrincipal.Text != string.Empty)
                {
                    var principal = Convert.ToDouble(textPrincipal.Text);

                    ComputationModel compute = new ComputationModel();
                    compute = transactionService.Compute(principal, itemTypeModel.ID);
                    var interest = compute.Interest;
                    var penalty = 0.00;
                    var netProceed = 0.00;
                    var serviceCharge = compute.ServiceCharge;
                    var appraisedValue = compute.AppraiseValue;


                    if (processType == "Renew")
                    {
                        if (datePickerLoan.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerLoan.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                        }
                    }
                    else if (processType == "Redeem")
                    {
                        if (datePickerClosed.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerClosed.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                            //penalty = computationHelper.getPenalty(principal, itemTypeModel.Penalty, multiplier);
                        }
                    }


                    netProceed = principal - (interest + penalty + serviceCharge);
                    labelServiceCharge.Text = serviceCharge.ToString("F", CultureInfo.InvariantCulture);
                    labelInterest.Text = interest.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = penalty.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = appraisedValue.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = netProceed.ToString("F", CultureInfo.InvariantCulture);
                }
                else
                {
                    labelInterest.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelServiceCharge.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                }
            }
            else
            {
                MessageBox.Show("Select Item Type First", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                buttonSave.PerformClick();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                this.Dispose();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void datePickerClosed_ValueChanged(object sender, EventArgs e)
        {
            if (!comboItemType.Text.Contains("-Select"))
            {
                datePickerMaturity.Value = datePickerLoan.Value.AddDays(itemTypeModel.DaysToMature);
                datePickerPenalty.Value = datePickerLoan.Value.AddDays(itemTypeModel.DaysToPenalty);
                datePickerExpiry.Value = datePickerMaturity.Value.AddDays(itemTypeModel.DaysToExpire);

                if (textPrincipal.Text != string.Empty)
                {
                    var principal = Convert.ToDouble(textPrincipal.Text);

                    ComputationModel compute = new ComputationModel();
                    compute = transactionService.Compute(principal, itemTypeModel.ID);
                    var interest = compute.Interest;
                    var penalty = 0.00;
                    var netProceed = 0.00;
                    var serviceCharge = compute.ServiceCharge;
                    var appraisedValue = compute.AppraiseValue;

                    if (processType == "Renew")
                    {
                        if (datePickerLoan.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerLoan.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                        }
                    }
                    else if (processType == "Redeem")
                    {
                        if (datePickerClosed.Value > transactionView.DatePenalty)
                        {
                            int multiplier = Convert.ToInt32(Math.Round((datePickerClosed.Value - transactionView.DatePenalty).TotalDays)) / 30;
                            multiplier = multiplier == 0 ? 1 : multiplier + 1;
                            penalty = compute.Penalty * (multiplier);
                            //penalty = computationHelper.getPenalty(principal, itemTypeModel.Penalty, multiplier);
                        }
                    }

                    netProceed = principal - (interest + penalty + serviceCharge);
                    labelServiceCharge.Text = serviceCharge.ToString("F", CultureInfo.InvariantCulture);
                    labelInterest.Text = interest.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = penalty.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = appraisedValue.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = netProceed.ToString("F", CultureInfo.InvariantCulture);
                }
                else
                {
                    labelInterest.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelPenalty.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelServiceCharge.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelAppraisedValue.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                    labelNetProceeds.Text = 0.ToString("F", CultureInfo.InvariantCulture);
                }
            }
            else
            {
                MessageBox.Show("Select Item Type First", "Pawnshop Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrintPawnTicket_Click(object sender, EventArgs e)
        {
            PrintPawnTicket();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            formClient formClient = new formClient();
            formClient.activeUser = activeUser;
            formClient.pawnTicketNumber = textPawnTicketNumber.Text;
            formClient.transactionID = transactionID;
            formClient.type = "transfer";
            formClient.ShowDialog();
        }
    }
}

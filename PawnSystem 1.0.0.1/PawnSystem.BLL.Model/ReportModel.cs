using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.BLL.Model
{
    public class OutLedgerModel
    {
        public string date { get; set; }
        public string transactionType { get; set; }
        public string pawnTicketNumber { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public string itemDescription { get; set; }
        public double principal { get; set; }
        public double serviceCharge { get; set; }
        public double interest { get; set; }
        public double netProceeds { get; set; }
        public string itemType { get; set; }

    }
    public class InLedgerModel
    {
        public string date { get; set; }
        public string clientName { get; set; }
        public string pawnTicketNumber { get; set; }
        public double principal { get; set; }
        public int months { get; set; }
        public int days { get; set; }
        public double amount { get; set; }
        public int interestPercent { get; set; }
        public double interestAmount { get; set; }
        public double penalty { get; set; }
        public double netProceed { get; set; }
        public string transactionType { get; set; }
    }
    public class AuctionModel
    {
        public int clientID { get; set; }
        public string date { get; set; }
        public string pawnTicketNumber { get; set; }
        public string clientName { get; set; }
        public string itemDescription { get; set; }
        public string principal { get; set; }
        public string interest { get; set; }
        public string penalty { get; set; }
        public string netProceed { get; set; }
    }
    public class NoticeReportModel
    {
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string PawnTicketNumber { get; set; }
        public string Principal { get; set; }
        public string dateLoan { get; set; }
        public string dateExpiry { get; set; }
        public string dateAuction { get; set; }
    }
    public class NoticeModel
    {
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string PawnTicketNumber { get; set; }
        public string Principal { get; set; }
        public string PrincipalText { get; set; }
        public string dateLoan { get; set; }
        public string datePenalty { get; set; }
        public string dateAuction { get; set; }
        public string dateExpiry { get; set; }
        public string dateAuctionWord { get; set; }
        public string monthDay { get; set; }
        public string year { get; set; }
        public string dateLoanReport { get; set; }
        public string dateAuctionReport { get; set; }
        public string dateExpiryReport { get; set; }
    }
}

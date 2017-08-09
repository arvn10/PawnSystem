using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PawnSystem.BLL.Model
{
    public class TransactionCreateEdit : CreateModifyPropertyModel
    {
        public int ClientID { get; set; }
        public int ItemTypeID { get; set; }
        public int AuctionDateID { get; set; }
        public int TicketTypeID { get; set; }
        public int IdTypeID { get; set; }
        public int ID { get; set; }
        public int OldTransactionID { get; set; }
        public string PawnTicketNumber { get; set; }
        public string TransactionType { get; set; }
        public DateTime DateLoan { get; set; }
        public DateTime DateMaturity { get; set; }  
        public DateTime DateExpiry { get; set; }
        public DateTime DatePenalty { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double ServiceCharge { get; set; }
        public double Penalty { get; set; }
        public double AppraiseValue { get; set; }
        public double NetProceed { get; set; }
        public string Status { get; set; }
        public DateTime? DateClosed { get; set; }
    }
    public class TransactionView : CreateModifyPropertyModel
    {
        #region Client
        public int ClientID { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string ClientFullName { get; set; }
        public string ClientAddress { get; set; }

        public string ClientContactNumber { get; set; }

        public string ClientImagePath { get; set; }

        #endregion

        #region Item Type
        public int ItemTypeID { get; set; }
        public string ItemTypeDescription { get; set; }

        public int ItemTypeInterest { get; set; }

        public int ItemTypePenalty { get; set; }

        public int ItemTypeAppraiseValue { get; set; }

        public string ItemTypeWithServiceCharge { get; set; }

        public int ItemTypeDaysToMature { get; set; }

        public int ItemTypeDaysToExpire { get; set; }

        public int ItemTypeDaysToPenalty { get; set; }
        #endregion

        #region Auction Date
        public int AuctionDateID { get; set; }
        public DateTime AuctionDate { get; set; }

        public DateTime AuctionItemFrom { get; set; }

        public DateTime AuctionItemTo { get; set; }
        #endregion

        #region Ticket Type
        public int TicketTypeID { get; set; }
        public string TicketType { get; set; }
        #endregion

        #region Id Type
        public int IdTypeID { get; set; }
        public string IdType { get; set; }
        #endregion

        public int ID { get; set; }
        public int OldID { get; set; }
        public string PawnTicketNumber { get; set; }
        public string TransactionType { get; set; }
        public DateTime DateLoan { get; set; }
        public DateTime DateMaturity { get; set; }
        public DateTime DateExpiry { get; set; }
        public DateTime DatePenalty { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double ServiceCharge { get; set; }
        public double Penalty { get; set; }
        public double AppraiseValue { get; set; }
        public double NetProceed { get; set; }
        public string Status { get; set; }
        public DateTime? DateClosed { get; set; }
        public string ProcessBy { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
    public class ComputationModel
    {
        public double Interest { get; set; }
        public double Penalty { get; set; }
        public double AppraiseValue { get; set; }
        public double ServiceCharge { get; set; }
    }
}

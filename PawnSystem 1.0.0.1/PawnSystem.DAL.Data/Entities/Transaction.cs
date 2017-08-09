using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.DAL.Data.Entities
{
    public class Transaction : Entities.CreatModifyProperty
    {
        public int ID { get; set; }

        public int OldTransactionID { get; set; }
        public int ClientID { get; set; }

        public int ItemTypeID { get; set; }

        public int AuctionDateID { get; set; }

        public int IdTypeID { get; set; }

        public int TicketTypeID { get; set; }
        
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

        public virtual Client Client { get; set; }

        public virtual ItemType ItemType { get; set; }

        public virtual AuctionDate AuctionDate { get; set; }

        public virtual IdType IdType { get; set; }

        public virtual TicketType TicketType { get; set; }

        public virtual ICollection<TransactionItem> TransactionItem { get; set; }
    }
}

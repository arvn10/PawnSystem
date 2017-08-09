using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.BLL.Model
{
    public class TransactionItemModel : CreateModifyPropertyModel
    {
        public int ID { get; set; }

        public int TransactionID { get; set; }

        public string Description { get; set; }
    }

    public class TransactionItemAuctionReport
    {
        public int TransactionItemID { get; set; }
        public int TransactionID { get; set; }
        public string Month { get; set; }
        public DateTime DateLoan { get; set; }
        public string PawnTicketNumber { get; set; }
        public string ItemDescription { get; set; }
        public double Principal { get; set; }
        public double Intereset { get; set; }
        public double Penalty { get; set; }
        public double NetProceeds { get; set; }
    }
}

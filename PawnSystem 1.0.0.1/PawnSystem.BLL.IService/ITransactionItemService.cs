using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnSystem.BLL.Model;
namespace PawnSystem.BLL.IService
{
    public interface ITransactionItemService
    {
        List<TransactionItemAuctionReport> generateAuctionReport(int auctionDateID);
    }
}

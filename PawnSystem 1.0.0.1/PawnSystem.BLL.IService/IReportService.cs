using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnSystem.BLL.Model;
namespace PawnSystem.BLL.IService
{
    public interface IReportService
    {
        List<OutLedgerModel> GenerateOutLedger(DateTime from, DateTime to);

        List<InLedgerModel> GenerateInLedger(DateTime from, DateTime to);

        List<AuctionModel> GenerateAuctionReport(AuctionDateModel param);
    }
}

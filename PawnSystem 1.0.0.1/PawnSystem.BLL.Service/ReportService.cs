using System;
using System.Collections.Generic;
using System.Linq;
using PawnSystem.BLL.IService;
using PawnSystem.BLL.Model;
using System.Globalization;
using PawnSystem.Helper;
namespace PawnSystem.BLL.Service
{
    public class ReportService : IReportService
    {
        TransactionService transactionService;
        TransactionItemService transactionItemService;
        HelperClass helper = new HelperClass();
        public ReportService()
        {
            transactionService = new TransactionService();
            transactionItemService = new TransactionItemService();
        }
        public List<OutLedgerModel> GenerateOutLedger(int ticketTypeID, DateTime from, DateTime to)
        {
            from = new DateTime(from.Year, from.Month, from.Day);
            to = new DateTime(to.Year, to.Month, to.Day);
            List<TransactionView> transactions = new List<TransactionView>();
            List<OutLedgerModel> outLedgerRaw = new List<OutLedgerModel>();
            if (ticketTypeID == 0)
            {
                transactions = transactionService.Get().Where(x =>
                                                              x.DateLoan >= from &&
                                                              x.DateLoan <= to &&
                                                              x.Status != "Closed" &&
                                                             (x.TransactionType == "Renew" ||
                                                              x.TransactionType == "Pawn"))
                                                      .OrderBy(x => x.PawnTicketNumber)
                                                      .ToList();
            }
            else
            {
                transactions = transactionService.Get().Where(x => x.TicketTypeID == ticketTypeID &&
                                                              x.DateLoan >= from &&
                                                              x.DateLoan <= to &&
                                                              x.Status != "Closed" &&
                                                             (x.TransactionType == "Renew" ||
                                                              x.TransactionType == "Pawn"))
                                                      .OrderBy(x => x.PawnTicketNumber)
                                                      .ToList();
            }


            foreach (TransactionView transaction in transactions)
            {
                OutLedgerModel data = new OutLedgerModel();
                data.date = transaction.DateLoan.ToString("yyyy-MM-dd");
                data.transactionType = transaction.TransactionType;
                data.itemType = transaction.ItemTypeDescription;
                data.pawnTicketNumber = transaction.PawnTicketNumber;
                data.clientName = transaction.ClientFullName;
                data.clientAddress = transaction.ClientAddress;
                data.principal = transaction.Principal;
                data.serviceCharge = transaction.ServiceCharge;
                data.interest = transaction.Interest;
                data.netProceeds = transaction.NetProceed;


                TransactionItemService transactionItemService = new TransactionItemService();
                List<TransactionItemModel> transactionItems = new List<TransactionItemModel>();
                transactionItems = transactionItemService.Get()
                                                         .Where(x => x.TransactionID == transaction.ID)
                                                         .ToList();
                foreach (TransactionItemModel item in transactionItems)
                {
                    data.itemDescription = data.itemDescription == null ? data.itemDescription + "" : data.itemDescription + ", ";
                    data.itemDescription = data.itemDescription + item.Description;
                }

                outLedgerRaw.Add(data);
            }

            return outLedgerRaw;
        }
        public List<InLedgerModel> GenerateInLedger(int ticketTypeID, DateTime from, DateTime to)
        {
            from = new DateTime(from.Year, from.Month, from.Day);
            to = new DateTime(to.Year, to.Month, to.Day);
            List<TransactionView> transactionList = new List<TransactionView>();
            if (ticketTypeID == 0)
            {
                transactionList = transactionService.Get()
                                                        .Where(x =>
                                                               x.DateClosed >= from &&
                                                               x.DateClosed <= to &&
                                                               x.Status == "Closed")
                                                        .OrderBy(x => x.PawnTicketNumber)
                                                        .ThenBy(x => x.DateClosed)
                                                        .ToList();
            }
            else
            {
                transactionList = transactionService.Get()
                                                        .Where(x =>
                                                               x.TicketTypeID == ticketTypeID &&
                                                               x.DateClosed >= from &&
                                                               x.DateClosed <= to &&
                                                               x.Status == "Closed")
                                                        .OrderBy(x => x.PawnTicketNumber)
                                                        .ThenBy(x => x.DateClosed)
                                                        .ToList();
            }

            List<InLedgerModel> inLedgerList = new List<InLedgerModel>();

            foreach (TransactionView transaction in transactionList.ToList())
            {


                InLedgerModel inLedger = new InLedgerModel();
                TransactionView oldTransactionView = transactionList.Where(x => x.OldID == transaction.ID &&
                                                                           x.DateClosed == transaction.DateClosed)
                                                                    .FirstOrDefault();
                if (oldTransactionView == null)
                {
                    inLedger.transactionType = transaction.TransactionType == "Pawn" ? "Renew" : transaction.TransactionType;
                    inLedger.date = Convert.ToDateTime(transaction.DateClosed).ToString("yyyy-MM-dd");
                    inLedger.clientName = transaction.ClientFullName;
                    inLedger.pawnTicketNumber = transaction.PawnTicketNumber;
                    inLedger.principal = transaction.Principal;
                    int daysInterest = 0;
                    int daysPenalty = 0;
                    int pMonth = 0;
                    int pDay = 0;
                    for (DateTime index = transaction.DateLoan; index < transaction.DateClosed; index = index.AddDays(1))
                    {
                        if (index.DayOfWeek != DayOfWeek.Sunday)
                        {
                            daysInterest++;
                        }
                    }
                    for (DateTime index = transaction.DatePenalty; index < transaction.DateClosed; index = index.AddDays(1))
                    {
                        if (index.DayOfWeek != DayOfWeek.Sunday)
                        {
                            daysPenalty++;
                        }
                    }
                    double interest = Math.Round(((double)transaction.Principal / 100) * transaction.ItemTypeInterest, 2);
                    double penalty = Math.Round(((double)transaction.Principal / 100) * transaction.ItemTypePenalty, 2);
                    if (daysInterest > 30)
                    {
                        inLedger.months = daysInterest / 30;
                        inLedger.days = daysInterest % 30;
                        inLedger.amount = Math.Round((interest * (inLedger.months - 1)) + (((double)interest / 30) * inLedger.days), 2);
                        inLedger.interestAmount = interest;
                    }
                    else
                    {
                        inLedger.months = 0;
                        inLedger.days = daysInterest;
                        inLedger.amount = 0;
                        inLedger.interestAmount = 0;
                    }

                    if (daysPenalty > 30)
                    {
                        pMonth = daysPenalty / 30;
                        pDay = daysPenalty % 30;
                        inLedger.penalty = Math.Round((penalty * pMonth) + (((double)penalty / 30) * pDay), 2);
                    }
                    else
                    {
                        pMonth = 1;
                        pDay = daysPenalty;
                        if (transaction.DateClosed > transaction.DatePenalty)
                        {
                            inLedger.penalty = Math.Round((penalty * pMonth) + (((double)penalty / 30) * pDay), 2);
                        }
                        else
                        {
                            inLedger.penalty = 0.00;
                        }
                    }

                    inLedger.interestPercent = transaction.ItemTypeInterest;
                    inLedger.netProceed = inLedger.principal + inLedger.amount + inLedger.interestAmount + inLedger.penalty;

                    inLedgerList.Add(inLedger);
                }
            }
            return inLedgerList;
        }
        public List<AuctionModel> GenerateAuctionReport(int ticketTypeID, AuctionDateModel param)
        {
            List<TransactionView> transactionList = new List<TransactionView>();

            if (ticketTypeID == 0)
            {
                transactionList = transactionService.Get()
                                            .Where(x => x.AuctionDateID == param.ID &&
                                                        x.Status == "Expired")
                                            .OrderBy(x => x.DateLoan)
                                            .ThenBy(x => x.ClientID)
                                            .ToList();
            }
            else
            {
                transactionList = transactionService.Get()
                                            .Where(x => x.AuctionDateID == param.ID &&
                                                        x.TicketTypeID == ticketTypeID &&
                                                        x.Status == "Expired")
                                            .OrderBy(x => x.DateLoan)
                                            .ThenBy(x => x.ClientID)
                                            .ToList();
            }

            List<AuctionModel> auctionList = new List<AuctionModel>();
            if (transactionList.Count > 0)
            {
                transactionService.UpdateTransactionStatusAuction(param.ID);
            }
            foreach (TransactionView transaction in transactionList)
            {

                int days = 0;
                int daysPenalty = 0;
                int index = 0;

                for (DateTime pos = transaction.DateLoan; pos < param.Date; pos = pos.AddDays(1))
                {
                    days++;
                }

                for (DateTime pos = transaction.DatePenalty; pos < param.Date; pos = pos.AddDays(1))
                {
                    daysPenalty++;
                }

                int monthInterest = days / 30;
                int dayInterest = days > 30 ? days % 30 : days;
                int monthPenalty = daysPenalty / 30;
                int dayPenalty = daysPenalty > 30 ? daysPenalty % 30 : daysPenalty;
                List<TransactionItemModel> transactionItems = transactionItemService.Get().Where(x => x.TransactionID == transaction.ID).ToList();
                foreach (TransactionItemModel item in transactionItems)
                {
                    AuctionModel auction = new AuctionModel();
                    if (index > 0)
                    {
                        auction.date = "";
                        auction.pawnTicketNumber = "";
                        auction.clientName = "";
                        auction.principal = "";
                        auction.interest = "";
                        auction.penalty = "";
                        auction.netProceed = "";
                    }
                    else
                    {
                        double principal = transaction.Principal;
                        double interest = Math.Round(((double)principal / 100) * transaction.ItemTypeInterest, 2);
                        double penalty = Math.Round(((double)principal / 100) * transaction.ItemTypePenalty, 2);

                        double interestComputed = Math.Round((interest * (monthInterest)) + (((double)interest / 30) * dayInterest), 2);
                        double penaltyComputed = Math.Round((penalty * (monthPenalty)) + (((double)penalty / 30) * dayPenalty), 2);
                        double netProceed = Math.Round(principal + interestComputed + penaltyComputed, 2);

                        auction.clientID = transaction.ClientID;
                        auction.date = transaction.DateLoan.ToShortDateString();
                        auction.pawnTicketNumber = transaction.PawnTicketNumber;
                        auction.clientName = transaction.ClientFullName;
                        auction.principal = principal.ToString("F", CultureInfo.InvariantCulture);
                        auction.interest = interestComputed.ToString("F", CultureInfo.InvariantCulture);
                        auction.penalty = penaltyComputed.ToString("F", CultureInfo.InvariantCulture);
                        auction.netProceed = netProceed.ToString("F", CultureInfo.InvariantCulture);
                        auction.itemDescription = item.Description;
                    }
                    auction.itemDescription = item.Description;

                    auctionList.Add(auction);
                    index++;
                }

            }
            return auctionList;
        }
        public List<NoticeModel> GenerateNoticeMail(int ticketTypeID, DateTime from, DateTime to)
        {
            from = new DateTime(from.Year, from.Month, from.Day);
            to = new DateTime(to.Year, to.Month, to.Day);
            List<NoticeModel> noticeList = new List<NoticeModel>();
            List<TransactionView> transactions = new List<TransactionView>();

            if (ticketTypeID == 0)
            {
                transactions = transactionService.Get()
                                                    .AsQueryable()
                                                    .Where(x => x.DatePenalty >= from &&
                                                                x.DatePenalty <= to &&
                                                                x.Status != "Closed")
                                                    .OrderBy(x => x.DateLoan)
                                                    .ThenBy(x => x.ClientID)
                                                    .ToList();
            }
            else
            {
                transactions = transactionService.Get()
                                                    .Where(x => x.DatePenalty >= from &&
                                                                x.DatePenalty <= to &&
                                                                x.TicketTypeID == ticketTypeID &&
                                                                x.Status != "Closed")
                                                    .OrderBy(x => x.DateLoan)
                                                    .ThenBy(x => x.ClientID)
                                                    .ToList();
            }

            foreach (TransactionView transaction in transactions)
            {
                NoticeModel notice = new NoticeModel();
                notice.ClientName = transaction.ClientFirstName + " " + transaction.ClientLastName;
                notice.ClientAddress = transaction.ClientAddress;
                notice.PawnTicketNumber = transaction.PawnTicketNumber;
                notice.Principal = transaction.Principal.ToString("F", CultureInfo.InvariantCulture);
                notice.PrincipalText = HelperClass.NumWordsWrapper(transaction.Principal) + " Pesos";
                notice.dateLoan = transaction.DateLoan.ToString("yyyy-MM-dd");
                notice.datePenalty = transaction.DatePenalty.ToString("yyyy-MM-dd");
                notice.dateAuction = transaction.AuctionDate.ToString("MM dd, yyyyy");
                notice.dateExpiry = transaction.DateExpiry.ToString("MM dd, yyyyy");
                notice.dateAuctionWord = string.Format("{0:D}", transaction.AuctionDate);
                notice.monthDay = string.Format("{0:m}", transaction.AuctionDate);
                notice.year = string.Format("{0:yy}", transaction.AuctionDate);
                notice.dateLoanReport = transaction.DateLoan.ToString("yyyy-MM-dd");
                notice.dateExpiryReport = transaction.DateExpiry.ToString("yyyy-MM-dd");
                notice.dateAuctionReport = transaction.AuctionDate.ToString("yyyy-MM-dd");
                noticeList.Add(notice);
            }
            return noticeList;
        }
    }
}
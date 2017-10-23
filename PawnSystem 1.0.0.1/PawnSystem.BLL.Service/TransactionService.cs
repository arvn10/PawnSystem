using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using PawnSystem.BLL.Model;
using PawnSystem.BLL.IService;
using PawnSystem.DAL.Core;
using PawnSystem.DAL.Data.Entities;

namespace PawnSystem.BLL.Service
{
    public class TransactionService :  ITransactionService
    {
        private PawnSystemContext context;
        public TransactionService()
        {
            context = new PawnSystemContext();
        }
        public TransactionCreateEdit Create(TransactionCreateEdit model)
        {
            Transaction data = new Transaction();
            data.OldTransactionID = model.OldTransactionID;
            data.ClientID = model.ClientID;
            data.ItemTypeID = model.ItemTypeID;
            data.AuctionDateID = model.AuctionDateID;
            data.IdTypeID = model.IdTypeID;
            data.TicketTypeID = model.TicketTypeID;
            data.PawnTicketNumber = model.PawnTicketNumber;
            data.TransactionType = model.TransactionType;
            data.DateLoan = model.DateLoan;
            data.DateMaturity = model.DateMaturity;
            data.DateExpiry = model.DateExpiry;
            data.DatePenalty = model.DatePenalty;
            data.DateClosed = model.DateClosed;
            data.Principal = model.Principal;
            data.Interest = model.Interest;
            data.ServiceCharge = model.ServiceCharge;
            data.Penalty = model.Penalty;
            data.AppraiseValue = model.AppraiseValue;
            data.NetProceed = model.NetProceed;
            data.Status = model.Status;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<Transaction>(data);
            context.SaveChanges();

            model.ID = data.ID;
            return model;
        }
        public bool Delete(int transactionID)
        {
            var transaction = context.AsQueryable<Transaction>().Where(x => x.ID == transactionID).FirstOrDefault();
            if(transaction != null)
            {
                context.Remove<Transaction>(transaction);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public IQueryable<TransactionView> Get()
        {
            var transaction = context.AsQueryable<Transaction>().Select(x => new TransactionView()
            {
                ClientID = x.Client.ID,
                ClientFirstName = x.Client.FirstName,
                ClientLastName = x.Client.LastName,
                ClientFullName = x.Client.FirstName + " " + x.Client.LastName,
                ClientAddress = x.Client.Address,
                ClientContactNumber = x.Client.ContactNumber,
                ClientImagePath = x.Client.ImagePath,
                ItemTypeID = x.ItemType.ID,
                ItemTypeDescription = x.ItemType.Description,
                ItemTypeInterest = x.ItemType.Interest,
                ItemTypePenalty = x.ItemType.Penalty,
                ItemTypeAppraiseValue = x.ItemType.AppraiseValue,
                ItemTypeWithServiceCharge = x.ItemType.WithServiceCharge,
                ItemTypeDaysToMature = x.ItemType.DaysToMature,
                ItemTypeDaysToExpire = x.ItemType.DaysToExpire,
                ItemTypeDaysToPenalty = x.ItemType.DaysToPenalty,
                AuctionDateID = x.AuctionDate.ID,
                AuctionDate = x.AuctionDate.Date,
                AuctionItemFrom = x.AuctionDate.ItemFrom,
                AuctionItemTo = x.AuctionDate.ItemTo,
                TicketTypeID = x.TicketType.ID,
                TicketType = x.TicketType.Type,
                IdTypeID = x.IdType.ID,
                IdType = x.IdType.Type,
                ID = x.ID,
                OldID = x.OldTransactionID,
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
                ModifiedDate = x.ModifiedDate,
                ProcessBy = x.ModifiedBy == null ? x.CreatedBy : x.ModifiedBy,
                ProcessDate = x.ModifiedDate == null ? x.CreatedDate : x.ModifiedDate
            }).AsQueryable();

            return transaction;
        }
        public TransactionCreateEdit Update(TransactionCreateEdit model)
        {
            var data = context.AsQueryable<Transaction>().Where(x => x.ID == model.ID).FirstOrDefault();

            data.OldTransactionID = model.OldTransactionID;
            data.ClientID = model.ClientID;
            data.ItemTypeID = model.ItemTypeID;
            data.AuctionDateID = model.AuctionDateID;
            data.IdTypeID = model.IdTypeID;
            data.TicketTypeID = model.TicketTypeID;
            data.PawnTicketNumber = model.PawnTicketNumber;
            data.TransactionType = model.TransactionType;
            data.DateLoan = model.DateLoan;
            data.DateMaturity = model.DateMaturity;
            data.DateExpiry = model.DateExpiry;
            data.DatePenalty = model.DatePenalty;
            data.DateClosed = model.DateClosed;
            data.Principal = model.Principal;
            data.Interest = model.Interest;
            data.ServiceCharge = model.ServiceCharge;
            data.Penalty = model.Penalty;
            data.AppraiseValue = model.AppraiseValue;
            data.NetProceed = model.NetProceed;
            data.Status = model.Status;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;

            context.Update<Transaction>(data);
            context.SaveChanges();

            return model;
        }
        public ComputationModel Compute(double principal, int itemTypeID)
        {
            ItemTypeService itemTypeService = new ItemTypeService();
            ItemTypeModel itemType = new ItemTypeModel();
            ComputationModel computationModel = new ComputationModel();
            itemType = itemTypeService.Get().Where(x => x.ID == itemTypeID).FirstOrDefault();

            computationModel.Interest = Math.Round(((double)principal / 100) * itemType.Interest, 2);
            computationModel.Penalty = Math.Round(((double)principal / 100) * itemType.Penalty, 2);
            computationModel.AppraiseValue = principal + Math.Round(((double)principal / 100) * itemType.AppraiseValue, 2);

            if (itemType.WithServiceCharge == "Yes")
            {
                if (principal >= Convert.ToInt32(ConfigurationManager.AppSettings["ServiceChargeHigh"].ToString()))
                {
                    computationModel.ServiceCharge = Convert.ToDouble(ConfigurationManager.AppSettings["ServiceChargeHighAmount"].ToString());
                }
                else
                {
                    computationModel.ServiceCharge = Math.Round(((double)principal / 100) * Convert.ToInt32(ConfigurationManager.AppSettings["ServiceChargeLowAmount"].ToString()), 2);
                }
            }
            else
            {
                computationModel.ServiceCharge = 0.00;
            }

            return computationModel;
        }
        public void UpdateTransactionStatus()
        {
            DateTime now = DateTime.Now;

            context.AsQueryable<Transaction>()
                   .Where(d => d.Status == "Open" && d.Status != "In Auction")
                   .ToList()
                   .ForEach(u => u.Status = 
                                     now > u.DateMaturity ? 
                                        now > u.DateExpiry ? 
                                            "Expired" : 
                                            "Matured" 
                                     : u.Status);
            context.SaveChanges();
        }

        public void UpdateTransactionStatusAuction(int auctionDateID)
        {
            DateTime now = DateTime.Now;

            context.AsQueryable<Transaction>()
                   .Where(d => d.AuctionDateID == auctionDateID && 
                               d.Status == "Expired")
                   .ToList()
                   .ForEach(u => u.Status = "In Auction");
            context.SaveChanges();
        }
    }
}

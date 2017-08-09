using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PawnSystem.BLL.Model;
using PawnSystem.BLL.IService;
using PawnSystem.DAL.Core;
using PawnSystem.DAL.Data.Entities;

namespace PawnSystem.BLL.Service
{
    public class TransactionItemService : CrudService<TransactionItemModel>, ITransactionItemService
    {
        private PawnSystemContext context;

        public TransactionItemService()
        {
            context = new PawnSystemContext();
        }

        public override TransactionItemModel Create(TransactionItemModel model)
        {

            TransactionItem data = new TransactionItem();
            data.TransactionID = model.TransactionID;
            data.Description = model.Description;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<TransactionItem>(data);
            context.SaveChanges();

            model.ID = data.ID;

            return model;
        }

        public override bool Delete(TransactionItemModel model)
        {
            bool returnValue = false;
            var data = context.AsQueryable<TransactionItem>().Where(x => x.ID == model.ID).FirstOrDefault();

            if (data != null)
            {
                context.Remove<TransactionItem>(data);
                context.SaveChanges();
                returnValue = true;
            }

            return returnValue;
        }

        public List<TransactionItemAuctionReport> generateAuctionReport(int auctionDateID)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TransactionItemModel> Get()
        {
            var transactionItem = context.AsQueryable<TransactionItem>().Select(x => new TransactionItemModel()
            {
                ID = x.ID,
                TransactionID = x.TransactionID,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate
            }).AsQueryable();

            return transactionItem;
        }

        public override TransactionItemModel Update(TransactionItemModel model)
        {
            var data = context.AsQueryable<TransactionItem>().Where(x => x.ID == model.ID).FirstOrDefault();
            data.Description = model.Description;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;

            context.Update<TransactionItem>(data);
            context.SaveChanges();

            return model;
        }
    }
}

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
    public class AuctionDateService : CrudService<AuctionDateModel>, IAuctionDateService
    {
        private PawnSystemContext context;

        public AuctionDateService()
        {
            context = new PawnSystemContext();
        }

        public override AuctionDateModel Create(AuctionDateModel model)
        {
            AuctionDate data = new AuctionDate();
            data.Date = model.Date;
            data.ItemFrom = model.ItemFrom;
            data.ItemTo = model.ItemTo;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<AuctionDate>(data);
            context.SaveChanges();

            model.ID = data.ID;
            return model;
        }

        public override bool Delete(AuctionDateModel model)
        {
            bool returnValue = false;

            var data = context.AsQueryable<AuctionDate>().Where(x => x.ID == model.ID).FirstOrDefault();
            if (data != null)
            {
                context.Remove<AuctionDate>(data);
                context.SaveChanges();
                returnValue = true;
            }

            return returnValue;
        }

        public override IQueryable<AuctionDateModel> Get()
        {
            var auctionDate = context.AsQueryable<AuctionDate>()
                                     .Select(x => new AuctionDateModel()
                                     {
                                         ID = x.ID,
                                         Date = x.Date,
                                         ItemFrom = x.ItemFrom,
                                         ItemTo = x.ItemTo,
                                         CreatedBy = x.CreatedBy,
                                         CreatedDate = x.CreatedDate,
                                         ModifiedBy = x.ModifiedBy,
                                         ModifiedDate = x.ModifiedDate
                                     }).AsQueryable();

            return auctionDate;
        }

        public override AuctionDateModel Update(AuctionDateModel model)
        {
            var data = context.AsQueryable<AuctionDate>().Where(x => x.ID == model.ID).FirstOrDefault();

            data.Date = model.Date;
            data.ItemFrom = model.ItemFrom;
            data.ItemTo = model.ItemTo;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;

            context.Update<AuctionDate>(data);
            context.SaveChanges();

            return model;
        }
    }
}

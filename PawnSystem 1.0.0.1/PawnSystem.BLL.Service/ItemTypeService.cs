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
    public class ItemTypeService : CrudService<ItemTypeModel>, IItemTypeService
    {
        private PawnSystemContext context;

        public ItemTypeService()
        {
            context = new PawnSystemContext();
        }

        public override ItemTypeModel Create(ItemTypeModel model)
        {
            ItemType data = new ItemType();
            data.Description = model.Description;
            data.Interest = model.Interest;
            data.Penalty = model.Penalty;
            data.AppraiseValue = model.AppraiseValue;
            data.WithServiceCharge = model.WithServiceCharge;
            data.DaysToMature = model.DaysToMature;
            data.DaysToExpire = model.DaysToExpire;
            data.DaysToPenalty = model.DaysToPenalty;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<ItemType>(data);
            context.SaveChanges();

            model.ID = data.ID;

            return model;
        }

        public override bool Delete(ItemTypeModel model)
        {
            bool returnValue = false;
            var data = context.AsQueryable<ItemType>().Where(x => x.ID == model.ID).FirstOrDefault();
            if(data != null)
            {
                context.Remove<ItemType>(data);
                context.SaveChanges();
                returnValue = true;
            }

            return returnValue;
        }

        public override IQueryable<ItemTypeModel> Get()
        {
            var itemType = context.AsQueryable<ItemType>().Select(x => new ItemTypeModel() {
                ID = x.ID,
                Description = x.Description,
                Interest = x.Interest,
                Penalty = x.Penalty,
                AppraiseValue = x.AppraiseValue,
                WithServiceCharge = x.WithServiceCharge,
                DaysToMature = x.DaysToMature,
                DaysToExpire = x.DaysToExpire,
                DaysToPenalty = x.DaysToPenalty,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate
            }).AsQueryable();

            return itemType;
        }

        public override ItemTypeModel Update(ItemTypeModel model)
        {
            var data = context.AsQueryable<ItemType>().Where(x => x.ID == model.ID).FirstOrDefault();
            data.Description = model.Description;
            data.Interest = model.Interest;
            data.Penalty = model.Penalty;
            data.AppraiseValue = model.AppraiseValue;
            data.WithServiceCharge = model.WithServiceCharge;
            data.DaysToMature = model.DaysToMature;
            data.DaysToExpire = model.DaysToExpire;
            data.DaysToPenalty = model.DaysToPenalty;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;

            context.Update<ItemType>(data);
            context.SaveChanges();

            return model;
        }
    }
}

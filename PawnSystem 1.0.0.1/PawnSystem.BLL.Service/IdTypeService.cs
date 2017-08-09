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
    public class IdTypeService : CrudService<IdTypeModel>
    {
        private PawnSystemContext context;

        public IdTypeService()
        {
            context = new PawnSystemContext();
        }

        public override IdTypeModel Create(IdTypeModel model)
        {
            context = new PawnSystemContext();
            IdType data = new IdType();
            data.Type = model.Type;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add(data);
            context.SaveChanges();
            model.ID = data.ID;

            return model;
        }

        public override bool Delete(IdTypeModel model)
        {
            context = new PawnSystemContext();
            bool retValue = false;

            var data = context.AsQueryable<IdType>().Where(x => x.ID == model.ID).FirstOrDefault();

            if (data != null)
            {
                context.Remove(model);
                context.SaveChanges();
                retValue = true;
            }

            return retValue;
        }

        public override IQueryable<IdTypeModel> Get()
        {

            var data = context.AsQueryable<IdType>().Select(x => new IdTypeModel()
            {
                ID = x.ID,
                Type = x.Type,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate
            }).AsQueryable();

            return data;
        }

        public override IdTypeModel Update(IdTypeModel model)
        {
            var data = context.AsQueryable<IdType>().Where(x => x.ID == model.ID).FirstOrDefault();
            data.Type = model.Type;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;
            context.Update(data);
            context.SaveChanges();

            return model;
        }
    }
}

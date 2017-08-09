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
    public class TicketTypeService : CrudService<TicketTypeModel>
    {
        private PawnSystemContext context;
        public TicketTypeService()
        {
            context = new PawnSystemContext();
        }

        public override TicketTypeModel Create(TicketTypeModel model)
        {
            TicketType data = new TicketType();

            data.Type = model.Type;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<TicketType>(data);
            context.SaveChanges();

            model.ID = data.ID;
            return model;
        }

        public override bool Delete(TicketTypeModel model)
        {
            var data = context.AsQueryable<TicketType>().Where(x => x.ID == model.ID).FirstOrDefault();
            bool returnValue = false;
            if (data != null)
            {
                context.Remove(data);
                context.SaveChanges();
                returnValue = true;
            }
            return returnValue;
        }

        public override IQueryable<TicketTypeModel> Get()
        {
            var data = context.AsQueryable<TicketType>().Select(x => new TicketTypeModel()
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

        public override TicketTypeModel Update(TicketTypeModel model)
        {
            var data = context.AsQueryable<TicketType>().Where(x => x.ID == model.ID).FirstOrDefault();
            data.Type = model.Type;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;
            context.Update<TicketType>(data);
            context.SaveChanges();
            return model;
        }
    }
}

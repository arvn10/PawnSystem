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
    public class UserTypeService : CrudService<UserTypeModel>, IUserTypeService
    {
        private PawnSystemContext context;

        public UserTypeService()
        {
            context = new PawnSystemContext();
        }


        public override UserTypeModel Create(UserTypeModel model)
        {
            UserType data = new UserType();
            data.Type = model.Type;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<UserType>(data);
            context.SaveChanges();

            model.ID = data.ID;

            return model;
        }

        public override bool Delete(UserTypeModel model)
        {
            bool returnValue = false;
            var data = context.AsQueryable<UserType>().Where(x => x.ID == model.ID).FirstOrDefault();
            if (data != null)
            {
                context.Remove<UserType>(data);
                context.SaveChanges();
                returnValue = true;
            }

            return returnValue;
        }

        public override IQueryable<UserTypeModel> Get()
        {
            var userType = context.AsQueryable<UserType>().Select(x => new UserTypeModel()
            {
                ID = x.ID,
                Type = x.Type,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate
            });

            return userType;
        }

        public override UserTypeModel Update(UserTypeModel model)
        {
            var data = context.AsQueryable<UserType>().Where(x => x.ID == model.ID).FirstOrDefault();
            data.Type = model.Type;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;

            context.Update<UserType>(data);
            context.SaveChanges();

            return model;
        }
    }
}

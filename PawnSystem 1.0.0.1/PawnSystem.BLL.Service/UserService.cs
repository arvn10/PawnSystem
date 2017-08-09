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
    public class UserService : CrudService<UserModel>, IUserService
    {
        private PawnSystemContext context;

        public UserService()
        {
            context = new PawnSystemContext();
        }

        public override UserModel Create(UserModel model)
        {
            User data = new User();
            data.UserTypeID = model.UserTypeID;
            data.UserName = model.UserName;
            data.Password = model.Password;
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Status = model.Status;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<User>(data);
            context.SaveChanges();
            model.ID = data.ID;

            return model;
        }

        public override bool Delete(UserModel model)
        {
            bool retValue = false;

            var data = context.AsQueryable<User>().Where(x => x.ID == model.ID).FirstOrDefault();
            if (data != null)
            {
                context.Remove<User>(data);
                context.SaveChanges();
                retValue = true;
            }
            return retValue;
        }

        public override IQueryable<UserModel> Get()
        {
            var user = context.AsQueryable<User>().Select(x => new UserModel
            {
                ID = x.ID,
                UserTypeID = x.UserTypeID,
                UserName = x.UserName,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Status = x.Status,
                UserType = x.UserType.Type
            }).AsQueryable();

            return user;
        }

        public UserModel Login(string userName, string password)
        {
            UserModel data = new UserModel();

            data = this.Get().AsQueryable().Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            return data;

        }

        public override UserModel Update(UserModel model)
        {
            var data = context.AsQueryable<User>().Where(x => x.ID == model.ID).FirstOrDefault();
            data.ID = model.ID;
            data.UserTypeID = model.UserTypeID;
            data.UserName = model.UserName;
            data.Password = model.Password;
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Status = model.Status;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;

            context.Update<User>(data);
            context.SaveChanges();
            return model;
        }
    }
}

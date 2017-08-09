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
    public class ClientService : CrudService<ClientModel>, IClientService
    {
        private PawnSystemContext context;

        public ClientService()
        {
            context = new PawnSystemContext();
        }

        public override ClientModel Create(ClientModel model)
        {
            Client data = new Client();
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Address = model.Address;
            data.ContactNumber = model.ContactNumber;
            data.ImagePath = model.ImagePath;
            data.CreatedBy = model.CreatedBy;
            data.CreatedDate = DateTime.Now;

            context.Add<Client>(data);
            context.SaveChanges();

            model.ID = data.ID;

            return model;
        }

        public override bool Delete(ClientModel model)
        {
            bool returnValue = false;
            var data = context.AsQueryable<Client>().Where(x => x.ID == model.ID).FirstOrDefault();

            if(data != null)
            {
                context.Remove<Client>(data);
                context.SaveChanges();
                returnValue = true;
            }

            return returnValue;
        }

        public override IQueryable<ClientModel> Get()
        {
            var client = context.AsQueryable<Client>().Select(x => new ClientModel()
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                ContactNumber = x.ContactNumber,
                ImagePath = x.ImagePath,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate
            }).AsQueryable();

            return client;
        }

        public override ClientModel Update(ClientModel model)
        {
            Client data = context.AsQueryable<Client>().Where(x => x.ID == model.ID).FirstOrDefault();
            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Address = model.Address;
            data.ContactNumber = model.ContactNumber;
            data.ImagePath = model.ImagePath;
            data.ModifiedBy = model.ModifiedBy;
            data.ModifiedDate = DateTime.Now;

            context.Update<Client>(data);
            context.SaveChanges();

            return model;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PawnSystem.BLL.Model;
using PawnSystem.BLL.Service;
using System.Collections.Generic;

namespace PawnSystem.BLL.ServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateAuctionDate()
        {
            AuctionDateModel data = new AuctionDateModel()
            {
                Date = DateTime.Now,
                ItemFrom = DateTime.Now,
                ItemTo = DateTime.Now.AddDays(7),
                CreatedBy = "",
                CreatedDate = DateTime.Now,
                ModifiedBy = "",
                ModifiedDate = DateTime.Now
            };

            AuctionDateService service = new AuctionDateService();

            service.Create(data);
        }

        [TestMethod]
        public void CreateUserType()
        {
            UserTypeModel data = new UserTypeModel();
            data.Type = "Test";
            data.CreatedBy = "";
            data.CreatedDate = DateTime.Now;

            UserTypeService service = new UserTypeService();

            service.Create(data);
        }

        [TestMethod]
        public void getItemType()
        {
            List<ItemTypeModel> data = new List<ItemTypeModel>();
            ItemTypeService service = new ItemTypeService();
            service.Get();
        }

        [TestMethod]

        public void login()
        {
            UserService service = new UserService();
            UserModel model = new UserModel();
            service.Login("admin", "password");

        }

        [TestMethod]
        public void outLedger()
        {
            ReportService service = new ReportService();
            DateTime d = new DateTime(2017, 6, 3);
            List<OutLedgerModel>list = service.GenerateOutLedger(d, d.AddDays(1));
            Console.WriteLine(list);
        }
        [TestMethod]
        public void inLedger()
        {
            ReportService service = new ReportService();
            DateTime from = new DateTime(2017, 6, 1);
            DateTime to = new DateTime(2017, 6, 30);
            service.GenerateInLedger(from, to);
        }
    }
}

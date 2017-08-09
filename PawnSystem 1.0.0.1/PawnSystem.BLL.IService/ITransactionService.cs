using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnSystem.BLL.Model;
namespace PawnSystem.BLL.IService
{
    public interface ITransactionService
    {
        TransactionCreateEdit Create(TransactionCreateEdit model);
        TransactionCreateEdit Update(TransactionCreateEdit model);
        bool Delete(int transactionID);
        IQueryable<TransactionView> Get();
        ComputationModel Compute(double principal, int itemTypeID);
        void UpdateTransactionStatus();
    }
}

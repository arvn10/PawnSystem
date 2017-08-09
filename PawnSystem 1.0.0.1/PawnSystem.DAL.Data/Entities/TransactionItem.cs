using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.DAL.Data.Entities
{
    public class TransactionItem : CreatModifyProperty
    {
        public int ID { get; set; }

        public int TransactionID { get; set; }

        public string Description { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}

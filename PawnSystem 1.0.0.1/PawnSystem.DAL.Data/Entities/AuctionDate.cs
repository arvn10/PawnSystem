using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.DAL.Data.Entities
{
    public class AuctionDate : CreatModifyProperty
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public DateTime ItemFrom { get; set; }

        public DateTime ItemTo { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

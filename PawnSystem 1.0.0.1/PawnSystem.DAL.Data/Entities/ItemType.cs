using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.DAL.Data.Entities
{
    public class ItemType : CreatModifyProperty
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public int Interest { get; set; }

        public int Penalty { get; set; }

        public int AppraiseValue { get; set; }

        public string WithServiceCharge { get; set; }

        public int DaysToMature { get; set; }

        public int DaysToPenalty { get; set; }

        public int DaysToExpire { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }

    }
}

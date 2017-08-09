using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.DAL.Data.Entities
{
    public class IdType : CreatModifyProperty
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

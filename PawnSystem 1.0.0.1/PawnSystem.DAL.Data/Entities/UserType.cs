using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.DAL.Data.Entities
{
    public class UserType : CreatModifyProperty
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}

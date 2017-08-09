using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.BLL.Model
{
    public class UserModel : CreateModifyPropertyModel
    {
        public int ID { get; set; }

        public int UserTypeID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Status { get; set; }

        public string UserType { get; set; }
    }
}

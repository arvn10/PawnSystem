using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.BLL.Model
{
    public class UserTypeModel : CreateModifyPropertyModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
}

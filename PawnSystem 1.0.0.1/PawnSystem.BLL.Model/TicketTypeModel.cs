using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnSystem.BLL.Model;
namespace PawnSystem.BLL.Model
{
    public class TicketTypeModel : CreateModifyPropertyModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }
}

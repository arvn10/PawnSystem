using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.BLL.Model
{
    public class ItemTypeModel : CreateModifyPropertyModel
    {
        public int ID { get; set; }
            
        public string Description { get; set; }

        public int Interest { get; set; }

        public int Penalty { get; set; }

        public int AppraiseValue { get; set; }

        public string WithServiceCharge { get; set; }
        
        public int DaysToMature { get; set; }

        public int DaysToExpire { get; set; }

        public int DaysToPenalty { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.BLL.Model
{
    public class ClientModel : CreateModifyPropertyModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string ImagePath { get; set; }
    }
}

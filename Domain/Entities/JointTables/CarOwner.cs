using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JointTables
{
    public class CarOwner
    {
        public int CarId { get; set; } // FK ka Car entitetu
        public Car Car { get; set; } // Navigaciono svojstvo

        public int OwnerId { get; set; } // FK ka Owner entitetu
        public Owner Owner { get; set; } // Navigaciono svojstvo
    }

}

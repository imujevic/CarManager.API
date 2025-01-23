using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; } // Jedinstveni identifikator
        public int CarId { get; set; } // FK ka Car entitetu
        public Car Car { get; set; } // Navigaciono svojstvo
        public int OwnerId { get; set; } // FK ka Owner entitetu
        public Owner Owner { get; set; } // Navigaciono svojstvo
        public int ServiceCenterId { get; set; } // FK ka ServiceCenter entitetu
        public ServiceCenter ServiceCenter { get; set; } // Navigaciono svojstvo
        public DateTime BookingDate { get; set; } // Datum rezervacije
    }
}

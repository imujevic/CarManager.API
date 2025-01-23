using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inspection
    {
        public int Id { get; set; } // Jedinstveni identifikator
        public int CarId { get; set; } // FK ka Car entitetu
        public Car Car { get; set; } // Navigaciono svojstvo
        public DateTime InspectionDate { get; set; } // Datum pregleda
        public string Result { get; set; } = string.Empty; // Rezultat pregleda
    }
}

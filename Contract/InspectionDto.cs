using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    // DTO za prikaz tehničkog pregleda
    public class InspectionDto
    {
        public int Id { get; set; } // Jedinstveni identifikator pregleda
        public int CarId { get; set; } // ID vozila
        public DateTime InspectionDate { get; set; } // Datum pregleda
        public string Result { get; set; } = string.Empty; // Rezultat pregleda
    }

    // DTO za kreiranje novog tehničkog pregleda
    public class CreateInspectionDto
    {
        public int CarId { get; set; } // ID vozila
        public DateTime InspectionDate { get; set; } // Datum pregleda
        public string Result { get; set; } = string.Empty; // Rezultat pregleda
    }

    // DTO za ažuriranje postojećeg tehničkog pregleda
    public class UpdateInspectionDto
    {
        public int CarId { get; set; } // ID vozila
        public DateTime InspectionDate { get; set; } // Datum pregleda
        public string Result { get; set; } = string.Empty; // Rezultat pregleda
    }
}


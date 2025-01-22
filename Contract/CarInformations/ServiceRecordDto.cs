namespace Contract.CarInformations
{
    // DTO za prikaz servisnog zapisa
    public class ServiceRecordDto
    {
        public int Id { get; set; } // Jedinstveni identifikator servisnog zapisa
        public int CarId { get; set; } // ID vozila
        public DateTime ServiceDate { get; set; } // Datum servisa
        public string Description { get; set; } = string.Empty; // Opis servisa
        public decimal Cost { get; set; } // Cena servisa
    }

    // DTO za kreiranje novog servisnog zapisa
    public class CreateServiceRecordDto
    {
        public int CarId { get; set; } // ID vozila
        public DateTime ServiceDate { get; set; } // Datum servisa
        public string Description { get; set; } = string.Empty; // Opis servisa
        public decimal Cost { get; set; } // Cena servisa
    }

    // DTO za ažuriranje postojećeg servisnog zapisa
    public class UpdateServiceRecordDto
    {
        public int CarId { get; set; } // ID vozila
        public DateTime ServiceDate { get; set; } // Datum servisa
        public string Description { get; set; } = string.Empty; // Opis servisa
        public decimal Cost { get; set; } // Cena servisa
    }
}

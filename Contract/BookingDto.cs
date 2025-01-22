namespace Contract
{
    // DTO za prikaz rezervacije
    public class BookingDto
    {
        public int Id { get; set; } // Jedinstveni identifikator rezervacije
        public int CarId { get; set; } // ID vozila
        public int OwnerId { get; set; } // ID vlasnika
        public DateTime BookingDate { get; set; } // Datum rezervacije
        public int ServiceCenterId { get; set; } // ID servisnog centra
    }

    // DTO za kreiranje nove rezervacije
    public class CreateBookingDto
    {
        public int CarId { get; set; } // ID vozila
        public int OwnerId { get; set; } // ID vlasnika
        public DateTime BookingDate { get; set; } // Datum rezervacije
        public int ServiceCenterId { get; set; } // ID servisnog centra
    }

    // DTO za ažuriranje postojeće rezervacije
    public class UpdateBookingDto
    {
        public int CarId { get; set; } // ID vozila
        public int OwnerId { get; set; } // ID vlasnika
        public DateTime BookingDate { get; set; } // Datum rezervacije
        public int ServiceCenterId { get; set; } // ID servisnog centra
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.CarInformations
{
    // DTO za prikaz servisnog centra
    public class ServiceCenterDto
    {
        public int Id { get; set; } // Jedinstveni identifikator servisnog centra
        public string Name { get; set; } = string.Empty; // Naziv servisnog centra
        public string Address { get; set; } = string.Empty; // Adresa servisnog centra
        public string PhoneNumber { get; set; } = string.Empty; // Kontakt telefon servisnog centra
    }

    // DTO za kreiranje novog servisnog centra
    public class CreateServiceCenterDto
    {
        public string Name { get; set; } = string.Empty; // Naziv servisnog centra
        public string Address { get; set; } = string.Empty; // Adresa servisnog centra
        public string PhoneNumber { get; set; } = string.Empty; // Kontakt telefon servisnog centra
    }

    // DTO za ažuriranje postojećeg servisnog centra
    public class UpdateServiceCenterDto
    {
        public string Name { get; set; } = string.Empty; // Naziv servisnog centra
        public string Address { get; set; } = string.Empty; // Adresa servisnog centra
        public string PhoneNumber { get; set; } = string.Empty; // Kontakt telefon servisnog centra
    }
}

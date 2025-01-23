using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServiceCenter
    {
        public int Id { get; set; } // Jedinstveni identifikator
        public string Name { get; set; } = string.Empty; // Naziv
        public string Address { get; set; } = string.Empty; // Adresa
        public string PhoneNumber { get; set; } = string.Empty; // Telefon
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Veza sa rezervacijama
    }
}

using Domain.Entities.JointTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; } // Jedinstveni identifikator
        public string FirstName { get; set; } = string.Empty; // Ime
        public string LastName { get; set; } = string.Empty; // Prezime
        public string Email { get; set; } = string.Empty; // Email
        public string PhoneNumber { get; set; } = string.Empty; // Telefon
        public ICollection<CarOwner> CarOwners { get; set; } = new List<CarOwner>(); // Veza sa automobilima
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Veza sa rezervacijama
    }
}

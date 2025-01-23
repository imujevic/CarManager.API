using Domain.Entities;
using Domain.Entities.JointTables;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain
{
    public class Car
    {
        public int Id { get; set; } // Jedinstveni identifikator
        public string Make { get; set; } = string.Empty; // Proizvođač
        public string Model { get; set; } = string.Empty; // Model
        public int Year { get; set; } // Godina proizvodnje
        public ICollection<CarOwner> CarOwners { get; set; } = new List<CarOwner>(); // Veza sa vlasnicima
        public ICollection<ServiceRecord> ServiceRecords { get; set; } = new List<ServiceRecord>(); // Veza sa servisima
        public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>(); // Veza sa pregledima
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Veza sa rezervacijama
    }
}
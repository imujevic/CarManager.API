using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }

        public ICollection<ServiceRecord> ServiceRecords { get; set; }
        public ICollection<CarOwner> CarOwners { get; set; } // Many-to-Many with Owner
        public ICollection<CarPart> CarParts { get; set; }  // Many-to-Many with Part
    }
}
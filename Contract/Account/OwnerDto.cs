using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Account
{
    // DTO za prikaz podataka o vlasniku
    public class OwnerDto
    {
        public int Id { get; set; } // Jedinstveni identifikator vlasnika
        public string FirstName { get; set; } = string.Empty; // Ime vlasnika
        public string LastName { get; set; } = string.Empty; // Prezime vlasnika
        public string Email { get; set; } = string.Empty; // Email adresa vlasnika
        public string PhoneNumber { get; set; } = string.Empty; // Broj telefona vlasnika
    }

    // DTO za kreiranje novog vlasnika
    public class CreateOwnerDto
    {
        public string FirstName { get; set; } = string.Empty; // Ime vlasnika
        public string LastName { get; set; } = string.Empty; // Prezime vlasnika
        public string Email { get; set; } = string.Empty; // Email adresa vlasnika
        public string PhoneNumber { get; set; } = string.Empty; // Broj telefona vlasnika
    }

    // DTO za ažuriranje postojećeg vlasnika
    public class UpdateOwnerDto
    {
        public string FirstName { get; set; } = string.Empty; // Ime vlasnika
        public string LastName { get; set; } = string.Empty; // Prezime vlasnika
        public string Email { get; set; } = string.Empty; // Email adresa vlasnika
        public string PhoneNumber { get; set; } = string.Empty; // Broj telefona vlasnika
    }
}

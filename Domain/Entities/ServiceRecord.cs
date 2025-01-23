using Core.Domain;
using Domain.Entities;

namespace Domain.Entities;

public class ServiceRecord
{
    public int Id { get; set; } // Jedinstveni identifikator
    public int CarId { get; set; } // FK ka Car entitetu
    public Car Car { get; set; } // Navigaciono svojstvo
    public DateTime ServiceDate { get; set; } // Datum servisa
    public string Description { get; set; } = string.Empty; // Opis servisa
    public decimal Cost { get; set; } // Cena servisa
}
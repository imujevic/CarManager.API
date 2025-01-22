namespace Contract.CarInformations;

// DTO za prikaz podataka o vozilu
public class CarDto
{
    public int Id { get; set; } // Jedinstveni identifikator
    public string Make { get; set; } = string.Empty; // Proizvođač automobila
    public string Model { get; set; } = string.Empty; // Model automobila
    public int Year { get; set; } // Godina proizvodnje
    public int OwnerId { get; set; } // ID vlasnika automobila
}

// DTO za kreiranje novog vozila
public class CreateCarDto
{
    public string Make { get; set; } = string.Empty; // Proizvođač automobila
    public string Model { get; set; } = string.Empty; // Model automobila
    public int Year { get; set; } // Godina proizvodnje
    public int OwnerId { get; set; } // ID vlasnika automobila
}

// DTO za ažuriranje postojećeg vozila
public class UpdateCarDto
{
    public string Make { get; set; } = string.Empty; // Proizvođač automobila
    public string Model { get; set; } = string.Empty; // Model automobila
    public int Year { get; set; } // Godina proizvodnje
    public int OwnerId { get; set; } // ID vlasnika automobila
}

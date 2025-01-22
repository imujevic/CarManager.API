using Domain.Models.JointTable;

namespace Domain.Models;

public class ServiceRecord
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime ServiceDate { get; set; }
    public string Description { get; set; } = string.Empty; // Opis servisa

    // Navigacione veze
    public string VehicleId { get; set; } = string.Empty;
    public Vehicle Vehicle { get; set; } = null!;
    public List<ServiceRecordPart> ServiceRecordParts { get; set; } = new List<ServiceRecordPart>();
}

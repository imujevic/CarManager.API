using Core.Domain;

namespace Domain.Models.JointTable;

public class ServiceRecordPart
{
    public string ServiceRecordId { get; set; }
    public ServiceRecord ServiceRecord { get; set; } = null!;
    public string PartId { get; set; }
    public Part Part { get; set; } = null!;
}

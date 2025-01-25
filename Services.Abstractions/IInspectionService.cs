namespace Services.Abstractions;

public interface IInspectionService
{
    Task<IEnumerable<InspectionDto>> GetAll(CancellationToken cancellationToken = default);

    Task<InspectionDto> GetById(int inspectionId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(CreateInspectionDto inspectionDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int inspectionId, UpdateInspectionDto inspectionDto, CancellationToken cancellationToken = default);

    Task Delete(int inspectionId, CancellationToken cancellationToken = default);
}

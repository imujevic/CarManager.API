using Contract.CarInformations;

namespace Services.Abstractions;

public interface IServiceCenterService
{
    Task<IEnumerable<ServiceCenterDto>> GetAll(CancellationToken cancellationToken = default);

    Task<ServiceCenterDto> GetById(int centerId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(CreateServiceCenterDto serviceCenterDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int centerId, UpdateServiceCenterDto serviceCenterDto, CancellationToken cancellationToken = default);

    Task Delete(int centerId, CancellationToken cancellationToken = default);
}

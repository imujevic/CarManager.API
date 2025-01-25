using Contract.CarInformations;

namespace Services.Abstractions;

public interface IServiceRecordService
{
    Task<IEnumerable<ServiceRecordDto>> GetAll(CancellationToken cancellationToken = default);

    Task<ServiceRecordDto> GetById(int recordId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(CreateServiceRecordDto serviceRecordDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int recordId, UpdateServiceRecordDto serviceRecordDto, CancellationToken cancellationToken = default);

    Task Delete(int recordId, CancellationToken cancellationToken = default);
}

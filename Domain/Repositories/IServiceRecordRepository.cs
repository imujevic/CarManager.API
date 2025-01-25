using Domain.Entities;

namespace Domain.Repositories;

public interface IServiceRecordRepository : IRepositoryBase<ServiceRecord>
{
    Task<IEnumerable<ServiceRecord>> GetAll(CancellationToken cancellationToken = default);

    Task<ServiceRecord> GetById(int serviceRecordId, CancellationToken cancellationToken = default);

    void CreateServiceRecord(ServiceRecord serviceRecord, CancellationToken cancellationToken = default);

    void DeleteServiceRecord(ServiceRecord serviceRecord, CancellationToken cancellationToken = default);

    void UpdateServiceRecord(ServiceRecord serviceRecord, CancellationToken cancellationToken = default);
}
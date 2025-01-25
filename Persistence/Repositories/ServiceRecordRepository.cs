using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ServiceRecordRepository(DataContext dataContext) : RepositoryBase<ServiceRecord>(dataContext), IServiceRecordRepository
{
    public void CreateServiceRecord(ServiceRecord serviceRecord, CancellationToken cancellationToken = default)
        => Create(serviceRecord);

    public void DeleteServiceRecord(ServiceRecord serviceRecord, CancellationToken cancellationToken = default)
        => Delete(serviceRecord);

    public void UpdateServiceRecord(ServiceRecord serviceRecord, CancellationToken cancellationToken = default)
        => Update(serviceRecord);

    public async Task<IEnumerable<ServiceRecord>> GetAll(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<ServiceRecord> GetById(int serviceRecordId, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(s => s.Id == serviceRecordId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}

using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ServiceCenterRepository(DataContext dataContext) : RepositoryBase<ServiceCenter>(dataContext), IServiceCenterRepository
{
    public void CreateServiceCenter(ServiceCenter serviceCenter, CancellationToken cancellationToken = default)
        => Create(serviceCenter);

    public void DeleteServiceCenter(ServiceCenter serviceCenter, CancellationToken cancellationToken = default)
        => Delete(serviceCenter);

    public void UpdateServiceCenter(ServiceCenter serviceCenter, CancellationToken cancellationToken = default)
        => Update(serviceCenter);

    public async Task<IEnumerable<ServiceCenter>> GetAll(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<ServiceCenter> GetById(int serviceCenterId, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(sc => sc.Id == serviceCenterId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}

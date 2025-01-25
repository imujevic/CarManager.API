using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class OwnerRepository(DataContext dataContext) : RepositoryBase<Owner>(dataContext), IOwnerRepository
{
    public void CreateOwner(Owner owner, CancellationToken cancellationToken = default)
        => Create(owner);

    public void DeleteOwner(Owner owner, CancellationToken cancellationToken = default)
        => Delete(owner);

    public void UpdateOwner(Owner owner, CancellationToken cancellationToken = default)
        => Update(owner);

    public async Task<IEnumerable<Owner>> GetAll(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<Owner> GetById(int ownerId, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(o => o.Id == ownerId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}

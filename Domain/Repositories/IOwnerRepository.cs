using Domain.Entities;

namespace Domain.Repositories;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    Task<IEnumerable<Owner>> GetAll(CancellationToken cancellationToken = default);

    Task<Owner> GetById(int ownerId, CancellationToken cancellationToken = default);

    void CreateOwner(Owner owner, CancellationToken cancellationToken = default);

    void DeleteOwner(Owner owner, CancellationToken cancellationToken = default);

    void UpdateOwner(Owner owner, CancellationToken cancellationToken = default);
}
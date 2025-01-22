using Domain.Entities;

namespace Domain.Repositories;

public interface IAccountRepository : IRepositoryBase<Car>
{
    Task<IEnumerable<Car>> GetAll(CancellationToken cancellationToken = default);

    Task<Car> GetById(string accountId, CancellationToken cancellationToken = default);
}
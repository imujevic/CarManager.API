using Core.Domain;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CarRepository(DataContext dataContext) : RepositoryBase<Car>(dataContext), ICarRepository
{
    public void CreateCar(Car car, CancellationToken cancellationToken = default)
        => Create(car);

    public void DeleteCar(Car car, CancellationToken cancellationToken = default)
        => Delete(car);

    public void UpdateCar(Car car, CancellationToken cancellationToken = default)
        => Update(car);

    public async Task<IEnumerable<Car>> GetAll(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<Car> GetById(int carId, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(c => c.Id == carId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}

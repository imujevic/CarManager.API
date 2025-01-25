using Core.Domain;
using Domain.Entities;

namespace Domain.Repositories;

public interface ICarRepository : IRepositoryBase<Car>
{
    Task<IEnumerable<Car>> GetAll(CancellationToken cancellationToken = default);

    Task<Car> GetById(int carId, CancellationToken cancellationToken = default);

    void CreateCar(Car car, CancellationToken cancellationToken = default);

    void DeleteCar(Car car, CancellationToken cancellationToken = default);

    void UpdateCar(Car car, CancellationToken cancellationToken = default);
}
namespace Services.Abstractions;
using Contract.CarInformations;
public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAll(CancellationToken cancellationToken = default);

    Task<CarDto> GetById(int carId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(CreateCarDto carDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(int carId, UpdateCarDto carDto, CancellationToken cancellationToken = default);

    Task Delete(int carId, CancellationToken cancellationToken = default);
}

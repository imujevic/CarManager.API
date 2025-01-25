using Microsoft.AspNetCore.Cors.Infrastructure;
using Contract.CarInformations;
using Core.Domain;

namespace Services
{
    public class CarService(IRepositoryManager repositoryManager) : ICarService
    {
        public async Task<GeneralResponseDto> Create(CreateCarDto carDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var car = carDto.Adapt<Car>();
                repositoryManager.CarRepository.CreateCar(car);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task Delete(int carId, CancellationToken cancellationToken = default)
        {
            var car = await repositoryManager.CarRepository.GetById(carId, cancellationToken);
            repositoryManager.CarRepository.DeleteCar(car, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<CarDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var cars = await repositoryManager.CarRepository.GetAll(cancellationToken);
            return cars.Adapt<IEnumerable<CarDto>>();
        }

        public async Task<CarDto> GetById(int carId, CancellationToken cancellationToken = default)
        {
            var car = await repositoryManager.CarRepository.GetById(carId, cancellationToken);
            return car.Adapt<CarDto>();
        }

        public async Task<GeneralResponseDto> Update(int carId, UpdateCarDto carDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingCar = await repositoryManager.CarRepository.GetById(carId, cancellationToken);
                if (existingCar == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Car not found." };

                carDto.Adapt(existingCar);

                repositoryManager.CarRepository.UpdateCar(existingCar);
                var res = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (res != 1)
                    return new GeneralResponseDto { IsSuccess = false };

                return new GeneralResponseDto { Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}

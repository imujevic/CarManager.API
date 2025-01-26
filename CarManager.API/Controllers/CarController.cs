using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Contract.CarInformations;

namespace StorageManagement.API.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCars(CancellationToken cancellationToken)
        {
            var response = await serviceManager.CarService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarById(int carId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.CarService.GetById(carId, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarDto carDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.CarService.Create(carDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{carId}")]
        public async Task<IActionResult> UpdateCar(int carId, [FromBody] UpdateCarDto carDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.CarService.Update(carId, carDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{carId}")]
        public async Task<IActionResult> DeleteCar(int carId, CancellationToken cancellationToken)
        {
            await serviceManager.CarService.Delete(carId, cancellationToken);
            return NoContent();
        }
    }
}

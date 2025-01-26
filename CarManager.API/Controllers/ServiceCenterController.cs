using Contract.CarInformations;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace StorageManagement.API.Controllers
{
    [ApiController]
    [Route("api/service-centers")]
    public class ServiceCenterController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllServiceCenters(CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceCenterService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{serviceCenterId}")]
        public async Task<IActionResult> GetServiceCenterById(int serviceCenterId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceCenterService.GetById(serviceCenterId, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceCenter([FromBody] CreateServiceCenterDto serviceCenterDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceCenterService.Create(serviceCenterDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{serviceCenterId}")]
        public async Task<IActionResult> UpdateServiceCenter(int serviceCenterId, [FromBody] UpdateServiceCenterDto serviceCenterDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceCenterService.Update(serviceCenterId, serviceCenterDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{serviceCenterId}")]
        public async Task<IActionResult> DeleteServiceCenter(int serviceCenterId, CancellationToken cancellationToken)
        {
            await serviceManager.ServiceCenterService.Delete(serviceCenterId, cancellationToken);
            return NoContent();
        }
    }
}

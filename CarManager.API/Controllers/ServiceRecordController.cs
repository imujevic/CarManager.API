using Contract.CarInformations;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace StorageManagement.API.Controllers
{
    [ApiController]
    [Route("api/service-records")]
    public class ServiceRecordController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllServiceRecords(CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceRecordService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{recordId}")]
        public async Task<IActionResult> GetServiceRecordById(int recordId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceRecordService.GetById(recordId, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceRecord([FromBody] CreateServiceRecordDto recordDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceRecordService.Create(recordDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{recordId}")]
        public async Task<IActionResult> UpdateServiceRecord(int recordId, [FromBody] UpdateServiceRecordDto recordDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.ServiceRecordService.Update(recordId, recordDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{recordId}")]
        public async Task<IActionResult> DeleteServiceRecord(int recordId, CancellationToken cancellationToken)
        {
            await serviceManager.ServiceRecordService.Delete(recordId, cancellationToken);
            return NoContent();
        }
    }
}

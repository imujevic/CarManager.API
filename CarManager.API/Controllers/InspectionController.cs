using Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace StorageManagement.API.Controllers
{
    [ApiController]
    [Route("api/inspections")]
    public class InspectionController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllInspections(CancellationToken cancellationToken)
        {
            var response = await serviceManager.InspectionService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{inspectionId}")]
        public async Task<IActionResult> GetInspectionById(int inspectionId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.InspectionService.GetById(inspectionId, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInspection([FromBody] CreateInspectionDto inspectionDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.InspectionService.Create(inspectionDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{inspectionId}")]
        public async Task<IActionResult> UpdateInspection(int inspectionId, [FromBody] UpdateInspectionDto inspectionDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.InspectionService.Update(inspectionId, inspectionDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{inspectionId}")]
        public async Task<IActionResult> DeleteInspection(int inspectionId, CancellationToken cancellationToken)
        {
            await serviceManager.InspectionService.Delete(inspectionId, cancellationToken);
            return NoContent();
        }
    }
}

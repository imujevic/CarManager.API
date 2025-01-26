using Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace StorageManagement.API.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnerController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOwners(CancellationToken cancellationToken)
        {
            var response = await serviceManager.OwnerService.GetAll(cancellationToken);
            return Ok(response);
        }

        [HttpGet("{ownerId}")]
        public async Task<IActionResult> GetOwnerById(int ownerId, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OwnerService.GetById(ownerId, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] CreateOwnerDto ownerDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OwnerService.Create(ownerDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{ownerId}")]
        public async Task<IActionResult> UpdateOwner(int ownerId, [FromBody] UpdateOwnerDto ownerDto, CancellationToken cancellationToken)
        {
            var response = await serviceManager.OwnerService.Update(ownerId, ownerDto, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{ownerId}")]
        public async Task<IActionResult> DeleteOwner(int ownerId, CancellationToken cancellationToken)
        {
            await serviceManager.OwnerService.Delete(ownerId, cancellationToken);
            return NoContent();
        }
    }
}

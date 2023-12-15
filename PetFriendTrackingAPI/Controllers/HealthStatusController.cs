using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/healthstatus")]
public class HealthStatusController : ControllerBase
{
    private readonly IHealthStatusService _healthStatusService;

    public HealthStatusController(IHealthStatusService healthStatusService)
    {
        _healthStatusService = healthStatusService;
    }
    
    // GET: api/v1/healthstatus/{petAnimalId}
    [HttpGet("{petAnimalId}")]
    public async Task<ActionResult<GetHealthStatusDTO>> Get(int petAnimalId)
    {
        try
        {
            // Retrieve health status information for the specified pet animal ID.
            var healthStatus = await _healthStatusService.GetByIdAsync(petAnimalId);

            if (healthStatus == null)
                return NotFound();

            return Ok(healthStatus);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // POST: api/v1/healthstatus
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] PostHealthStatusDTO healthStatusDto)
    {
        try
        {
            // Add a new health status entry based on the provided data.
            await _healthStatusService.AdduAsync(healthStatusDto);
            return Ok("Created");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // PATCH: api/v1/healthstatus/{petAnimalId}
    [HttpPatch("{petAnimalId}")]
    public async Task<ActionResult> Patch(int petAnimalId, [FromBody] PatchHealthStatusDTO healthStatus)
    {
        try
        {
            // Update the health status for the specified pet animal ID with the provided data.
            await _healthStatusService.UpdateAsync(petAnimalId, healthStatus);
            return Ok("Updated.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
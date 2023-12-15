using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[Route("api/v1/activities")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }
    
    // Endpoint to get all activities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetActivityDTO>>> Get()
    {
        try
        {
            var activities = await _activityService.GetAllAsync();
            return Ok(activities);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Endpoint to get activities by pet animal ID
    [HttpGet("{petAnimalId}")]
    public async Task<ActionResult<GetActivityDTO>> GetByPetAnimalId(int evcilHayvanId)
    {
        try
        {
            var activities = await _activityService.GetByPetAnimalIdAsync(evcilHayvanId);
            return Ok(activities);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Endpoint to add a new activity
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostActivityDTO activity)
    {
        try
        {
            await _activityService.AddAsync(activity);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Endpoint to delete an activity by ID
    [HttpDelete("{activityId}")]
    public async Task<ActionResult> DeleteAktivite(int activityId)
    {
        try
        {
            await _activityService.RemoveAsync(activityId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
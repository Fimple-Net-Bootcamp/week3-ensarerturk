using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/foods")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetFoodDTO>>> GetAll()
    {
        try
        {
            // Retrieve all foods from the service and return as an OK response.
            var foods = await _foodService.GetAllAsync();
            return Ok(foods);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("{foodId}")]
    public async Task<ActionResult<GetFoodDTO>> GetById(int foodId)
    {
        try
        {
            // Retrieve a specific food by ID from the service and return as an OK response.
            var food = await _foodService.GetByIdAsync(foodId);

            if (food == null)
                return NotFound();

            return Ok(food);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostFoodDTO food)
    {
        try
        {
            // Add a new food using the service and return an OK response.
            await _foodService.AddAsync(food);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("giveFoods/{petAnimalId}")]
    public async Task<ActionResult> GiveFood(int petAnimalId, string foodName)
    {
        try
        {
            // Feed a pet with the specified food using the service and return an OK response.
            await _foodService.GiveFoodAsync(petAnimalId, foodName);
            return Ok("Your pet was successfully fed.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut("{foodId}")]
    public async Task<ActionResult> Put(int foodId, [FromBody] PostFoodDTO besin)
    {
        try
        {
            // Update an existing food using the service and return an OK response.
            await _foodService.UpdateAsync(besin);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{foodId}")]
    public async Task<ActionResult> DeleteBesin(int foodId)
    {
        try
        {
            // Remove a specific food by ID using the service and return an OK response.
            await _foodService.RemoveAsync(foodId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
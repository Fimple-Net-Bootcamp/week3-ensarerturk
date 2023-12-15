using Microsoft.AspNetCore.Mvc;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Controllers;

[ApiController]
[Route("api/v1/petAnimals")]
public class PetAnimalController : ControllerBase
{
    private readonly IPetAnimalService _petAnimalService;

    public PetAnimalController(IPetAnimalService petAnimalService)
    {
        _petAnimalService = petAnimalService;
    }
    
    // Endpoint to get all pet animals.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetPetAnimalDTO>>> GetAll()
    {
        try
        {
            // Call the service to get all pet animals asynchronously.
            var petAnimals = await _petAnimalService.GetAllEAsync();
            return Ok(petAnimals);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Endpoint to get a specific pet animal by its identifier.
    [HttpGet("{petAnimalId}")]
    public async Task<ActionResult<GetPetAnimalDTO>> GetById(int petAnimalId)
    {
        try
        {
            // Call the service to get a specific pet animal by its identifier asynchronously.
            var petAnimal = await _petAnimalService.GetByIdAsync(petAnimalId);

            if (petAnimal == null)
                return NotFound();

            return Ok(petAnimal);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Endpoint to add a new pet animal.
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PostPetAnimalDTO petAnimalDto)
    {
        try
        {
            // Call the service to add a new pet animal asynchronously.
            await _petAnimalService.AddAsync(petAnimalDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Endpoint to update an existing pet animal.
    [HttpPut("{petAnimalId}")]
    public async Task<ActionResult> PutEvcilHayvan(int petAnimalId, [FromBody] PostPetAnimalDTO petAnimalDto)
    {
        try
        {
            // Call the service to update an existing pet animal asynchronously.
            await _petAnimalService.UpdatenAsync(petAnimalId, petAnimalDto);
            return Ok("Created.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    // Endpoint to delete a pet animal by its identifier.
    [HttpDelete("{petAnimalId}")]
    public async Task<ActionResult> Delete(int petAnimalId)
    {
        try
        {
            // Call the service to remove a pet animal by its identifier asynchronously.
            await _petAnimalService.RemoveAsync(petAnimalId);
            return Ok("Deleted.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
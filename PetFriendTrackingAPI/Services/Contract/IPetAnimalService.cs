using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

// IPetAnimalService interface defines the contract for operations related to pet animals.
public interface IPetAnimalService
{
    // Get all pet animals asynchronously.
    Task<IEnumerable<GetPetAnimalDTO>> GetAllEAsync();
    // Get a specific pet animal by its identifier asynchronously.
    Task<GetPetAnimalDTO> GetByIdAsync(int petAnimalId);
    // Add a new pet animal asynchronously.
    Task AddAsync(PostPetAnimalDTO petAnimalDTO);
    // Update an existing pet animal asynchronously.
    Task UpdatenAsync(int petAnimalId, PostPetAnimalDTO petAnimalDTO);
    // Remove a pet animal by its identifier asynchronously.
    Task RemoveAsync(int petAnimalId);
}
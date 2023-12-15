using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

// IPetAnimalRepository interface defines the contract for operations related to pet animal entities in the data layer.
public interface IPetAnimalRepository
{
    // Get all pet animals asynchronously.
    Task<IEnumerable<PetAnimal>> GetAllAsync();
    // Get a specific pet animal by its identifier asynchronously.
    Task<PetAnimal> GetByIdAsync(int petAnimalId);
    // Add a new pet animal asynchronously.
    Task AddAsync(PetAnimal petAnimal);
    // Update an existing pet animal asynchronously.
    Task UpdateAsync(int petAnimalId, PetAnimal petAnimal);
    // Remove a pet animal by its identifier asynchronously.
    Task RemoveAsync(int petAnimalId);
}
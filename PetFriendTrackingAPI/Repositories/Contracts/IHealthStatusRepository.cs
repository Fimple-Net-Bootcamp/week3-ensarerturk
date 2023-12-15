using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Repositories.Contracts;

// This interface defines the contract for health status repository operations.
public interface IHealthStatusRepository
{
    // Retrieves health status information by its unique identifier asynchronously.
    Task<HealthStatus> GetByIdAsync(int healthStatusId);
    // Adds a new health status entry asynchronously based on the provided data.
    Task AddSAsync(HealthStatus healthStatus);
    // Updates an existing health status entry for a given pet animal asynchronously.
    Task UpdateAsync(int petAnimalId, HealthStatus healthStatus);
}

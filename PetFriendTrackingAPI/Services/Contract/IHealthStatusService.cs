using PetFriendTrackingAPI.DTO;

namespace PetFriendTrackingAPI.Services.Contract;

// This interface defines the contract for health status-related operations.
public interface IHealthStatusService
{
    // Retrieves health status information based on its unique identifier asynchronously.
    Task<GetHealthStatusDTO> GetByIdAsync(int healthStatusId);
    // Adds a new health status entry asynchronously based on the provided data.
    Task AdduAsync(PostHealthStatusDTO healthStatus);
    // Updates an existing health status entry for a given pet animal asynchronously.
    Task UpdateAsync(int petAnimalId, PatchHealthStatusDTO healthStatus);
}
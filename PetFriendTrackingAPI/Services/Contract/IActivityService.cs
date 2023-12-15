using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Services.Contract;

// IActivityService interface defines the contract for activity-related operations.
public interface IActivityService
{
    // Get all activities asynchronously.
    Task<IEnumerable<GetActivityDTO>> GetAllAsync();
    // Get activities by pet animal ID asynchronously.
    Task<GetActivityDTO> GetByPetAnimalIdAsync(int petAnimalId);
    // Add a new activity asynchronously.
    Task AddAsync(PostActivityDTO activity);
    // Remove an activity by ID asynchronously.
    Task RemoveAsync(int activityId);
}
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Services.Contract;

// Service interface for managing food-related operations.
public interface IFoodService
{
    // Get all available foods.
    Task<IEnumerable<GetFoodDTO>> GetAllAsync();
    // Get a specific food by ID.
    Task<GetFoodDTO> GetByIdAsync(int foodId);
    // Add a new food.
    Task AddAsync(PostFoodDTO besin);
    // Feed a pet with a specific food.
    Task GiveFoodAsync(int petAnimalId, string foodName);
    // Update an existing food.
    Task UpdateAsync(PostFoodDTO food);
    // Remove a specific food by ID.
    Task RemoveAsync(int foodId);
}
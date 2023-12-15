using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;

    public FoodService(IFoodRepository foodRepository, IMapper mapper)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
    }

    // Retrieve all available foods.
    public async Task<IEnumerable<GetFoodDTO>> GetAllAsync()
    {
        var foods = await _foodRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetFoodDTO>>(foods);
    }

    // Get a specific food by ID.
    public async Task<GetFoodDTO> GetByIdAsync(int foodId)
    {
        var foods = await _foodRepository.GetnByIdAsync(foodId);
        return _mapper.Map<GetFoodDTO>(foods);
    }

    // Add a new food.
    public async Task AddAsync(PostFoodDTO besin)
    {
        var foods = _mapper.Map<Food>(besin);
        await _foodRepository.AddAsync(foods);
    }

    // Feed a pet with a specific food.
    public async Task GiveFoodAsync(int petAnimalId, string foodName)
    {
        await _foodRepository.GiveFoodAsync(petAnimalId, foodName);
    }

    // Update an existing food.
    public async Task UpdateAsync(PostFoodDTO foodDTO)
    {
        var food = _mapper.Map<Food>(foodDTO);
        await _foodRepository.UpdateAsync(food);
    }

    // Remove a specific food by ID.
    public async Task RemoveAsync(int foodId)
    {
        await _foodRepository.RemoveAsync(foodId);
    }
}
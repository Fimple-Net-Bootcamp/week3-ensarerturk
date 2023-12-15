using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;

    public ActivityService(IActivityRepository activityRepository, IMapper mapper)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
    }

    // GetAllAsync method retrieves all activities from the repository.
    public async Task<IEnumerable<GetActivityDTO>> GetAllAsync()
    {
        var activities = await _activityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetActivityDTO>>(activities);
    }

    // GetByPetAnimalIdAsync method retrieves activities by pet animal Id from the repository.
    public async Task<GetActivityDTO> GetByPetAnimalIdAsync(int petAnimalId)
    {
        var petAnimal = await _activityRepository.GetByPetAnimalIdAsync(petAnimalId);
        return _mapper.Map<GetActivityDTO>(petAnimal);
    }

    // AddAsync method adds a new activity to the repository.
    public async Task AddAsync(PostActivityDTO activity)
    {
        var activities = _mapper.Map<Activity>(activity);
        await _activityRepository.AddAsync(activities);
    }
    
    // RemoveAsync method removes an activity by Id from the repository.
    public async Task RemoveAsync(int activityId)
    {
        await _activityRepository.RemoveAsync(activityId);
    }
}
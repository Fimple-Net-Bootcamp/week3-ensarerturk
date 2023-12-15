using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

// This class implements the IHealthStatusService interface, providing functionality for health status operations.
public class HealthStatusService : IHealthStatusService
{
    private readonly IHealthStatusRepository _healthStatusRepository;
    private readonly IMapper _mapper;

    // Initializes a new instance of the HealthStatusService class.
    public HealthStatusService(IHealthStatusRepository healthStatusRepository, IMapper mapper)
    {
        _healthStatusRepository = healthStatusRepository;
        _mapper = mapper;
    }

    // Retrieves health status information by its unique identifier asynchronously.
    public async Task<GetHealthStatusDTO> GetByIdAsync(int healthStatusId)
    {
        var healthStatus = await _healthStatusRepository.GetByIdAsync(healthStatusId);
        return _mapper.Map<GetHealthStatusDTO>(healthStatus);
    }

    // Adds a new health status entry based on the provided data asynchronously.
    public async Task AdduAsync(PostHealthStatusDTO healthStatus)
    {
        var saglikDurumu = _mapper.Map<HealthStatus>(healthStatus);
        await _healthStatusRepository.AddSAsync(saglikDurumu);
    }

    // Updates an existing health status entry for a given pet animal asynchronously.
    public async Task UpdateAsync(int petAnimalId, PatchHealthStatusDTO healthStatusDTO)
    {
        var healthStatus = _mapper.Map<HealthStatus>(healthStatusDTO);
        await _healthStatusRepository.UpdateAsync(petAnimalId, healthStatus);
    }
}
using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

// PetAnimalService class implements the IPetAnimalService interface.
public class PetAnimalService : IPetAnimalService
{
    private readonly IPetAnimalRepository _petAnimalRepository;
    private readonly IMapper _mapper;

    // Constructor to inject dependencies: IPetAnimalRepository and IMapper.
    public PetAnimalService(IPetAnimalRepository petAnimalRepository, IMapper mapper)
    {
        _petAnimalRepository = petAnimalRepository;
        _mapper = mapper;
    }

    // Get all pet animals asynchronously.
    public async Task<IEnumerable<GetPetAnimalDTO>> GetAllEAsync()
    {
        // Call the repository to get all pet animals and map the results to DTOs.
        var petAnimals = await _petAnimalRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetPetAnimalDTO>>(petAnimals);
    }

    // Get a specific pet animal by its identifier asynchronously.
    public async Task<GetPetAnimalDTO> GetByIdAsync(int petAnimalId)
    {
        // Call the repository to get a specific pet animal by its identifier.
        var petAnimal = await _petAnimalRepository.GetByIdAsync(petAnimalId);
        return _mapper.Map<GetPetAnimalDTO>(petAnimal);
    }

    // Add a new pet animal asynchronously.
    public async Task AddAsync(PostPetAnimalDTO petAnimalDTO)
    {
        // Map the DTO to the entity and call the repository to add the new pet animal.
        var petAnimal = _mapper.Map<PetAnimal>(petAnimalDTO);
        await _petAnimalRepository.AddAsync(petAnimal);
    }

    // Update an existing pet animal asynchronously.
    public async Task UpdatenAsync(int petAnimalId, PostPetAnimalDTO petAnimalDTO)
    {
        // Map the DTO to the entity and call the repository to update the existing pet animal.
        var evcilHayvan = _mapper.Map<PetAnimal>(petAnimalDTO);
        await _petAnimalRepository.UpdateAsync(petAnimalId, evcilHayvan);
    }

    // Remove a pet animal by its identifier asynchronously.
    public async Task RemoveAsync(int petAnimalId)
    {
        // Call the repository to remove a pet animal by its identifier.
        await _petAnimalRepository.RemoveAsync(petAnimalId);
    }
}
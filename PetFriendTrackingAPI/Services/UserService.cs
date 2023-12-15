using AutoMapper;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services.Contract;

namespace PetFriendTrackingAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    // Constructor with dependency injection
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        // Initializes the dependencies
        _userRepository = userRepository;
        _mapper = mapper;
    }

    // Asynchronously retrieves all users
    public async Task<IEnumerable<GetUserDTO>> GetAllAsync()
    {
        // Retrieves all users from the repository
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetUserDTO>>(users);
    }

    // Asynchronously retrieves a user by Id
    public async Task<GetUserDTO> GetByIdAsync(int userId)
    {
        // Retrieves a user by Id from the repository
        var user = await _userRepository.GetByIdAsync(userId);
        return _mapper.Map<GetUserDTO>(user);
    }

    // Asynchronously adds a new user
    public async Task AddAsync(PostUserDTO user)
    {
        // Maps the DTO to the entity and adds it to the repository
        var mappedUser = _mapper.Map<User>(user);
        await _userRepository.AddAsync(mappedUser);
    }

    // Asynchronously removes a user by Id
    public async Task RemoveAsync(int userId)
    {
        await _userRepository.RemoveAsync(userId);
    }
}
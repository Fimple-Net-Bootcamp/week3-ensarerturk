using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PetFriendTrackingAPI.DTO;
using PetFriendTrackingAPI.Entities;

namespace PetFriendTrackingAPI.Mapper;

/*
 * The PetAPIMapper class is responsible for configuring AutoMapper profiles
 * to map between entity and DTO objects in the Pet Friend Tracking API.
 */
public class PetAPIMapper : Profile
{
    // Initializes a new instance of the PetAPIMapper class and defines mapping configurations.
    public PetAPIMapper()
    {
        CreateMap<Activity, GetActivityDTO>().ReverseMap();
        CreateMap<Activity, PostActivityDTO>().ReverseMap();
        
        CreateMap<Food, GetFoodDTO>().ReverseMap();
        CreateMap<Food, PostFoodDTO>().ReverseMap();

        CreateMap<HealthStatus, GetHealthStatusDTO>().ReverseMap();
        CreateMap<HealthStatus, PostHealthStatusDTO>().ReverseMap();
        CreateMap<HealthStatus, PatchHealthStatusDTO>().ReverseMap();

        CreateMap<PetAnimal, GetPetAnimalDTO>().ReverseMap();
        CreateMap<PetAnimal, PostPetAnimalDTO>().ReverseMap();

        CreateMap<User, GetUserDTO>().ReverseMap();
        CreateMap<User, PostUserDTO>().ReverseMap();

        CreateMap<PetAnimalFood, PetAnimalFoodDTO>().ReverseMap();
    }
}
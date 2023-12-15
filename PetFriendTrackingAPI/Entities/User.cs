namespace PetFriendTrackingAPI.Entities;

public class User
{
    // Unique identifier for the user
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    // Navigation property representing the list of pet animals associated with the user
    public virtual List<PetAnimal> PetAnimals { get; set; }
}
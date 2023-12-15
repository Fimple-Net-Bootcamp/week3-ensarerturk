# Pet Friend Tracking API

Pet Friend Tracking API is a RESTful API for tracking pet health, activity, food consumption and more. The API is designed in accordance with object-oriented programming (OOP) and SOLID principles. Data storage and management is provided using PostgreSQL database. The AutoMapper library facilitates data transfer between data transfer objects (DTO) and object mapping. These features contribute to making the code readable, maintainable and modifiable, but also make it possible to adapt more flexibly to changes in the system.

## ## Project Structer

- **Controllers:** Contains controller classes that manage API endpoints.
- - **ActivityController:** Includes API endpoints related to activities.
- - **FoodController:**  Contains API endpoints related to nutrients.
- - **HealthStatusController:**  Contains API endpoints related to health status.
- - **PetAnimalController:** Contains API endpoints related to pets.
- - **UserController:** Contains API endpoints related to users.

- **DTO (Data Transfer Objects):** Contains data transfer classes used to transmit or receive data to and from clients.
- - **GetActivityDTO:** DTO class used to get activity information.
- - **PostActivityDTO:**  DTO class used to add a new activity. 
- - **GetFoodDTO:**  DTO class used to retrieve nutritional information.
- - **PostFoodDTO:** DTO class used to add a new food.
- - **GetHealthStatusDTO:** DTO class used to retrieve health status information.
- - **PostHealthStatusDTO:** DTO class for adding a new health status.
- - **PatchHealthStatusDTO:** DTO class used to update the current health status.
- - **GetPetAnimalDTO:** DTO class used to retrieve pet information.
- - **PostPetAnimalDTO:** DTO class used to add a new pet.
- - **GetUserDTO:** DTO class used to retrieve user information.
- - **PostUserDTO:**  DTO class used to add a new user.
- - **PetAnimalFoodDTO:**  DTO class used to get the pet's food information.

- **Entities:** Contains the basic entity classes that represent database tables.
- - **Activity:** Represents the activity table.
- - **Food:** Represents the nutrient table.
- - **HealthStatus:** Represents the health status table.
- - **PetAnimal:** Represents the pet table.
- - **User:** Represents the user table.
- - **PetAnimalFood:** Represents the food consumed by pets.

- **Repositories:** Contains repository classes that manage database operations.
- - **ActivityRepository:** Implements from the IActivityRepository. Manages activity database operations.
- - **FoodRepository:** Implements from the IFoodRepository. Manages nutrient database operations.
- - **HealthStatusRepository:** Implements from the IHealthStatusRepository. Manages health status database operations.
- - **PetAnimalRepository:** Implements from the IPetAnimalRepository. Manages pet database operations.
- - **UserRepository:** Implements from the IUserRepository. Manages user database operations.
- - **PetAnimalFoodRepository:** Implements from the IPetAnimalFoodRepository. Manages the food consumed by pets.

- **Services:** Contains service classes that manage business logic.
- - **ActivityService:** Implements from the IActivityService. Manages the business logic of activity operations.
- - **FoodService:** Implements from the IFoodService. Manages the business logic of food operations.
- - **HealthStatusService:** Implements from the IHealthStatusService.Manages the business logic of health status operations.
- - **PetAnimalService:** Implements from the IPetAnimalService. Manages the business logic of pet operations.
- - **UserService:** Implements from the IUserService. Manages the business logic of user operations.

- **Mapper:** Contains the AutoMapper configuration that manages transformations between DTO and Entity classes.
- - **PetAPIMapper:** Manages transformations between Entity and DTO classes.

- **DBOperations:** Contains database connection and configuration.
- - **PetDbContext:** Manages database operations with Entity Framework.

## API Endpoints

**Activity Related Endpoints (ActivityController):**

- `GET /api/v1/activities:` Gets all activities.
- `GET /api/v1/activities/{petAnimalId}:` The pet receives activities according to its identity.
- `POST /api/v1/activities:` Adds a new activity.
- `DELETE /api/v1/v1/activities/{activityId}:` Deletes a specific activity.

**Food-related Endpoints (FoodController):**

- `GET /api/v1/foods:` Gets all foods.
- `GET /api/v1/foods/{foodId}:` Gets a specific food.
- `POST /api/v1/foods:` Adds a new food.
- `POST /api/v1/foods:` The pet with the given Id is given food with the desired food name.
- `PUT /api/v1/foods/giveFoods/{petAnimalId}:` Updates a specific food.
- `DELETE /api/v1/foods/{foodId}:` Deletes a specific food.

**Health Status Related Endpoints (HealthStatusController):**

- `GET /api/v1/healthstatus/{petAnimalId}:` Gets the health status of a specific pet.
- `POST /api/v1/healthstatus:` Adds a new health status.
- `PATCH /api/v1/v1/healthstatus/{petAnimalId}:` Updates the health status of a specific pet.

**Pet-related Endpoints (PetAnimalController):**

- `GET /api/v1/petAnimals:` Fetches all pets.
- `GET /api/v1/v1/petAnimals/{petAnimalId}:` Retrieves a specific pet.
- `POST /api/v1/petAnimals:` Adds a new pet.
- `PUT /api/v1/petAnimals/{petAnimalId}:` Updates a specific pet.
- `DELETE /api/v1/petAnimals/{petAnimalId}:` Deletes a specific pet.

**User Related Endpoints (UserController):**

- `GET /api/v1/users:` Gets all users.
- `GET /api/v1/users/{userId}:` Retrieves a specific user.
- `POST /api/v1/users:` Adds a new user.
- `PUT /api/v1/users/{userId}:` Updates a specific user.
- `DELETE /api/v1/users/{userId}:` Deletes a specific user.
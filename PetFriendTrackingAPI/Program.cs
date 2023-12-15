using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Mapper;
using PetFriendTrackingAPI.Repositories;
using PetFriendTrackingAPI.Repositories.Contracts;
using PetFriendTrackingAPI.Services;
using PetFriendTrackingAPI.Services.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IPetAnimalService, PetAnimalService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHealthStatusService, HealthStatusService>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IPetAnimalRepository, PetAnimalRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHealthStatusRepository, HealthStatusRepository>();

builder.Services.AddAutoMapper(typeof(PetAPIMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

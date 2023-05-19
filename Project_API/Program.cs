using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_API.Common.Behaviours;
using Project_API.Domain;
using Project_API.Domain.Abstract;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<User_ID, Guid>());
        options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<Animal_ID, Guid>());
        options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<ShelteredAnimal_ID, Guid>());
        options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<AnimalShelter_ID, Guid>());
        options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<UserAnimalId, Guid>());
        options.JsonSerializerOptions.Converters.Add(new StronglyTypedIdJsonConverter<Client_ID, Guid>());
      
    });
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
    //    options.SerializerSettings.Converters.Add(new StronglyTypedIdNewtonsoftJsonConverter());
    });
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
    builder.Services.AddScoped<IAnimalShelterRepository, AnimalShelterRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IAdoptionUoW, AdoptionUoW>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IAdoptionFactory, AdoptionFactory>();
    builder.Services.AddScoped<IAnimalRepositoryFactory, AnimalRepositoryFactory>();
    builder.Services.AddScoped<IUserRepositoryFactory, UserRepositoryFactory>();
    builder.Services.AddScoped<IGiveAnimalToShelterUoW, GiveAnimalToShelterUoW>();
    builder.Services.AddScoped<IFindStrayAnimalsUoW,FindStrayAnimalsUoW>();
    //  builder.Services.AddTransient<IValidator<DetachAnimalFromUserCommand>, DetachAnimalFromUserCommandValidator>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string dbConnection = Environment.GetEnvironmentVariable("DBConnection") ?? "DefaultConnection";
string connectionString = builder.Configuration.GetConnectionString(dbConnection);
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}
app.Run();




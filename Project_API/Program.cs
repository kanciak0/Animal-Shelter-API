using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_API.Common.Behaviours;
using Project_API.Common.Mappings;
using Project_API.Features._Animals;
using Project_API.Infrastructure.Persistence;
using System.Diagnostics;
using System.Reflection;
using static Project_API.Features._Animals.AssignAnimalToUserCommandHandler;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
//  builder.Services.AddTransient<IValidator<DetachAnimalFromUserCommand>, DetachAnimalFromUserCommandValidator>();
//  builder.Services.AddValidatorsFromAssembly(typeof(AssignAnimalToUserCommandValidator).Assembly);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string dbConnection = Environment.GetEnvironmentVariable("DBCONNECTION") ?? "DefaultConnection";
string connectionString = builder.Configuration.GetConnectionString(dbConnection);
builder.Services.AddDbContext<DemoDatabaseContext>(options =>
{
    options.UseSqlServer(connectionString);

});

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




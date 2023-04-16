using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.Entities.AnimalAggregate;
using Project_API.Infrastructure.Persistence;
using System.Text.Json.Serialization;
using static Animal;

namespace Project_API.Controllers._Users
{
    public class CreateAnimalController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Create(CreateAnimalCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateAnimalCommand : IRequest<string>
    {
        public string Name { get; set; }
        public Species Species { get; set; }
        public HealthCondition HealthCondition { get; set; }
    }
    internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, string>
    {
        private readonly IAnimalRepository _animalRepository;
        public CreateAnimalCommandHandler(IAnimalRepository animalrepository) { _animalRepository = animalrepository; }
        public Task<string> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var entity = CreateNewAnimal(request.Name, request.Species, request.HealthCondition);
            _animalRepository.InsertAnimal(entity);
            _animalRepository.SaveChangesAsync();
            return Task.FromResult(entity.Name+" has been created");
        }
    }
  /*  public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
    {
        private readonly DemoDatabaseContext _dbcontext;
        public CreateAnimalCommandValidator(DemoDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;

            RuleFor(x => x.Name)
                   .MaximumLength(50)
                   .NotEmpty();
            RuleFor(x =>x.Species._Species)
                   .MaximumLength(50)
                   .NotEmpty();
        }
    }*/
}
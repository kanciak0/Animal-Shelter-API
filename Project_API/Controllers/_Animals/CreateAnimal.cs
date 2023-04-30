using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Entities.AnimalAggregate;
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
            var animalId = Animal_ID.NewId();
            var entity = new Animal(animalId, request.Name, request.Species, request.HealthCondition);

            _animalRepository.Insert(entity);
            _animalRepository.SaveChangesAsync();

            return Task.FromResult(entity.Name+" has been created");
        }
    }
}
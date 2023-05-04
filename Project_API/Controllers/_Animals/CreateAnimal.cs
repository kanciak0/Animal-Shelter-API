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
        public async Task<ActionResult<CreateAnimalResult>> Create(CreateAnimalCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateAnimalCommand : IRequest<CreateAnimalResult>
    {
        public string Name { get; set; }
        public Species Species { get; set; }
        public HealthCondition HealthCondition { get; set; }
    }
    public class CreateAnimalResult
    {
        public string Name { get; set; }
        public Species Species { get; set; }
        public HealthCondition HealthCondition { get; set; }
        public string Message { get; set; }
    }
    internal class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, CreateAnimalResult>
    {
        private readonly IAnimalRepository _animalRepository;
        public CreateAnimalCommandHandler(IAnimalRepository animalrepository) { _animalRepository = animalrepository; }
        public async Task<CreateAnimalResult> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animalId = Animal_ID.NewId();
            var entity = new Animal(animalId, request.Name, request.Species, request.HealthCondition);

            _animalRepository.Insert(entity);
            await _animalRepository.SaveChangesAsync();

            return await Task.FromResult(new CreateAnimalResult
            {
                Name = request.Name,
                Species = request.Species,
                HealthCondition = request.HealthCondition,
                Message = "Animal has been succesfully created"
            });
        }
    }

}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using static Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimal;
using Project_API.Entities.AnimalAggregate;
using Project_API.Domain.Animal_ShelterAggregate;

namespace Project_API.Features._AnimalShelter
{
    public class GiveAnimalToShelterController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Adoptions(GiveAnimalToShelterCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class GiveAnimalToShelterCommand : IRequest<string>
    {
        public Animal_ID animal_id { get; set; }
        public HealthCondition HealthCondition { get; set; }
    }
    internal class GiveAnimalToShelterHandler : IRequestHandler<GiveAnimalToShelterCommand, string>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalShelterRepository _animalShelterRepository;
        public GiveAnimalToShelterHandler(IAnimalRepository animalrepository, IAnimalShelterRepository animalShelterRepository)
        {
            _animalShelterRepository = animalShelterRepository;
            _animalRepository = animalrepository;
        }
        public async Task<string> Handle(GiveAnimalToShelterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                return await Task.FromResult("Animal has been succesfully given to shelter");
            }

            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}



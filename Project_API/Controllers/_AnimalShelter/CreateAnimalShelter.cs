using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Domain.Abstract;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;

namespace Project_API.Features._AnimalShelter
{
    public class CreateAnimalShelter : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Adoptions([FromBody]CreateAnimalShelterCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateAnimalShelterCommand : IRequest<string>
    {
    }
    internal class CreateAnimalShelterHandler : IRequestHandler<CreateAnimalShelterCommand, string>
    {
        private readonly IAnimalShelterRepository _animalShelterRepository;
        public CreateAnimalShelterHandler(IAnimalShelterRepository animalShelterRepository)
        {
            _animalShelterRepository = animalShelterRepository;
        }
        public async Task<string> Handle(CreateAnimalShelterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animalShelterID = new AnimalShelter_ID(Guid.NewGuid());
                var animals = new List<ShelteredAnimal>();
                var clients = new List<Client>();
                var adoptions = new List<Adoption>();
                var shelter = new AnimalShelter(animalShelterID,animals, clients, adoptions);

                _animalShelterRepository.Insert(shelter);
                await _animalShelterRepository.SaveChangesAsync();
                _animalShelterRepository.Dispose();
                return await Task.FromResult("AnimalShelter has been succesfully made");
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}



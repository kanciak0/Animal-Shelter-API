using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Domain.Abstract;
using Project_API.Domain.Animal_ShelterAggregate;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;

namespace Project_API.Features._AnimalShelter
{
    public class GiveAnimalToShelterController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GiveAnimalFromClientToShelterResult>> Adoptions(GiveAnimalFromClientToShelterCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class GiveAnimalFromClientToShelterCommand : IRequest<GiveAnimalFromClientToShelterResult>
    {
        public AnimalShelter_ID AnimalShelter_ID { get; set; }
        public User_ID User_ID { get; set; }
        public UserAnimalId UserAnimalsID { get; set; }
    }
    public class GiveAnimalFromClientToShelterResult
    {
        public AnimalShelter_ID AnimalShelter_ID { get; set; }
        public Client_ID Client_ID { get; set; }
        public ShelteredAnimal_ID  ShelteredAnimal_ID { get; set; }
        public string Message { get; set; }

    }
    internal class GiveAnimalToShelterHandler : IRequestHandler<GiveAnimalFromClientToShelterCommand, GiveAnimalFromClientToShelterResult>
    {
        private readonly IGiveAnimalToShelterUoW _giveAnimalToShelterUoW;
        public GiveAnimalToShelterHandler(IGiveAnimalToShelterUoW giveAnimalToShelterUoW)
        {
            _giveAnimalToShelterUoW = giveAnimalToShelterUoW;
        }
        public async Task<GiveAnimalFromClientToShelterResult> Handle(GiveAnimalFromClientToShelterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _giveAnimalToShelterUoW.DoWork(request);
                return await Task.FromResult(new GiveAnimalFromClientToShelterResult
                {
                    AnimalShelter_ID = request.AnimalShelter_ID,
                    ShelteredAnimal_ID = new ShelteredAnimal_ID(request.UserAnimalsID.Value),
                    Client_ID = new Client_ID(request.User_ID.Value),
                    Message = "Animal has been successfully given to shelter"
                });
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}



using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities.Animal_ShelterAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;
using System.Diagnostics;
using Project_API.Common.Mappings;
namespace Project_API.Features._AnimalShelter
{
    public class AdoptController : ApiControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<string>> Adoptions(Animal_ID id)
        {
           // await Mediator.Send(new DeleteAnimalCommand { Id = id });
            return Ok();
        }
    }
    public class AdoptCommand : IRequest<string>
    {
        public User_ID User_Id { get; set; }
        public ShelteredAnimal_ID ShelteredAnimal_ID { get; set; }
    }
    internal class AdoptCommandHandler : IRequestHandler<AdoptCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAnimalShelterRepository _animalShelterRepository;
        public AdoptCommandHandler(IUserRepository userRepository,IAnimalShelterRepository animalShelterRepository) 
        {
            _animalShelterRepository = animalShelterRepository;
            _userRepository = userRepository;
        }
        public Task<string> Handle(AdoptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepository.GetUserByID(request.User_Id);
                var client = Client.CreateClient(new Client_ID
                    (user.User_UUID.Value), 
                    user.UserName, 
                    new ClientCredentials
                    (user.UserCredentials.FirstName,
                    user.UserCredentials.LastName), 
                    new ClientAddress
                    (user.UserAddress.Street,
                    user.UserAddress.City, 
                    user.UserAddress.State,
                    user.UserAddress.HouseNumber),
                    user.Age);
                var shelteredAnimal = _animalShelterRepository.GetShelteredAnimalByID(request.ShelteredAnimal_ID);
                user.AnimalIds.Add(new UserAnimalsID(shelteredAnimal.ShelteredAnimal_UUID.Value));
                var animalshelter = new AnimalShelter();
                animalshelter.Adopt(client.Client_UUID, shelteredAnimal.ShelteredAnimal_UUID, client, shelteredAnimal);
                _userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}

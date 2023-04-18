using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities.AnimalAggregate;
using Project_API.Infrastructure.Persistence;
using System.Diagnostics;

namespace Project_API.Features.User
{
    public class DeleteAnimalController : ApiControllerBase
    {

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Animal_ID id)
        {
            await Mediator.Send(new DeleteAnimalCommand { Id = id });
            return Ok();
        }
    }
    public class DeleteAnimalCommand : IRequest<string>
    {
        public Animal_ID Id { get; set; }
    }
    internal class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, string>
    {
        private readonly IAnimalRepository _animalRepository;
        public DeleteAnimalCommandHandler(IAnimalRepository animalrepository) { _animalRepository = animalrepository; }
        public Task<string> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animal = _animalRepository.GetAnimalByID(request.Id);
                _animalRepository.DeleteAnimal(animal.Animal_UUID);//Check after
                _animalRepository.SaveChangesAsync();
                return Task.FromResult("User has been deleted");
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}

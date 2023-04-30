using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Entities.AnimalAggregate;

namespace Project_API.Features._Animals
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
        public async Task<string> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animal = _animalRepository.GetByID(request.Id.ToGuid());
                _animalRepository.Delete(animal.Animal_UUID.ToGuid());//Check after
                await _animalRepository.SaveChangesAsync();
                return await Task.FromResult("User has been deleted");
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}

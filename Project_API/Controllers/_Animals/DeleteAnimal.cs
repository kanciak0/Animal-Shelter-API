using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API.Common;
using Project_API.Entities.AnimalAggregate;

namespace Project_API.Features._Animals
{
    public class DeleteAnimalController : ApiControllerBase
    {

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteAnimalResult>> Delete(Animal_ID id)
        {
            await Mediator.Send(new DeleteAnimalCommand { Id = id });
            return Ok();
        }
    }
    public class DeleteAnimalCommand : IRequest<DeleteAnimalResult>
    {
        public Animal_ID Id { get; set; }
    }
    public class DeleteAnimalResult
    {
        public Animal_ID Id { get; set; }
        public string Message { get; set; }
    }
    internal class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, DeleteAnimalResult>
    {
        private readonly IAnimalRepository _animalRepository;
        public DeleteAnimalCommandHandler(IAnimalRepository animalrepository) { _animalRepository = animalrepository; }
        public async Task<DeleteAnimalResult> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animal = _animalRepository.GetByID(request.Id.ToGuid());
                _animalRepository.Delete(animal.Animal_UUID.ToGuid());//Check after

                await _animalRepository.SaveChangesAsync();
                _animalRepository.Dispose();
                return await Task.FromResult(
                    new DeleteAnimalResult
                    {
                        Id = request.Id,
                        Message = "Animal has been succesfully deleted"
                    });
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}

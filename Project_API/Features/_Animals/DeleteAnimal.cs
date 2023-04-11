using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities;
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
        private readonly DemoDatabaseContext _dbcontext;
        public DeleteAnimalCommandHandler(DemoDatabaseContext dbcontext) { _dbcontext = dbcontext; }
        public Task<string> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var animal = _dbcontext.Animals.FirstOrDefault(x => x.Animal_UUID == request.Id)
                ?? throw new Exception("User not found");
                _dbcontext.Entry(animal).State = EntityState.Deleted;
                _dbcontext.SaveChanges();
                return Task.FromResult("Animal has been deleted");
            }
            catch (Exception)
            {
                throw new Exception("An error has occured");
            }
        }
    }
}

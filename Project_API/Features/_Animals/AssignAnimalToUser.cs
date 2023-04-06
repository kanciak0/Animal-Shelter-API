using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Features.User;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Features._Animals
{
    public class AssignAnimatoUserController : ApiControllerBase
    {
        [HttpPut("{uuid}")]
        public async Task<IActionResult> Assign([FromRoute] Guid uuid, [FromBody] AssignAnimalToUserCommand command)
        {
            command.Uuid = uuid;
            await Mediator.Send(command);

            return NoContent();
        }

    }
    public class AssignAnimalToUserCommand : IRequest<Unit>
    {
        public Guid Uuid { get; set; }  
        public ICollection<Guid> AnimalUuids { get; set; } = new List<Guid>();
    }

        internal class AssignAnimalToUserCommandHandler : IRequestHandler<AssignAnimalToUserCommand, Unit>
    {
        private readonly DemoDatabaseContext _dbcontext;

        public AssignAnimalToUserCommandHandler(DemoDatabaseContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<Unit> Handle(AssignAnimalToUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbcontext.Users.Include(u => u.Animals).FirstOrDefaultAsync(x => x.UUID == request.Uuid, cancellationToken);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                foreach (var animalUuid in request.AnimalUuids)
                {
                    if (!user.Animals.Any(a => a.Animal_UUID == animalUuid))
                    {
                        var animal = await _dbcontext.Animals.FirstOrDefaultAsync
                            (x => x.Animal_UUID == animalUuid, cancellationToken);
                        if (animal == null)
                        {
                            throw new Exception($"Animal with UUID {animalUuid} not found"); //TODO: Make validation for animals through db like it is below instead
                        }
                        user.Animals.Add(animal);
                    }
                }
                await _dbcontext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Unit.Value;
        }
    }
}

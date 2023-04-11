using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Features._Animals
{
    public class DetachAnimalFromUserController : ApiControllerBase
    {
        [HttpPut("{uuid}")]
        public async Task<ActionResult<string>> Detach([FromQuery] User_ID uuid, [FromBody] DetachAnimalFromUserCommand command)

        {
            command.Uuid = uuid;
            await Mediator.Send(command);

            return Ok();
        }
    }

    public class DetachAnimalFromUserCommand : IRequest<string>
    {
        public User_ID Uuid { get; set; }
        public ICollection<Animal_ID> AnimalUuids { get; set; } = new List<Animal_ID>();
    }

    internal class DetachAnimalFromUserCommandHandler : IRequestHandler<DetachAnimalFromUserCommand, string>
    {
        private readonly DemoDatabaseContext _dbcontext;

        public DetachAnimalFromUserCommandHandler(DemoDatabaseContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<string> Handle(DetachAnimalFromUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: Looks a bit like spaghetti need to apply some fluent validator logic instead or else, works for now.
            try
            {
                var user = await _dbcontext.Users.Include(u => u.Animals)
                    .FirstOrDefaultAsync(x => x.User_UUID == request.Uuid, cancellationToken)
                    ?? throw new Exception("User not found");

                foreach (var animalUuid in request.AnimalUuids)
                {
                    var animal = await _dbcontext.Animals.FirstOrDefaultAsync(a => a.Animal_UUID == animalUuid, cancellationToken)
                    ?? throw new Exception($"Animal with UUID {animalUuid} not found");

                    if (!user.Animals.Contains(animal))
                    {
                        throw new Exception($"Animal with UUID {animalUuid} is not attached to user with UUID {request.Uuid}");
                    }
                    user.Animals.Remove(animal);
                }
                await _dbcontext.SaveChangesAsync(cancellationToken); 

                return "Animal(s) detached successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to detach animal: {ex.Message}");
            }
        }
        public class DetachAnimalFromUserCommandValidator : AbstractValidator<DetachAnimalFromUserCommand>
        {
            public DetachAnimalFromUserCommandValidator()
            {
                RuleFor(x => x.AnimalUuids)
                    .NotEmpty()
                    .WithMessage("At least one animal UUID is required to detach an animal from a user.");
            }
        }
    }
}

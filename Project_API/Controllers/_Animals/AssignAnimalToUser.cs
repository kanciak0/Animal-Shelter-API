using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities.AnimalAggregate;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Features._Animals
{/*
    public class AssignAnimaltoUserController : ApiControllerBase
    {
        [HttpPut("{uuid}")]
        public async Task<ActionResult<string>> Assign([FromQuery] User_ID uuid, [FromBody] AssignAnimalToUserCommand command)

        {
            command.Uuid = uuid;
            await Mediator.Send(command);

            return Ok();
        }
    }

    public class AssignAnimalToUserCommand : IRequest<string>
    {
        public User_ID Uuid { get; set; }
        public ICollection<Animal_ID> AnimalUuids { get; set; } = new List<Animal_ID>();
    }

    internal class AssignAnimalToUserCommandHandler : IRequestHandler<AssignAnimalToUserCommand, string>
    {
        private readonly DemoDatabaseContext _dbcontext;

        public AssignAnimalToUserCommandHandler(DemoDatabaseContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<string> Handle(AssignAnimalToUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: Looks a bit like spaghetti need to apply some fluent validator logic instead or else, works for now.
            try
            {
                var user = await _dbcontext.Users.Include(u => u.Animals)
                    .FirstOrDefaultAsync(x => x.User_UUID == request.Uuid, cancellationToken)
                    ?? throw new Exception("User not found");
                if (user.Animals.Count >= 2)
                {
                    throw new Exception("User already has 2 or more animals assigned");
                }
                foreach (var animalUuid in request.AnimalUuids)
                {
                    if (!user.Animals.Any(a => a.Animal_UUID == animalUuid))
                    {
                        var animal = await _dbcontext.Animals.FirstOrDefaultAsync
                            (x => x.Animal_UUID == animalUuid, cancellationToken)
                            ?? throw new Exception($"Animal with UUID {animalUuid} not found");
                        user.Animals.Add(animal);
                    }
                }
                await _dbcontext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return "Animal has been succesfully assigned";
        }
        public class AssignAnimalToUserCommandValidator : AbstractValidator<AssignAnimalToUserCommand>
        {
            private readonly DemoDatabaseContext _dbcontext;
            public AssignAnimalToUserCommandValidator(DemoDatabaseContext dbcontext)
            {
                _dbcontext = dbcontext; 
                RuleFor(x => x.AnimalUuids).Must(animalUuids => animalUuids.Count <= 2)
                    .WithMessage("User cannot have more than 2 animals");
            }
        }
    }*/
}

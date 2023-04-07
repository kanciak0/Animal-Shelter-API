using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Features.User
{
    public class UpdateUserController : ApiControllerBase
    {
        [HttpPut("{uuid}")]
        public async Task<IActionResult> Update(Guid uuid, UpdateUserCommand command)
        {
            command.Uuid = uuid;
            await Mediator.Send(command);

            return NoContent();
        }
    }

    public class UpdateUserCommand : IRequest<Unit>
    {
        public Guid Uuid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public ICollection<Guid> AnimalUuids { get; set; } = new List<Guid>();
    }

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly DemoDatabaseContext _dbContext;

        public UpdateUserCommandHandler(DemoDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Users.Include(u => u.Animals).FirstOrDefaultAsync(x => x.UUID == request.Uuid, cancellationToken);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                user.UserName = request.UserName;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.City = request.City;
                user.State = request.State;
                user.Country = request.Country;

                foreach (var animalUuid in request.AnimalUuids)
                {
                    if (!user.Animals.Any(a => a.Animal_UUID == animalUuid))
                    {
                        var animal = await _dbContext.Animals.FirstOrDefaultAsync
                            (x => x.Animal_UUID == animalUuid, cancellationToken); 
                        if (animal == null)
                        {
                            throw new Exception($"Animal with UUID {animalUuid} not found"); //TODO: Make validation for animals
                                                                                             //through db like it is below instead
                        }
                        user.Animals.Add(animal);
                    }
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Unit.Value;
        }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly DemoDatabaseContext _dbContext;
        public UpdateUserCommandValidator(DemoDatabaseContext dbcontext)
        {
            _dbContext = dbcontext;
            RuleFor(x => x.UserName)
                .MaximumLength(200)
                .NotEmpty()
                .MustAsync(BeUniqueUsername);
            RuleFor(x => x.FirstName)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(x => x.City)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(x => x.Country)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(x => x.State)
                .MaximumLength(200)
                .NotEmpty();

        }
        private Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .AllAsync(User => User.UserName != username, cancellationToken);
        }
    }
}

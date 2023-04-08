using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.Common.Models;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence;

namespace Project_API.Controllers._Users
{
    public class CreateUserController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<Guid>> Create(CreateUserCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly DemoDatabaseContext _dbContext;
        public CreateUserCommandHandler(DemoDatabaseContext dbcontext) { _dbContext = dbcontext; }
        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User_entity
            {
                UUID = Guid.NewGuid(),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                City = request.City,
                Country = request.Country,
                State = request.State,
            };
            _dbContext.Users.Add(entity);

            _dbContext.SaveChanges();
            return Task.FromResult(entity.UUID);
        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly DemoDatabaseContext _dbContext;
        public CreateUserCommandValidator(DemoDatabaseContext dbcontext)
        {
            _dbContext = dbcontext;
            RuleFor(Username => Username.UserName)
                   .MaximumLength(50)
                   .NotEmpty()
                   .MustAsync(BeUniqueUsername);
            RuleFor(FirstName => FirstName.FirstName)
                    .MaximumLength(50)
                    .NotEmpty();
            RuleFor(LastName => LastName.LastName)
                .MaximumLength(100)
                .NotEmpty();
            RuleFor(City => City.City)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(Country => Country.Country)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(State => State.State)
                .MaximumLength(50)
                .NotEmpty();
        }
        private Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .AllAsync(User => User.UserName != username, cancellationToken);
        }
    }
}
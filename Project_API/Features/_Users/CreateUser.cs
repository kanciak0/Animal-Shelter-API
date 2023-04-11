using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Common.Mappings;
using Project_API.Entities;
using Project_API.Infrastructure.Persistence;
using Project_API.ValueObjects;
using Project_API.ValueObjects.UserValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Project_API.Controllers._Users
{
    public class CreateUserController : ApiControllerBase
    {
        [HttpPost()]
        public async Task<ActionResult<string>> Create(CreateUserCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public UserCredentials Credentials { get; set; }
        public Address Address { get; set; }

    }
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly DemoDatabaseContext _dbContext;
        public CreateUserCommandHandler(DemoDatabaseContext dbcontext) { _dbContext = dbcontext; }
        public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User_Entity.Create(request.UserName, request.Credentials, request.Address);
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
            return Task.FromResult(user.UserName+" user has been correctly created");
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
        }
        private Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .AllAsync(User => User.UserName != username, cancellationToken);
        }
    }
}
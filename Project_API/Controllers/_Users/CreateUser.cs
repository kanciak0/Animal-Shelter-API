using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Common;
using Project_API.Entities.UserAggregate;
using Project_API.Infrastructure.Persistence;


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
        public UserAddress Address { get; set; }
        public int Age { get; set; }

    }
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository) { _userRepository = userRepository; }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User(request.UserName, request.Credentials, request.Address,request.Age);
            _userRepository.Insert(entity);
            await _userRepository.SaveChangesAsync();
            return await Task.FromResult(entity.UserName + " has been created");
        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly DatabaseContext _dbContext;
        public CreateUserCommandValidator(DatabaseContext dbcontext)
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


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
        public async Task<ActionResult<CreateUserResult>> Create(CreateUserCommand request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
    public class CreateUserCommand : IRequest<CreateUserResult>
    {
        public string UserName { get; set; }
        public UserCredentials Credentials { get; set; }
        public UserAddress Address { get; set; }
        public int Age { get; set; }

    }
    public class CreateUserResult
    {
        public string UserName { get; set; }
        public UserCredentials Credentials { get; set; }
        public UserAddress Address { get; set; }
        public int Age { get; set; }
        public string Message { get; set; }

    }
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository) { _userRepository = userRepository; }
        public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User(request.UserName, request.Credentials, request.Address,request.Age);
            _userRepository.Insert(entity);
            await _userRepository.SaveChangesAsync();
            _userRepository.Dispose();
            return await Task.FromResult(
                new CreateUserResult
                {
                    UserName = request.UserName,
                    Credentials = request.Credentials,
                    Address = request.Address,
                    Age = request.Age,
                    Message = $"(entity.Username) has been created"
                }
        
           );
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

